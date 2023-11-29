using Application.Data;
using Domain.Products;
using Domain.PurchaseHistories;
using Domain.PurchaseHistoryItems;
using MediatR;

namespace Application.PurchaseHistoryItems.Update
{
    internal sealed class UpdatePurchaseHistoryItemCommandHandler : IRequestHandler<UpdatePurchaseHistoryItemCommand>
    {
        private readonly IPurchaseHistoryItemRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdatePurchaseHistoryItemCommandHandler(IPurchaseHistoryItemRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(UpdatePurchaseHistoryItemCommand request, CancellationToken cancellationToken)
        {
            var purchaseHistoryItem = await _repository.GetByIdAsync(request.PurchaseHistoryItemId);

            if (purchaseHistoryItem is null)
            {
                throw new PurchaseHistoryItemNotFoundException(request.PurchaseHistoryItemId);
            }

            purchaseHistoryItem.Update(
                new PurchaseHistoryId(request.PurchaseHistoryId.Value),
                new ProductId(request.ProductId.Value),
                new Domain.Products.Money(request.ProductCurrency, request.ProductAmount),
                request.Quantity
                );

            _repository.Update(purchaseHistoryItem);

            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
