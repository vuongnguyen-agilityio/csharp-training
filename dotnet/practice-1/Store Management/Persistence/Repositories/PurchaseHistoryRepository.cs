using Domain.PurchaseHistories;
using Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories
{
    internal sealed class PurchaseHistoryRepository : IPurchaseHistoryRepository
    {
        private readonly ApplicationDbContext _context;

        public PurchaseHistoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<PurchaseHistory?> GetByIdAsync(UserId userId, PurchaseHistoryId purchaseHistoryId)
        {
            return _context.PurchaseHistories
                .SingleOrDefaultAsync(c => c.Id == new PurchaseHistoryId(purchaseHistoryId.Value) && c.UserId == userId);
        }

        public Task<List<PurchaseHistory>> ListAsync()
        {
            return _context.PurchaseHistories.ToListAsync();
        }

        public void Add(PurchaseHistory purchaseHistory)
        {
            _context.PurchaseHistories.Add(purchaseHistory);
        }

        public void Update(PurchaseHistory purchaseHistory)
        {
            _context.PurchaseHistories.Update(purchaseHistory);
        }

        public void Remove(PurchaseHistory purchaseHistory)
        {
            _context.PurchaseHistories.Remove(purchaseHistory);
        }
    }
}
