using Application.Data;
using Domain.PurchaseHistoryItems;
using MediatR;

namespace Application.PurchaseHistoryItems.Delete
{
    internal sealed class DeletePurchaseHistoryItemCommandHandler : IRequestHandler<DeletePurchaseHistoryItemCommand>
    {
        private readonly IPurchaseHistoryItemRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public DeletePurchaseHistoryItemCommandHandler(IPurchaseHistoryItemRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(DeletePurchaseHistoryItemCommand request, CancellationToken cancellationToken)
        {
            var purchaseHistoryItem = await _repository.GetByIdAsync(request.PurchaseHistoryItemId);

            if (purchaseHistoryItem is null)
            {
                throw new PurchaseHistoryItemNotFoundException(request.PurchaseHistoryItemId);
            }

            _repository.Remove(purchaseHistoryItem);

            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
