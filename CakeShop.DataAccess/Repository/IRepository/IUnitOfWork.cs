using System;

namespace CakeShop.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
         ICakeRepository Cake { get; }
         ISP_Call SP_Call { get; }
    }
}