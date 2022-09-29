namespace Core.Entity;

public class Group : BaseEntity
{
    public Group(string description, string code, bool active)
    {
        Description = description;
        Code = code;
        Active = active;
    }
    public string Description { get; private set; }
    public string Code { get; private set; }

    public Group SetId(Guid? id = null)
    {
        Id = id ?? Guid.NewGuid();

        return this;
    }
}