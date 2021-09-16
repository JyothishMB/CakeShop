using CakeShop.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CakeShop.Infra.Data.Context
{
    public class CakeShopDbContext : DbContext
    {
        public CakeShopDbContext(DbContextOptions<CakeShopDbContext> options)
            :base(options)
        {

        }

        public DbSet<Cake> Cakes { get; set; }
        
    }
}