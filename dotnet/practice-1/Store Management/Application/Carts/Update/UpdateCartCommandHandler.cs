using Application.Data;
using Domain.Carts;
using Domain.Products;
using Domain.Users;
using MediatR;

namespace Application.Carts.Update;

internal sealed class UpdateCartCommandHandler : IRequestHandler<UpdateCartCommand>
{
    private readonly ICartRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateCartCommandHandler(ICartRepository cartRepository, IUnitOfWork unitOfWork)
    {
        _repository = cartRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(UpdateCartCommand request, CancellationToken cancellationToken)
    {
        var cart = await _repository.GetByIdAsync(new UserId(request.UserId.Value), new ProductId(request.ProductId.Value));

        if (cart is null)
        {
            throw new CartNotFoundException(new ProductId(request.ProductId.Value));
        }

        cart.Update(
            new UserId(request.UserId.Value),
            new ProductId(request.ProductId.Value),
            request.Quantity);

        _repository.Update(cart);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
