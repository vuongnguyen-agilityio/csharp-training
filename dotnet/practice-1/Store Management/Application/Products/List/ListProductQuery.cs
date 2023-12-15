using Application.Abstractions.Messaging;
using Application.Products.Get;

namespace Application.Products.List;

public record ListProductQuery(
    int Skip,
    int Take
    ) : ICommand<List<ProductResponse>>;
