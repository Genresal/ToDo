using Microsoft.AspNetCore.Mvc;

namespace Todo.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MessageController : ControllerBase
{
    public MessageController()
    {
    }

    [Route("[action]/{message}")]
    [HttpGet]
    public IActionResult SendMessage(string message)
    {
        return Ok("Сообщение отправлено");
    }
}