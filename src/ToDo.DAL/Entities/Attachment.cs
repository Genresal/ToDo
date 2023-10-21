using ToDo.DAL.Entities.Core;

namespace ToDo.DAL.Entities;
public class Attachment : Entity
{
    public int TaskId { get; set; }

    public Task Task { get; set; }
}
