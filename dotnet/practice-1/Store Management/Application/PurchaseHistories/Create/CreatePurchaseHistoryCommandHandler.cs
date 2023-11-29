using Application.Data;
using Domain.PurchaseHistories;
using Domain.Users;
using MediatR;

namespace Application.PurchaseHistories.Create
{
    internal sealed class CreatePurchaseHistoryCommandHandler : IRequestHandler<CreatePurchaseHistoryCommand>
    {
        private readonly IPurchaseHistoryRepository _repository;

        private readonly IUnitOfWork _unitOfWork;

        public CreatePurchaseHistoryCommandHandler(IPurchaseHistoryRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(CreatePurchaseHistoryCommand request, CancellationToken cancellationToken)
        {
            var product = new PurchaseHistory(
                new PurchaseHistoryId(Guid.NewGuid()),
                new UserId(request.UserId.Value),
                new Money(request.Currency, request.Amount));

            _repository.Add(product);

            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
