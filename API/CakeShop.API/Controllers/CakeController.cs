using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CakeShop.Application.DTOs;
using CakeShop.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CakeShop.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
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

        [HttpGet("GetCakes")]
        [AllowAnonymous]
        public async Task<IActionResult> GetCakes()
        {
            return Ok(await _cakeService.GetCakesList());
        }

        [HttpGet("{id}", Name="GetCake")]
        [AllowAnonymous]
        public async Task<IActionResult> GetCake(int id)
        {
            var caketoreturn = await _cakeService.GetCakeInfoById(id);
            if(caketoreturn==null)
                return NotFound();
            
            return Ok(caketoreturn);
        }

        [HttpPost("AddCake")]
        public async Task<IActionResult> AddCake(CakeDto cakeDto)
        {
            var result = await _cakeService.AddCake(cakeDto);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCake(int id)
        {
            await _cakeService.DeleteCake(id);
            return Ok(new { message = "Cake deleted" });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, CakeDto cakeDto)
        {
            var caketoupdate = await _cakeService.GetCakeInfoById(id);
            if(caketoupdate==null)
                return NotFound();
            cakeDto.Id = id;
            await _cakeService.UpdateCake(cakeDto);
            return Ok(new { message = "Cake updated" });
        }
    }
}
