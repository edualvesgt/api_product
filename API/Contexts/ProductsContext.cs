using API_Product.Domains;
using Microsoft.EntityFrameworkCore;

namespace API_Product.Contexts
{
    public class ProductsContext : DbContext
    {
        public ProductsContext(DbContextOptions<ProductsContext> options) : base(options)
        {
        }

        public DbSet<Products> Products { get; set; }
    }
}
