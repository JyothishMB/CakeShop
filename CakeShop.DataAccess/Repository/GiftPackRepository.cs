using System.Linq;
using CakeShop.DataAccess.Data;
using CakeShop.DataAccess.Repository.IRepository;
using CakeShop.Models;

namespace CakeShop.DataAccess.Repository
{
    public class GiftPackRepository : Repository<GiftPack>, IGiftPackRepository
    {
        private readonly ApplicationDbContext _db;
        public GiftPackRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(GiftPack giftPack)
        {
            var objFromDb = _db.GiftPacks.FirstOrDefault(c => c.Id == giftPack.Id);

            if(objFromDb!=null)
            {
                objFromDb.Title = giftPack.Title;
                objFromDb.Description = giftPack.Description;
                objFromDb.price = giftPack.price;

                if(giftPack.ImageUrl!=null)
                    objFromDb.ImageUrl = giftPack.ImageUrl;

                objFromDb.CakeId = giftPack.CakeId;
                objFromDb.CookieId = giftPack.CookieId;
            }
        }
    }
}