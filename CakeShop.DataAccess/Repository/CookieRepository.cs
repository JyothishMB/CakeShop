using System.Linq;
using CakeShop.DataAccess.Data;
using CakeShop.DataAccess.Repository.IRepository;
using CakeShop.Models;

namespace CakeShop.DataAccess.Repository
{
    public class CookieRepository : Repository<Cookie>, ICookieRepository
    {
        private readonly ApplicationDbContext _db;
        public CookieRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(Cookie cookie)
        {
            var objFromDb = _db.Cookies.FirstOrDefault(c => c.Id == cookie.Id);

            if(objFromDb!=null)
            {
                objFromDb.Name = cookie.Name;
            }
        }
    }
}