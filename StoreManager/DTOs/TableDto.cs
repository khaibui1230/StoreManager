using System.ComponentModel.DataAnnotations;

namespace StoreManager.DTOs
{
    public class TableDto
    {
        public int Id { get; set; }
        [Required]
        [Range(1, 100)]
        public int Number { get; set; } // number of the table
        [Required(ErrorMessage = "Status is required")]
        [RegularExpression("Available|Occupied|Reserved", ErrorMessage = "Status must be Available, Occupied, or Reserved")]
        public string Status { get; set; }
    }
}
