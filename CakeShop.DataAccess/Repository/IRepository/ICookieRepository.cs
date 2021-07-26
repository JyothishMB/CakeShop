using CakeShop.Models;

namespace CakeShop.DataAccess.Repository.IRepository
{
    public interface ICookieRepository : IRepository<Cookie>
    {
         void Update(Cookie cookie);
    }
}