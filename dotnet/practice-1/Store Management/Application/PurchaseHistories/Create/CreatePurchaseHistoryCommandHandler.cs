using Application.Data;
using Application.PurchaseHistoryItems.Create;
using Domain.Products;
using Domain.PurchaseHistories;
using Domain.PurchaseHistoryItems;
using Domain.Users;
using MediatR;

namespace Application.PurchaseHistories.Create
{
    internal sealed class CreatePurchaseHistoryCommandHandler : IRequestHandler<CreatePurchaseHistoryCommand>
    {
        private readonly IPurchaseHistoryRepository _repository;
        private readonly IPurchaseHistoryItemRepository _purchaseHistoryItemRepository;

        private readonly IUnitOfWork _unitOfWork;

        public CreatePurchaseHistoryCommandHandler(IPurchaseHistoryRepository repository, IPurchaseHistoryItemRepository purchaseHistoryItemRepository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _purchaseHistoryItemRepository = purchaseHistoryItemRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(CreatePurchaseHistoryCommand request, CancellationToken cancellationToken)
        {
            List<CreatePurchaseHistoryItemRequest> purchaseHistoryItems = request.CreatePurchaseHistoryItemRequest;
            var currency = purchaseHistoryItems[0].ProductCurrency;
            decimal amount = purchaseHistoryItems.Aggregate(0m, (total, item) => total + (item.Quantity * item.ProductAmount));

            var purchaseHistory = new PurchaseHistory(
                new PurchaseHistoryId(Guid.NewGuid()),
                new UserId(request.UserId.Value),
                new Domain.PurchaseHistories.Money(currency, amount));

            _repository.Add(purchaseHistory);

            // Save Items async
            foreach (CreatePurchaseHistoryItemRequest command in purchaseHistoryItems)
            {
                PurchaseHistoryItem _purchaseHistoryItems = new PurchaseHistoryItem(
                    new PurchaseHistoryItemId(Guid.NewGuid()),
                    new PurchaseHistoryId(purchaseHistory.Id.Value),
                    new UserId(request.UserId.Value),
                    new ProductId(command.ProductId.Value),
                    new Domain.Products.Money(command.ProductCurrency, command.ProductAmount),
                    command.Quantity
                    );
                _purchaseHistoryItemRepository.Add(_purchaseHistoryItems);
            }

            await _unitOfWork.SaveChangesAsync();
        }
    }
}
