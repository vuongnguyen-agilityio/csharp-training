using Arch.EntityFrameworkCore.UnitOfWork;

namespace Application.Data
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
