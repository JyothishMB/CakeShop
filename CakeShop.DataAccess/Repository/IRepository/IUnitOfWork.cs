using System;

namespace CakeShop.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        ICakeRepository Cake { get; }
        ICookieRepository Cookie { get; }
        IGiftPackRepository GiftPack { get; }
        ISP_Call SP_Call { get; }
        void Save();
    }
}