using System.ComponentModel.DataAnnotations;

namespace StoreManager.DTOs
{
    public class TableDto
    {
        public int Id { get; set; }
        [Required]
        [Range(1, 100)]
        public int Number { get; set; } // number of the table
        [Required]
        [Range(0,2)]
        public string Status { get; set; } // 0: empty, 1: reserved, 2: occupied
    }
}
