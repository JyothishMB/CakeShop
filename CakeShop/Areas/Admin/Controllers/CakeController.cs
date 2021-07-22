using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CakeShop.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace CakeShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CakeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public CakeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            return View();
        }

        #region API CALL
        [HttpGet]
        public IActionResult GetAll()
        {
            var allCakes = _unitOfWork.Cake.GetAll();
            return Json(new { data = allCakes });
        }
        #endregion
    }
}