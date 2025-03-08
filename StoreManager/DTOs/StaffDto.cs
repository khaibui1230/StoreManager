using System.ComponentModel.DataAnnotations;

namespace StoreManager.DTOs
{
    public class StaffDto
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string FullName { get; set; } = string.Empty;
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Role { get; set; } = string.Empty; // ex: waiter, chef, manager
    }
}
