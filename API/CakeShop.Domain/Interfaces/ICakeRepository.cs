using System.Collections.Generic;
using System.Threading.Tasks;
using CakeShop.Domain.Models;

namespace CakeShop.Domain.Interfaces
{
    public interface ICakeRepository
    {
        IEnumerable<Cake> GetAll();
        Cake Get(int id);
        Task<Cake> AddAsync(Cake cake);
        void Delete(Cake cake);
        void Update(Cake cake);
    }
}