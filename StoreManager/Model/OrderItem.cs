using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StoreManager.Model
{
    public class OrderItem
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; } // Liên kết với bảng Order
        public int MenuItemId { get; set; }
        public MenuItem MenuItem { get; set; } // Liên kết với bảng MenuItem
        public int Quantity { get; set; }
        public decimal Price { get; set; } // Giá tại thời điểm đặt hàng
    }
}