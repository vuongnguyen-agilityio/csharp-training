using Application.Products.Get;
using MediatR;

namespace Application.Products.List;

public record ListProductQuery() : IRequest<List<ProductResponse>>;
