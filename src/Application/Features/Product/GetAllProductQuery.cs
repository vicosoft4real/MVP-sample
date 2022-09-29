using MediatR;

namespace Application.Features.Product;

public record GetAllProductQuery :  IRequest<List<GetProductResponse>>
{
    
}