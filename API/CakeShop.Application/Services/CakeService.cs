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

        public CakeDto GetCakeInfoById(int id)
        {
            var cake = _repository.GetCake(id);
            return new CakeDto()
            {
                Id = cake.Id,
                Name = cake.Name,
                Description = cake.Description,
                Price = cake.Price
            };
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