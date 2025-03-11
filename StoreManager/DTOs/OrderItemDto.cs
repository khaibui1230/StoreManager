using System.ComponentModel.DataAnnotations;

namespace StoreManager.DTOs
{
    public class OrderItemDto
    {
        public int Id { get; set; }
        public int MenuItemId { get; set; }
        public string MenuItemName { get; set; } // Để hiển thị thông tin
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}