using System.ComponentModel.DataAnnotations;

namespace StoreManager.DTOs
{
    public class MenuItemDto
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Name { get; set; } = string.Empty;
        [Required]
        [Range(1, 100000)]
        public decimal Price { get; set; }
        [Required]
        [StringLength(50)]
        public string Category { get; set; } = string.Empty;
    }
}
