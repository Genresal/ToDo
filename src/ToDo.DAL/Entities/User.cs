using ToDo.DAL.Entities.Core;

namespace ToDo.DAL.Entities;
public class User : Entity
{
    public string UserName { get; set; }

    public string Password { get; set; }

    public string Email { get; set; }
}
