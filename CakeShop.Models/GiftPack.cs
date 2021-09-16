using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CakeShop.Models
{
    public class GiftPack
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public double price { get; set; }
        
        public string ImageUrl { get; set; }
        
        [Required]
        public int CakeId { get; set; }
        
        [ForeignKey("CakeId")]
        public Cake Cake { get; set; }

        [Required]
        public int CookieId { get; set; }

        [ForeignKey("CookieId")]
        public Cookie Cookie { get; set; }

    }
}