using CakeShop.Application.DTOs;

namespace CakeShop.Application.Interfaces
{
    public interface ICakeService
    {
        CakesListDto GetCakesList();
        CakeDto GetCakeInfoById(int id);
    }

}