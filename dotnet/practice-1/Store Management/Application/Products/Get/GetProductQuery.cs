using Application.Abstractions.Messaging;
using Domain.Products;

namespace Application.Products.Get;

public record GetProductQuery(ProductId ProductId) : ICommand<ProductResponse>;

public record ProductResponse(
    Guid Id,
    string Name,
    string Sku,
    string Currency,
    decimal Amount,
    DateTime CreatedDate,
    DateTime UpdatedDate);
