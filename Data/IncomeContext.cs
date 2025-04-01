using Finance_Monitor.Models;
using Microsoft.EntityFrameworkCore;

namespace Finance_Monitor.Data
{
    public class IncomeContext : DbContext
    {
        public IncomeContext(DbContextOptions<IncomeContext> options) : base(options)
        {
        }

        public DbSet<Income> Incomes { get; set; } = default!;
        public DbSet<IncomeCategory> IncomeCategories { get; set; } = default!;
    }

}
