using CakeShop.Models;

namespace CakeShop.DataAccess.Repository.IRepository
{
    public interface ICakeRepository : IRepository<Cake>
    {
         void Update(Cake cake);
    }
}