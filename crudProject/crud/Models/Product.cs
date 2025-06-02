using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace crud.Models
{
    public class Product
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string? Brand { get; set; }
        [MaxLength(100)]
        public string? Category { get; set; }
        [MaxLength(100)]
        public string? Name { get; set; }
        [MaxLength(500)]
        public string? Description { get; set; }
        [Precision(16, 2)]
        public decimal Price { get; set; }
        public string? ImageUrl { get; set; }

        public DateTime CreatedAt { get; set; }
        // Additional properties can be added as needed
    }
}
