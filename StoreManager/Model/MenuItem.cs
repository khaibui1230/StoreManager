using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StoreManager.Model
{
    [Table("MenuItems")]
    public class MenuItem
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Price must be non-negative.")]
        public decimal Price { get; set; }

        [StringLength(50)]
        public string Category { get; set; }

        // Một MenuItem có thể xuất hiện trong nhiều OrderItem
        public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}