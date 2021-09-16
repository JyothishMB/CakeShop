using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CakeShop.DataAccess.Repository.IRepository;
using CakeShop.Models;
using CakeShop.Models.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CakeShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class GiftPackController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostEnvironment;
        public GiftPackController(IUnitOfWork unitOfWork,
            IWebHostEnvironment hostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _hostEnvironment = hostEnvironment;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Upsert(int? id)
        {
            GiftPackVM giftPackVm =  new GiftPackVM()
            {
                GiftPack = new GiftPack(),
                CakeList = _unitOfWork.Cake.GetAll().Select(i => new SelectListItem {
                    Text = i.Name,
                    Value = i.Id.ToString()
                }),
                CookieList = _unitOfWork.Cookie.GetAll().Select(i => new SelectListItem {
                    Text = i.Name,
                    Value = i.Id.ToString()
                })
            };

            if(id==null)
            {
                //Create 
                return View(giftPackVm);
            } 

            //Edit
            giftPackVm.GiftPack = _unitOfWork.GiftPack.Get(id.GetValueOrDefault());

            if(giftPackVm.GiftPack == null)
            {
                return NotFound();
            }
            return View(giftPackVm);
        }

        #region API CALL
        [HttpGet]
        public IActionResult GetAll()
        {
            var allPacks = _unitOfWork.GiftPack.GetAll(includeproperties:"Cake,Cookie");
            return Json(new { data = allPacks });
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(GiftPackVM giftPackVM)
        {
            if(ModelState.IsValid)
            {
                string webRootPath = _hostEnvironment.WebRootPath;
                var files = HttpContext.Request.Form.Files;
                if(files.Count>0)
                {
                    string filename = Guid.NewGuid().ToString();
                    var uploads = Path.Combine(webRootPath, @"images/GiftPacks");
                    var extensions = Path.GetExtension(files[0].FileName);

                    if(giftPackVM.GiftPack.ImageUrl != null)
                    {
                        var imagepath = Path.Combine(webRootPath, giftPackVM.GiftPack.ImageUrl.TrimStart('\\'));
                        if(System.IO.File.Exists(imagepath))
                        {
                            System.IO.File.Delete(imagepath);
                        }
                    }

                    using(var fileStreams = new FileStream(Path.Combine(uploads,filename+extensions), FileMode.Create))
                    {
                        files[0].CopyTo(fileStreams);
                    }

                    giftPackVM.GiftPack.ImageUrl = @"\images\GiftPacks\"+filename+extensions;
                }
                else
                {
                    //update when there is no change in image
                    if(giftPackVM.GiftPack.Id != 0)
                    {
                        GiftPack objFromDb = _unitOfWork.GiftPack.Get(giftPackVM.GiftPack.Id);
                        giftPackVM.GiftPack.ImageUrl = objFromDb.ImageUrl;
                    }
                }

                if(giftPackVM.GiftPack.Id == 0)
                {
                    _unitOfWork.GiftPack.Add(giftPackVM.GiftPack);
                }
                else
                {
                    _unitOfWork.GiftPack.Update(giftPackVM.GiftPack);
                }
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(giftPackVM);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var objFromDb = _unitOfWork.GiftPack.Get(id);

            if(objFromDb==null)
            {
                return Json(new { success=false, message="Error while deleting" });
            }

            string webRootPath = _hostEnvironment.WebRootPath;
            var imagepath = Path.Combine(webRootPath, objFromDb.ImageUrl.TrimStart('\\'));
            if(System.IO.File.Exists(imagepath))
            {
                System.IO.File.Delete(imagepath);
            }
            _unitOfWork.GiftPack.Remove(objFromDb);
            _unitOfWork.Save();

            return Json(new { success=true, message="Delete Successful" });
        }
        #endregion
    }
}