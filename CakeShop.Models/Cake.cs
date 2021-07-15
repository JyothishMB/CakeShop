using System.ComponentModel.DataAnnotations;

namespace CakeShop.Models
{
    public class Cake
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Cake Name")]
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

    }
}