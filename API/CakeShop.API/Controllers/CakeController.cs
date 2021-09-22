using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CakeShop.Application.DTOs;
using CakeShop.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CakeShop.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CakeController : ControllerBase
    {
        private readonly ILogger<CakeController> _logger;
        private readonly ICakeService _cakeService;

        public CakeController(ICakeService cakeService
            , ILogger<CakeController> logger)
        {
            _cakeService = cakeService;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetCakes()
        {
            return Ok(_cakeService.GetCakesList());
        }

        [HttpGet("{id}", Name="GetCake")]
        public IActionResult GetCake(int id)
        {
            return Ok(_cakeService.GetCakeInfoById(id));
        }

        [HttpPost]
        public async Task<IActionResult> AddCake(CakeDto cakeDto)
        {
            var result = await _cakeService.AddCake(cakeDto);

            return Ok(result);
        }

        
    }
}
