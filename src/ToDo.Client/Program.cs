using Microsoft.AspNetCore.ResponseCompression;
using ToDo.Client.BackgroundServices;
using ToDo.Client.Data;
using ToDo.Client.Hubs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();

// Queue service
// https://stackoverflow.com/questions/58250893/blazor-how-to-get-the-hosted-service-instance
builder.Services.AddSingleton<RabbitMqService>();
builder.Services.AddHostedService<RabbitMqService>();

// As it named it for response compression to reduce response size
builder.Services.AddResponseCompression(o =>
{
    o.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(
        new[] { "application/octet-stream" });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();

app.MapHub<MessageHub>("/messagehub");

app.MapFallbackToPage("/_Host");

app.Run();
