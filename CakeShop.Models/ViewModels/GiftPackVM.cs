using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CakeShop.Models.ViewModels
{
    public class GiftPackVM
    {
        public GiftPack GiftPack { get; set; }
        public IEnumerable<SelectListItem> CakeList { get; set; }
        public IEnumerable<SelectListItem> CookieList { get; set; }
    }
}