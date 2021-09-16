using System.ComponentModel.DataAnnotations;

namespace CakeShop.Domain.Models
{
    public class Cake
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(500)]
        public string Description { get; set; }

        [Required]
        public double Price { get; set; }

    }
}