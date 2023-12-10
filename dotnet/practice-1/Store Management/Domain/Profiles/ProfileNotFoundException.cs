using Domain.Users;

namespace Domain.Profiles;

public sealed class ProfileNotFoundException : Exception
{
    public ProfileNotFoundException(ProfileId id)
        : base($"The profile with the ID = {id.Value} was not found")
    {
    }
}

public sealed class ProfileByUserIdNotFoundException : Exception
{
    public ProfileByUserIdNotFoundException(UserId id)
        : base($"The profile with the User ID = {id.Value} was not found")
    {
    }
}
