using Domain.Products;
using MediatR;

namespace Application.Products.Create
{
    internal sealed class CreateProductCommandHandler : IRequestHandler<CreateProductCommand>
    {
        private readonly IProductRepository _repository;
        // TODO: Implement UnitOfWork;
        //private readonly IUnitOfWork _unitOfWork;

        public CreateProductCommandHandler(IProductRepository repository)
        {
            _repository = repository;
        }
        public Task Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Product(
                new ProductId(Guid.NewGuid()),
                request.Name,
                new Money(request.Currency, request.Amount),
                Sku.Create(request.Sku)!);

            _repository.Add(product);

            // TODO: Implement UnitOfWork
            return Task.CompletedTask;
        }
    }
}
