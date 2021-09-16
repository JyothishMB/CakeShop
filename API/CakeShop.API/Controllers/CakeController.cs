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
        public IActionResult Get()
        {
            return Ok(_cakeService.GetCakesList());
        }
    }
}
