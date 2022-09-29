namespace Application.Features.Product;

public record GetProductResponse 
{
    public Guid Id { get; set; }
    public string Description { get;  set; }
    public string Number { get;  set; }
    public decimal Price { get;  set; }
    public bool Active { get;  set; }

    public Guid GroupId { get; set; }
}