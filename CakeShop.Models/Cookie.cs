using System.ComponentModel.DataAnnotations;

namespace CakeShop.Models
{
    public class Cookie
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Cookie Name")]
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}