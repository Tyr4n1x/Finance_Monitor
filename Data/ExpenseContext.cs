using Finance_Monitor.Models;
using Microsoft.EntityFrameworkCore;

namespace Finance_Monitor.Data
{
    public class ExpenseContext : DbContext
    {
        public ExpenseContext(DbContextOptions<ExpenseContext> options) : base(options)
        {
        }

        public DbSet<Expense> Expenses { get; set; } = default!;
        public DbSet<ExpenseCategory> ExpenseCategories { get; set; } = default!;
    }
   
}
