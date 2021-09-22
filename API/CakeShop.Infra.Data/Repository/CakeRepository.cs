using System.Collections.Generic;
using System.Threading.Tasks;
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

        public async Task<Cake> AddAsync(Cake cake)
        {
            await _context.Cakes.AddAsync(cake);
            await _context.SaveChangesAsync();

            return cake;
        }

        public void Delete(Cake cake)
        {
            _context.Cakes.Remove(cake);
            _context.SaveChanges();
        }

        public Cake Get(int id)
        {
            return _context.Cakes.Find(id);
        }

        public IEnumerable<Cake> GetAll()
        {
            return _context.Cakes;
        }

        public void Update(Cake cake)
        {
            var obj = _context.Cakes.Find(cake.Id);

            if(obj!=null)
            {
                obj.Name = cake.Name;
                obj.Description = cake.Description;
                obj.Price = cake.Price;
            }

            _context.SaveChanges();
        }
    }
}