using System.Collections.Generic;
using CakeShop.Domain.Interfaces;
using CakeShop.Domain.Models;
using CakeShop.Infra.Data.Context;

namespace CakeShop.Infra.Data.Repository
{
    public class CakeRepository : ICakeRepository
    {
        private readonly CakeShopDbContext _context;
        public CakeRepository(CakeShopDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Cake> GetCakes()
        {
            return _context.Cakes;
        }
    }
}