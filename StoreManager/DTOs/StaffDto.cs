using System.ComponentModel.DataAnnotations;

namespace StoreManager.DTOs
{
    public class StaffDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(100, ErrorMessage = "Name cannot exceed 100 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Role is required")]
        [RegularExpression("Admin|Waiter|Chef", ErrorMessage = "Role must be Admin, Waiter, or Chef")]
        public string Role { get; set; }
    }
}
