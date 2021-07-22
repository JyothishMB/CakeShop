using System.Linq;
using CakeShop.DataAccess.Data;
using CakeShop.DataAccess.Repository.IRepository;
using CakeShop.Models;

namespace CakeShop.DataAccess.Repository
{
    public class CakeRepository : Repository<Cake>, ICakeRepository
    {
        private readonly ApplicationDbContext _db;
        public CakeRepository(ApplicationDbContext db): base(db)
        {
            _db = db;
        }
        public void Update(Cake cake)
        {
            var objFromDb = _db.Cakes.FirstOrDefault(c => c.Id == cake.Id);

            if(objFromDb!=null)
            {
                objFromDb.Name = cake.Name;
                _db.SaveChanges();
            }
        }
    }
}