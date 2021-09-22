using System.Threading.Tasks;
using CakeShop.Application.DTOs;

namespace CakeShop.Application.Interfaces
{
    public interface ICakeService
    {
        CakesListDto GetCakesList();
        CakeDto GetCakeInfoById(int id);
        Task<CakeDto> AddCake(CakeDto cakeDto);
        void DeleteCake(CakeDto cakeDto);
        void UpdateCake(CakeDto cakeDto);

    }

}