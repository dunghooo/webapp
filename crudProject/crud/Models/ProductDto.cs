using System.ComponentModel.DataAnnotations;

namespace crud.Models
{
    public class ProductDto
    {
        public string? Brand { get; set; }
        [Required,MaxLength(100)]
        public string? Category { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required, MaxLength(500)]
        public string? Description { get; set; }
        [Required]
        public decimal Price { get; set; }
        public IFormFile? ImageUrl { get; set; }
    }
}
