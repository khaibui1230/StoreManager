using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StoreManager.Model
{
    [Table("Tables")]
    public class Table
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Table number must be at least 1.")]
        public int Number { get; set; }

        [Required(ErrorMessage = "Status is required")]
        [RegularExpression("Available|Occupied|Reserved", ErrorMessage = "Status must be Available, Occupied, or Reserved")]
        public string Status { get; set; }

        // Một bàn có thể liên kết với nhiều đơn hàng (tùy chọn)
        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
    }
    
}