using Application.Data;
using Domain.Profiles;
using MediatR;

namespace Application.Profiles.Delete;

internal sealed class DeleteProfileCommandHandler : IRequestHandler<DeleteProfileCommand>
{
    private readonly IProfileRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteProfileCommandHandler(IProfileRepository userRepository, IUnitOfWork unitOfWork)
    {
        _repository = userRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(DeleteProfileCommand request, CancellationToken cancellationToken)
    {
        var user = await _repository.GetByIdAsync(request.ProfileId);

        if (user is null)
        {
            throw new ProfileNotFoundException(request.ProfileId);
        }

        _repository.Remove(user);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
