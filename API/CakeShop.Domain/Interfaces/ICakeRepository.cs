using System.Collections.Generic;
using System.Threading.Tasks;
using CakeShop.Domain.Models;

namespace CakeShop.Domain.Interfaces
{
    public interface ICakeRepository
    {
        Task<IEnumerable<Cake>> GetAll();
        Task<Cake> Get(int id);
        Task<Cake> Add(Cake cake);
        Task Delete(int id);
        Task Update(Cake cake);
    }
}