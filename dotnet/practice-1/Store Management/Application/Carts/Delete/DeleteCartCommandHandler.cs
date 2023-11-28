using Application.Data;
using Domain.Carts;
using Domain.Products;
using Domain.Users;
using MediatR;

namespace Application.Carts.Delete;

internal sealed class DeleteCartCommandHandler : IRequestHandler<DeleteCartCommand>
{
    private readonly ICartRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteCartCommandHandler(ICartRepository cartRepository, IUnitOfWork unitOfWork)
    {
        _repository = cartRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(DeleteCartCommand request, CancellationToken cancellationToken)
    {
        var cart = await _repository.GetByIdAsync(new UserId(request.UserId.Value), new ProductId(request.ProductId.Value));

        if (cart is null)
        {
            throw new CartNotFoundException(new ProductId(request.ProductId.Value));
        }

        _repository.Remove(cart);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
