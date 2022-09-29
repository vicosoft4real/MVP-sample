namespace Core.Entity;
/// <summary>
/// Entity base class for all other entities
/// Other Common properties for all entities can be added here
/// </summary>
public abstract class BaseEntity
{
    public Guid Id { get; protected set; }

    public bool Active { get; protected set; }
    
    public bool IsDeleted { get; protected set; }
}