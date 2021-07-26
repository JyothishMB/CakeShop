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
    public class CookieController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public CookieController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Upsert(int? id)
        {
            Cookie cookie =  new Cookie();
            if(id==null)
            {
                //Create 
                return View(cookie);
            } 

            //Edit
            cookie = _unitOfWork.Cookie.Get(id.GetValueOrDefault());

            if(cookie == null)
            {
                return NotFound();
            }
            return View(cookie);
        }

        #region API CALL
        [HttpGet]
        public IActionResult GetAll()
        {
            var allCookies = _unitOfWork.Cookie.GetAll();
            return Json(new { data = allCookies });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Cookie cookie)
        {
            if(ModelState.IsValid)
            {
                if(cookie.Id == 0)
                {
                    _unitOfWork.Cookie.Add(cookie);
                }
                else
                {
                    _unitOfWork.Cookie.Update(cookie);
                }
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(cookie);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var objFromDb = _unitOfWork.Cookie.Get(id);

            if(objFromDb==null)
            {
                return Json(new { success=false, message="Error while deleting" });
            }
            _unitOfWork.Cookie.Remove(objFromDb);
            _unitOfWork.Save();

            return Json(new { success=true, message="Delete Successful" });
        }
        #endregion
    }
}