using Finance_Monitor.Models;

namespace Finance_Monitor.Services
{
    public interface IDataService
    {
        Task<ICollection<YearlyItem>> LoadCurrentYearExpenses(string userId);
        Task<ICollection<YearlyItem>> LoadCurrentYearIncomes(string userId);
        Task<MonthlyData> LoadCurrentMonthExpenses(string userId);
        Task<MonthlyData> LoadCurrentMonthIncomes(string userId);
        Task<List<ICategory>> GetExpenseCategories(string userId);
        Task<List<ICategory>> GetIncomeCategories(string userId);
    }
}
