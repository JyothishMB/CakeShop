using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CakeShop.DataAccess.Repository.IRepository;
using CakeShop.Models;
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

        public IActionResult Upsert(int? id)
        {
            Cake cake =  new Cake();
            if(id==null)
            {
                //Create 
                return View(cake);
            } 

            //Edit
            cake = _unitOfWork.Cake.Get(id.GetValueOrDefault());

            if(cake == null)
            {
                return NotFound();
            }
            return View(cake);
        }

        #region API CALL
        [HttpGet]
        public IActionResult GetAll()
        {
            var allCakes = _unitOfWork.Cake.GetAll();
            return Json(new { data = allCakes });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Cake cake)
        {
            if(ModelState.IsValid)
            {
                if(cake.Id == 0)
                {
                    _unitOfWork.Cake.Add(cake);
                }
                else
                {
                    _unitOfWork.Cake.Update(cake);
                }
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(cake);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var objFromDb = _unitOfWork.Cake.Get(id);

            if(objFromDb==null)
            {
                return Json(new { success=false, message="Error while deleting" });
            }
            _unitOfWork.Cake.Remove(objFromDb);
            _unitOfWork.Save();

            return Json(new { success=true, message="Delete Successful" });
        }
        #endregion
    }
}