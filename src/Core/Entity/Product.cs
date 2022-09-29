namespace Core.Entity;

public class Product : BaseEntity
{
    public Product(string description, string number, bool active, decimal price, Guid groupId)
    {
        Description = description;
        Number = number;
        Active = active;
        Price = price;
        GroupId = groupId;
    }

    private Product()
    {
        
    }
    public string Description { get; private set; }
    public string Number { get; private set; }
    public decimal Price { get; private set; }
    public Guid GroupId { get; private set; }
    

    public Group Group { get; private set; }
 
    public Product SetGroup(Group group)
    {
        Group = group;
        return this;
    }
    public Product SetId(Guid? id = null)
    {
        Id = id ?? Guid.NewGuid();
        return this;
    }
    
}