using Application.Data;
using Domain.PurchaseHistories;
using MediatR;

namespace Application.PurchaseHistories.Delete
{
    internal sealed class DeletePurchaseHistoryCommandHandler : IRequestHandler<DeletePurchaseHistoryCommand>
    {
        private readonly IPurchaseHistoryRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public DeletePurchaseHistoryCommandHandler(IPurchaseHistoryRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(DeletePurchaseHistoryCommand request, CancellationToken cancellationToken)
        {
            var purchaseHistory = await _repository.GetByIdAsync(request.UserId, request.PurchaseHistoryId);

            if (purchaseHistory is null)
            {
                throw new PurchaseHistoryNotFoundException(request.PurchaseHistoryId);
            }

            _repository.Remove(purchaseHistory);

            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
