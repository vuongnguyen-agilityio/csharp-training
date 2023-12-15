using Application.Abstractions.Messaging;
using Domain.Products;

namespace Application.Products.Update;

public record UpdateProductCommand(
    ProductId ProductId,
    string Name,
    string Sku,
    string Currency,
    decimal Amount) : ICommand;

public record UpdateProductRequest(
    string Name,
    string Sku,
    string Currency,
    decimal Amount);
