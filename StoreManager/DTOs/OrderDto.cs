using StoreManager.Model;
using System.ComponentModel.DataAnnotations;

namespace StoreManager.DTOs
{
    public class OrderDto
    {
        public int Id { get; set; }
        public int TableId { get; set; }
        public int StaffId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public string Status { get; set; }
        public List<OrderItemDto> OrderItems { get; set; }
    }
}