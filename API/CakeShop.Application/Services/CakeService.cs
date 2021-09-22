using System.Threading.Tasks;
using CakeShop.Application.DTOs;
using CakeShop.Application.Interfaces;
using CakeShop.Domain.Interfaces;
using CakeShop.Domain.Models;

namespace CakeShop.Application.Services
{
    public class CakeService : ICakeService
    {
        private readonly ICakeRepository _repository;
        public CakeService(ICakeRepository repository)
        {
            _repository = repository;
        }

        public async Task<CakeDto> AddCake(CakeDto cakeDto)
        {
            var result = await _repository.AddAsync(new Cake(){ 
                Name = cakeDto.Name,
                Description = cakeDto.Description,
                Price = cakeDto.Price
             });

             var cakecreated = new CakeDto(){
                 Name = result.Name,
                 Description = result.Description,
                 Price = result.Price,
                 Id = result.Id
             };

            return cakecreated;
        }

        public void DeleteCake(CakeDto cakeDto)
        {
            _repository.Delete(new Cake(){ 
                Name = cakeDto.Name,
                Description = cakeDto.Description,
                Price = cakeDto.Price
             });
        }

        public CakeDto GetCakeInfoById(int id)
        {
            var cake = _repository.Get(id);
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
                Cakes = _repository.GetAll()
            };
        }

        public void UpdateCake(CakeDto cakeDto)
        {
            _repository.Update(new Cake(){ 
                Name = cakeDto.Name,
                Description = cakeDto.Description,
                Price = cakeDto.Price
             });
        }
    }
}