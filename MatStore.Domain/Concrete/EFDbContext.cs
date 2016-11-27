using MatStore.Domain.Entities;
using System.Data.Entity;

namespace MatStore.Domain.Concrete
{
    public class EFDbContext : DbContext { 
        public DbSet<Product> Products { get; set; }
    }
}
