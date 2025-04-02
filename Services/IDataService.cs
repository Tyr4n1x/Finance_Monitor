namespace Finance_Monitor.Services
{
    public interface IDataService
    {
        Task<ICollection<YearlyItem>> LoadCurrentYearExpenses(string userId);
        Task<ICollection<YearlyItem>> LoadCurrentYearIncomes(string userId);
        Task<MonthlyData> LoadCurrentMonthExpenses(string userId);
        Task<MonthlyData> LoadCurrentMonthIncomes(string userId);
    }
}
