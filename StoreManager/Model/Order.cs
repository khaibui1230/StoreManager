using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace StoreManager.Model
{
    [Table("Orders")]
    public class Order
    {
        public int Id { get; set; }
        public int TableId { get; set; }
        public Table Table { get; set; } // Liên kết với bảng Table
        public int StaffId { get; set; }
        public Staff Staff { get; set; } // Liên kết với bảng Staff

        public int CustomerId { get; set; }
        public Customer Customer { get; set; } // lieen ket voi bang Customer
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public string Status { get; set; } // Ví dụ: "Pending", "Completed", "Cancelled"
        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}
