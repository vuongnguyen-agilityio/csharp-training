using Application.Data;
using Application.Products.Get;
using Domain.Products;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Products.List;

internal sealed class ListProductQueryHandler : IRequestHandler<ListProductQuery, List<ProductResponse>>
{
    private readonly IApplicationDbContext _context;

    public ListProductQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<ProductResponse>> Handle(ListProductQuery request, CancellationToken cancellationToken)
    {
        var products = await _context
            .Products
            .Select(p => new ProductResponse(
                p.Id.Value,
                p.Name,
                p.Sku.Value,
                p.Price.Currency,
                p.Price.Amount))
            .Skip(request.Skip)
            .Take(request.Take)
            .ToListAsync(cancellationToken);

        return products;
    }
}
