using System.ComponentModel.DataAnnotations;

namespace StoreManager.DTOs
{
    public class OrderDto
    {
        public int Id { get; set; }
        [Required]
        public DateTime OrderDate { get; set; }
        [Required]
        public int TableId { get; set; }
        [Required]
        public List<OrderItemDto> OrderItems { get; set; } = new List<OrderItemDto>();

        [Required]
        [Range(0,1)] // check if the value is 0 or 1
        public int Status { get; set; }
    }
}
