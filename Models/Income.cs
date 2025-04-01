using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Finance_Monitor.Models
{
    public class Income
    {

        [Required]
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; } = string.Empty;

        [Required]
        public string Description { get; set; } = string.Empty;

        [Required]
        public DateOnly Date { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Please enter an amount greater than {1}")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Amount { get; set; }

        [Required]
        public List<IncomeCategory> Categories { get; set; } = new List<IncomeCategory>();

    }
}


