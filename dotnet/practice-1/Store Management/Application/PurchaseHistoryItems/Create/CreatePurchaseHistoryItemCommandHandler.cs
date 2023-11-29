using Application.Data;
using Domain.Products;
using Domain.PurchaseHistories;
using Domain.PurchaseHistoryItems;
using MediatR;

namespace Application.PurchaseHistoryItems.Create
{
    internal sealed class CreatePurchaseHistoryItemCommandHandler : IRequestHandler<CreatePurchaseHistoryItemCommand>
    {
        private readonly IPurchaseHistoryItemRepository _repository;

        private readonly IUnitOfWork _unitOfWork;

        public CreatePurchaseHistoryItemCommandHandler(IPurchaseHistoryItemRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(CreatePurchaseHistoryItemCommand request, CancellationToken cancellationToken)
        {
            var purchaseHistoryItem = new PurchaseHistoryItem(
                new PurchaseHistoryItemId(Guid.NewGuid()),
                new PurchaseHistoryId(request.PurchaseHistoryId.Value),
                new ProductId(request.ProductId.Value),
                new Domain.Products.Money(request.ProductCurrency, request.ProductAmount),
                request.Quantity);

            _repository.Add(purchaseHistoryItem);

            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
