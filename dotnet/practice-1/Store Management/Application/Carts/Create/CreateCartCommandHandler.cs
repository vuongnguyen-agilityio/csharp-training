using Application.Data;
using Domain.Carts;
using Domain.Products;
using Domain.Users;
using MediatR;

namespace Application.Carts.Create
{
    internal sealed class CreateCartCommandHandler : IRequestHandler<CreateCartCommand>
    {
        private readonly ICartRepository _repository;

        private readonly IUnitOfWork _unitOfWork;

        public CreateCartCommandHandler(ICartRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(CreateCartCommand request, CancellationToken cancellationToken)
        {
            var cart = new Cart(
                new UserId(request.UserId.Value),
                new ProductId(request.ProductId.Value),
                request.Quantity);

            _repository.Add(cart);

            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
