using CakeShop.Models;

namespace CakeShop.DataAccess.Repository.IRepository
{
    public interface IGiftPackRepository : IRepository<GiftPack>
    {
         void Update(GiftPack giftPack);
    }
}