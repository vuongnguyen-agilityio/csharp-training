using Microsoft.EntityFrameworkCore;
using Domain.PurchaseHistoryItems;

namespace Persistence.Repositories
{
    internal sealed class PurchaseHistoryItemRepository : IPurchaseHistoryItemRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly OtherApplicationDbContext _otherContext;

        public PurchaseHistoryItemRepository(ApplicationDbContext context, OtherApplicationDbContext otherContext)
        {
            _context = context;
            _otherContext = otherContext;
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
            _otherContext.PurchaseHistoryItems.Add(item);
        }

        public void Update(PurchaseHistoryItem item)
        {
            _context.PurchaseHistoryItems.Update(item);
            _otherContext.PurchaseHistoryItems.Update(item);
        }

        public void Remove(PurchaseHistoryItem item)
        {
            _context.PurchaseHistoryItems.Remove(item);
            _otherContext.PurchaseHistoryItems.Remove(item);
        }
    }
}
