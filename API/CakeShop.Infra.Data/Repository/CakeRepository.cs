using System.Collections.Generic;
using System.Threading.Tasks;
using CakeShop.Domain.Interfaces;
using CakeShop.Domain.Models;
using CakeShop.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CakeShop.Infra.Data.Repository
{
    public class CakeRepository : ICakeRepository
    {
        private readonly CakeShopDbContext _context;
        public CakeRepository(CakeShopDbContext context)
        {
            _context = context;
        }

        public async Task<Cake> Add(Cake cake)
        {
            _context.Cakes.Add(cake);
            await _context.SaveChangesAsync();

            return cake;
        }

        public async Task Delete(int id)
        {
            var caketodelete = await _context.Cakes.FindAsync(id);
            _context.Cakes.Remove(caketodelete);
            await _context.SaveChangesAsync();
        }

        public async Task<Cake> Get(int id)
        {
            var cake = await _context.Cakes.FindAsync(id);
            return cake;
        }

        public async Task<IEnumerable<Cake>> GetAll()
        {
            var cakes = await _context.Cakes.ToListAsync();
            return cakes;
        }

        public async Task Update(Cake cake)
        {
            var obj = await _context.Cakes.FindAsync(cake.Id);

            if(obj!=null)
            {
                obj.Name = cake.Name;
                obj.Description = cake.Description;
                obj.Price = cake.Price;
            }

            await _context.SaveChangesAsync();
        }
    }
}