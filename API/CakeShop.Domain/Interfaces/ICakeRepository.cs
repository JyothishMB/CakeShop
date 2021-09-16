using System.Collections.Generic;
using CakeShop.Domain.Models;

namespace CakeShop.Domain.Interfaces
{
    public interface ICakeRepository
    {
         IEnumerable<Cake> GetCakes();
    }
}