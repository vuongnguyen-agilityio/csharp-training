using Application.Data;
using Domain.Profiles;
using Domain.Users;
using MediatR;

namespace Application.Profiles.Create
{
    internal sealed class CreateProfileCommandHandler : IRequestHandler<CreateProfileCommand>
    {
        private readonly IProfileRepository _repository;

        private readonly IUnitOfWork _unitOfWork;

        public CreateProfileCommandHandler(IProfileRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(CreateProfileCommand request, CancellationToken cancellationToken)
        {
            var user = new Profile(
                new ProfileId(Guid.NewGuid()),
                new UserId(request.UserId.Value),
                request.FirstName,
                request.LastName,
                request.Age);

            _repository.Add(user);

            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
