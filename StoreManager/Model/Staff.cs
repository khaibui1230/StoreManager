using System.ComponentModel.DataAnnotations;

namespace StoreManager.Model
{
    public class Staff
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [Required]
        [RegularExpression("Admin|Waiter|Chef", ErrorMessage = "Role must be Admin, Waiter or Chef")]
        public string Role { get; set; } // Admin, Waiter, Chef

        public virtual List<Order> Orders { get; set; } = new List<Order>();
    }

}
