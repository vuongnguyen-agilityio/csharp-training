using Application.Data;
using Domain.Users;
using MediatR;

namespace Application.Users.Update;

internal sealed class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand>
{
    private readonly IUserRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateUserCommandHandler(IUserRepository userRepository, IUnitOfWork unitOfWork)
    {
        _repository = userRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _repository.GetByIdAsync(request.UserId);

        if (user is null)
        {
            throw new UserNotFoundException(request.UserId);
        }

        user.Update(
            request.Name,
            request.Password);

        _repository.Update(user);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
