using System.Threading.Tasks;
using CakeShop.Application.DTOs;
using CakeShop.Application.Interfaces;
using CakeShop.Domain.Interfaces;
using CakeShop.Domain.Models;
using AutoMapper;

namespace CakeShop.Application.Services
{
    public class CakeService : ICakeService
    {
        private readonly ICakeRepository _repository;
        private readonly IMapper _mapper;
        public CakeService(ICakeRepository repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<CakeDto> AddCake(CakeDto cakeDto)
        {
            var caketoadd = _mapper.Map<Cake>(cakeDto);

            var result = await _repository.Add(caketoadd);

            var addedCake = _mapper.Map<CakeDto>(result);

            return addedCake;
        }

        public async Task DeleteCake(int id)
        {
            await _repository.Delete(id);
        }

        public async Task<CakeDto> GetCakeInfoById(int id)
        {
            var cake = await _repository.Get(id);
            return _mapper.Map<CakeDto>(cake);
        }

        public async Task<CakesListDto> GetCakesList()
        {
            return new CakesListDto()
            {
                Cakes = await _repository.GetAll()
            };
        }

        public async Task UpdateCake(CakeDto cakeDto)
        {
            await _repository.Update(_mapper.Map<Cake>(cakeDto));
        }
    }
}