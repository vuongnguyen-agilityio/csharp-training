using Application.Data;
using Domain.PurchaseHistories;
using Domain.Users;
using MediatR;

namespace Application.PurchaseHistories.Update
{
    internal sealed class UpdatePurchaseHistoryCommandHandler : IRequestHandler<UpdatePurchaseHistoryCommand>
    {
        private readonly IPurchaseHistoryRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdatePurchaseHistoryCommandHandler(IPurchaseHistoryRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(UpdatePurchaseHistoryCommand request, CancellationToken cancellationToken)
        {
            var purchaseHistory = await _repository.GetByIdAsync(request.PurchaseHistoryId);

            if (purchaseHistory is null)
            {
                throw new PurchaseHistoryNotFoundException(request.PurchaseHistoryId);
            }

            purchaseHistory.Update(
                new UserId(request.UserId.Value),
                new Money(request.Currency, request.Amount));

            _repository.Update(purchaseHistory);

            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
