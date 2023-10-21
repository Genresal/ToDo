namespace ToDo.DAL.Entities.Core;

public class Entity : IEntity
{
    public int Id { get; set; }

    public DateTime Created { get; set; } = DateTime.UtcNow;

    public DateTime? Updated { get; set; }
}
