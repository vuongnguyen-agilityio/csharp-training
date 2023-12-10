using Domain.Profiles;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories
{
    internal sealed class ProfileRepository : IProfileRepository
    {
        private readonly ApplicationDbContext _context;

        public ProfileRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<Profile?> GetByIdAsync(ProfileId id)
        {
            return _context.Profiles
                .SingleOrDefaultAsync(p => p.Id == id);
        }

        public Task<List<Profile>> ListAsync()
        {
            return _context.Profiles.ToListAsync();
        }

        public void Add(Profile profile)
        {
            _context.Profiles.Add(profile);
        }

        public void Update(Profile profile)
        {
            _context.Profiles.Update(profile);
        }

        public void Remove(Profile profile)
        {
            _context.Profiles.Remove(profile);
        }
    }
}
