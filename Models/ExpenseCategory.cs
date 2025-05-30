﻿using System.ComponentModel.DataAnnotations;

namespace Finance_Monitor.Models
{
    public class ExpenseCategory : ICategory
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; } = string.Empty;

        [Required]
        public string Category { get; set; } = string.Empty;

        [Required]
        [RegularExpression("^#(?:[0-9a-fA-F]{3}){1,2}$", ErrorMessage = "Invalid hex color format.")]
        public string ColorHex { get; set; } = "#006bb7"; // Default color
    }
}