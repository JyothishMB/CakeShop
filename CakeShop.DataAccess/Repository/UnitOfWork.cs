using CakeShop.DataAccess.Data;
using CakeShop.DataAccess.Repository.IRepository;

namespace CakeShop.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Cake = new CakeRepository(_db);
            SP_Call = new SP_Call(_db);
        }
        public ICakeRepository Cake { get; private set; }

        public ISP_Call SP_Call { get; private set; }

        public void Dispose()
        {
            _db.Dispose();
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}