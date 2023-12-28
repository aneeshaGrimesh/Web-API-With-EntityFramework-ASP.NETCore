using Microsoft.EntityFrameworkCore;
using Product.Models;

namespace Product.DAL
{
    public class ProducrDBContext :DbContext
    {
        public ProducrDBContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Products> Products { get; set; }
    }
}
