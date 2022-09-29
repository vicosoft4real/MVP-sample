namespace Core.Entity;

public class Agreement : BaseEntity
{
    public Agreement(
        DateTimeOffset effectiveDate,
        DateTimeOffset expiration,
        decimal productPrice,
        decimal newPrice,
        Guid productId,
        string userId,
        Guid groupId,
        bool active)
    {
        EffectiveDate = effectiveDate;
        Expiration = expiration;
        ProductPrice = productPrice;
        NewPrice = newPrice;
        ProductId = productId;
        UserId = userId;
        GroupId = groupId;
        Active = active;
    }
    

    private Agreement()
    {
        
    }

    public DateTimeOffset EffectiveDate { get; private set; }

    public DateTimeOffset Expiration { get; private set; }

    public decimal ProductPrice { get; private set; }

    public decimal NewPrice { get; private set; }
    public Guid ProductId { get; private set; }
    public string UserId { get; private set; }
    public Guid GroupId { get; private set; }
    

    public Product Product { get; set; }

    public User User { get; set; }

    public Group Group { get; set; }

    public Agreement SetEffectiveDate(DateTimeOffset effectiveDate)
    {
        EffectiveDate = effectiveDate;
        return this;
    }
    public Agreement SetExpirationDate(DateTimeOffset expiration)
    {
        Expiration = expiration;
        return this;
    }
    public Agreement SetProductPrice(decimal productPrice)
    {
        ProductPrice = productPrice;
        return this;
    }
    public Agreement SetNewPrice(decimal newPrice)
    {
        NewPrice = newPrice;
        return this;
    }
    public Agreement SetProductId(Guid productId)
    {
        ProductId = productId;
        return this;
    }
    public Agreement SetUserId(string userId)
    {
        UserId = userId;
        return this;
    }
    public Agreement SetGroupId(Guid groupId)
    {
        GroupId = groupId;
        return this;
    }
    
    public Agreement SetActive(bool active)
    {
        Active = active;
        return this;
    }
    public Agreement SetIsDeleted(bool isDeleted)
    {
        IsDeleted = isDeleted;
        return this;
    }
    public static Agreement CreateAgreement(DateTimeOffset effectiveDate,
        DateTimeOffset expiration,
        decimal productPrice,
        decimal newPrice,
        Guid productId,
        string userId,
        Guid groupId,
        bool active)
    {
        return new Agreement(
            effectiveDate,
            expiration,
            productPrice,
            newPrice,
            productId,
            userId,
            groupId,active);
    }
}