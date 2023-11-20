using Domain.Products;
namespace Application.Data
{
    public interface IApplicationDBContext
    {
        DbSet<Product> Products { get; set; }
    }
}
