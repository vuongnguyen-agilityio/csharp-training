using Application.Data;
using Domain.Users;
using MediatR;

namespace Application.Users.Create
{
    internal sealed class CreateUserCommandHandler : IRequestHandler<CreateUserCommand>
    {
        private readonly IUserRepository _repository;

        private readonly IUnitOfWork _unitOfWork;

        public CreateUserCommandHandler(IUserRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User(
                new UserId(Guid.NewGuid()),
                request.Email,
                request.Name,
                request.Password,
                UserRole.User);

            _repository.Add(user);

            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
