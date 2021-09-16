using System.Collections.Generic;
using CakeShop.Domain.Models;

namespace CakeShop.Application.DTOs
{
    public class CakesListDto
    {
        public IEnumerable<Cake> Cakes { get; set; }
    }
}