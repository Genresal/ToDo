using Microsoft.AspNetCore.SignalR;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Diagnostics;
using System.Text;
using ToDo.Client.Hubs;

namespace ToDo.Client.BackgroundServices;

public class RabbitMqService : BackgroundService
{
    private IConnection _connection;
    private IModel _channel;
    private IHubContext<MessageHub> _hubContext;

    public RabbitMqService(IHubContext<MessageHub> hubContext)
    {
        _hubContext = hubContext;

        // Не забудьте вынести значения "localhost" и "MyQueue"
        // в файл конфигурации
        var factory = new ConnectionFactory { HostName = "localhost" };
        _connection = factory.CreateConnection();
        _channel = _connection.CreateModel();
        _channel.QueueDeclare(queue: "MyQueue", durable: false, exclusive: false, autoDelete: false, arguments: null);
    }

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        stoppingToken.ThrowIfCancellationRequested();

        var consumer = new EventingBasicConsumer(_channel);
        consumer.Received += async (ch, ea) =>
        {
            var content = Encoding.UTF8.GetString(ea.Body.ToArray());

            // Каким-то образом обрабатываем полученное сообщение
            Debug.WriteLine($"Получено сообщение: {content}");
            // To list
            await _hubContext.Clients.All.SendAsync("RefreshMessages", content);

            _channel.BasicAck(ea.DeliveryTag, false);
        };

        _channel.BasicConsume("MyQueue", false, consumer);

        return Task.CompletedTask;
    }

    public override void Dispose()
    {
        _channel.Close();
        _connection.Close();
        base.Dispose();
    }
}
