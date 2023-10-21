using ToDo.DAL.Entities.Core;

namespace ToDo.DAL.Entities;
public class Comment : Entity
{
    public string Text { get; set; }

    public int TaskId { get; set; }
    public int UserId { get; set; }

    public Task Task { get; set; }
    public User User { get; set; }
}
