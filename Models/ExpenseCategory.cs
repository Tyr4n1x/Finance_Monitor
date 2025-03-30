using System.ComponentModel.DataAnnotations;

namespace Finance_Monitor.Models
{
    public class ExpenseCategory
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; } = string.Empty;

        [Required]
        public string Category { get; set; } = string.Empty;
    }
}