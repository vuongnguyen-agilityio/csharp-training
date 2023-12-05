using Application.Products.Get;
using MediatR;

namespace Application.Products.List;

public record ListProductQuery(
    int Skip,
    int Take
    ) : IRequest<List<ProductResponse>>;
