using Application.Data;
using Domain.Users;
using MediatR;

namespace Application.Users.Delete;

internal sealed class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand>
{
    private readonly IUserRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteUserCommandHandler(IUserRepository userRepository, IUnitOfWork unitOfWork)
    {
        _repository = userRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _repository.GetByIdAsync(request.UserId);

        if (user is null)
        {
            throw new UserNotFoundException(request.UserId);
        }

        _repository.Remove(user);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
