namespace Domain.Profiles
{
    public interface IProfileRepository
    {
        Task<Profile?> GetByIdAsync(ProfileId id);

        void Add(Profile profile);

        void Update(Profile profile);

        void Remove(Profile profile);
    }
}
