using System.ComponentModel.DataAnnotations;

namespace StoreManager.DTOs
{
    public class OrderItemDto
    {
        public int Id { get; set; }
        [Required]
        public int MenuItemId { get; set; }
        [Required]
        [Range(1, 100)]
        public int Quantity { get; set; }
    }
}