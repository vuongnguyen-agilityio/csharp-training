using Application.Data;
using Domain.Profiles;
using Domain.Users;
using MediatR;

namespace Application.Profiles.Update;

internal sealed class UpdateProfileCommandHandler : IRequestHandler<UpdateProfileCommand>
{
    private readonly IProfileRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateProfileCommandHandler(IProfileRepository profileRepository, IUnitOfWork unitOfWork)
    {
        _repository = profileRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(UpdateProfileCommand request, CancellationToken cancellationToken)
    {
        var profile = await _repository.GetByIdAsync(request.ProfileId);

        if (profile is null)
        {
            throw new ProfileNotFoundException(request.ProfileId);
        }

        profile.Update(
            request.FirstName,
            request.LastName,
            request.Age);

        _repository.Update(profile);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
