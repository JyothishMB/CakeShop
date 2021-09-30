using CakeShop.Domain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CakeShop.Infra.Data.Context
{
    public class CakeShopDbContext : IdentityDbContext
    {
        public CakeShopDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Cake> Cakes { get; set; }
        
    }
}