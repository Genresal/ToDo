namespace ToDo.DAL.Entities.Core;
public interface IEntity
{
    public long Id { get; set; }

    public DateTime Created { get; set; }

    public DateTime? Updated { get; set; }
}
