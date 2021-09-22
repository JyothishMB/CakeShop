using System.Threading.Tasks;
using CakeShop.Application.DTOs;

namespace CakeShop.Application.Interfaces
{
    public interface ICakeService
    {
        Task<CakesListDto> GetCakesList();
        Task<CakeDto> GetCakeInfoById(int id);
        Task<CakeDto> AddCake(CakeDto cakeDto);
        Task DeleteCake(int id);
        Task UpdateCake(CakeDto cakeDto);

    }

}