using Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories
{
    internal sealed class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<User?> GetByIdAsync(UserId id)
        {
            return _context.Users
                .SingleOrDefaultAsync(p => p.Id == id);
        }

        public Task<List<User>> ListAsync()
        {
            return _context.Users.ToListAsync();
        }

        public void Add(User user)
        {
            _context.Users.Add(user);
        }

        public void Update(User user)
        {
            _context.Users.Update(user);
        }

        public void Remove(User user)
        {
            _context.Users.Remove(user);
        }
    }
}
