using CakeShop.Application.DTOs;
using CakeShop.Application.Interfaces;
using CakeShop.Domain.Interfaces;

namespace CakeShop.Application.Services
{
    public class CakeService : ICakeService
    {
        private readonly ICakeRepository _repository;
        public CakeService(ICakeRepository repository)
        {
            _repository = repository;
        }
        public CakesListDto GetCakesList()
        {
            return new CakesListDto()
            {
                Cakes = _repository.GetCakes()
            };
        }
    }
}