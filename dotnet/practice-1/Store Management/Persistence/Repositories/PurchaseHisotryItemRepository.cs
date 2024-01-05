using Microsoft.EntityFrameworkCore;
using Domain.PurchaseHistoryItems;

namespace Persistence.Repositories
{
    internal sealed class PurchaseHistoryItemRepository : IPurchaseHistoryItemRepository
    {
        private readonly ApplicationDbContext _context;

        public PurchaseHistoryItemRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<PurchaseHistoryItem?> GetByIdAsync(PurchaseHistoryItemId purchaseHistoryItemId)
        {
            return _context.PurchaseHistoryItems
                .SingleOrDefaultAsync(c => c.Id == new PurchaseHistoryItemId(purchaseHistoryItemId.Value));
        }

        public Task<List<PurchaseHistoryItem>> ListAsync()
        {
            return _context.PurchaseHistoryItems.ToListAsync();
        }

        public void Add(PurchaseHistoryItem item)
        {
            _context.PurchaseHistoryItems.Add(item);
        }

        public void Update(PurchaseHistoryItem item)
        {
            _context.PurchaseHistoryItems.Update(item);
        }

        public void Remove(PurchaseHistoryItem item)
        {
            _context.PurchaseHistoryItems.Remove(item);
        }
    }
}
