namespace Core.Persistence.Repositories;

public class Entity<TId>
{
    public TId Id { get; set; }
    public DateTime TimeStamp { get; set; }

    public Entity()
    {
        Id = default;
    }

    public Entity(TId id)
    {
        Id = id;
    }
}