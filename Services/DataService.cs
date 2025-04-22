using Finance_Monitor.Components.Administration;
using Finance_Monitor.Data;
using Finance_Monitor.Models;
using Microsoft.EntityFrameworkCore;

namespace Finance_Monitor.Services
{
    public class DataService(IDbContextFactory<ExpenseContext> ExpenseDbFactory,
                       IDbContextFactory<IncomeContext> IncomeDbFactory) : IDataService
    {

        private readonly IDbContextFactory<ExpenseContext> expenseDbFactory = ExpenseDbFactory ?? throw new ArgumentNullException(nameof(ExpenseDbFactory));
        private readonly IDbContextFactory<IncomeContext> incomeDbFactory = IncomeDbFactory ?? throw new ArgumentNullException(nameof(IncomeDbFactory));
        private readonly int currentYear = DateTime.Today.Year;
        private readonly int currentMonth = DateTime.Today.Month;

        public async Task<ICollection<YearlyItem>> LoadYearExpenses(int year, string userId)
        {
            using var context = expenseDbFactory.CreateDbContext();

            // Load all expenses for the given year, grouped by month
            // Only load expenses for the current user
            // Store this in a dictionary with month number as key and total amount as value
            var yearExpenses = await context.Expenses
                .Where(expense => expense.Date.Year == year && expense.UserId == userId)
                .GroupBy(expense => expense.Date.Month)
                .ToDictionaryAsync(group => group.Key, group => group.Sum(expense => expense.Amount));

            // Initialize dictionary with all months (1 to 12), defaulting to an amount of 0 if missing
            var yearExpensesAllMonths = Enumerable.Range(1, 12)
                .ToDictionary(
                    month => month,
                    month => yearExpenses.ContainsKey(month) ? yearExpenses[month] : 0
                );

            // Convert dictionary to list of YearlyItem objects
            var yearlyItems = yearExpensesAllMonths
                .Select(kvp => new YearlyItem
                {
                    Month = MonthToString(kvp.Key, year),
                    Amount = kvp.Value
                })
                .ToList();

            return yearlyItems;
        }

        public async Task<MonthlyData> LoadMonthExpenses(int year, int month, string userId)
        {
            using var context = expenseDbFactory.CreateDbContext();

            var monthExpenses = await context.Expenses
                .Where(expense => expense.Date >= new DateOnly(year, month, 1) &&
                                  expense.Date <= new DateOnly(year, month, DateTime.DaysInMonth(year, month)) &&
                                  expense.UserId == userId)
                // Flatten the Categories list so each category gets its own expense entry
                .SelectMany(expense => expense.Categories, (expense, category) => new { category, expense.Amount })
                .GroupBy(item => item.category)
                .Select(group => new MonthlyItem
                {
                    Amount = group.Sum(item => item.Amount),
                    Category = group.Key
                })
                .ToListAsync();

            var monthData = new MonthlyData
            {
                Data = monthExpenses,
                Label = MonthToString(month, year)
            };
            return monthData;
        }

        public async Task<ICollection<YearlyItem>> LoadCurrentYearExpenses(string userId)
        {
            var yearlyItems = await LoadYearExpenses(currentYear, userId);

            // Trim the list to only include months up to the current month
            var filteredYearExpenses = yearlyItems
                .Where(expense => DateTime.Parse(expense.Month).Month <= currentMonth)
                .ToList();

            return filteredYearExpenses;
        }


        public async Task<MonthlyData> LoadCurrentMonthExpenses(string userId)
        {
            return await LoadMonthExpenses(currentYear, currentMonth, userId);
        }

        public async Task<ICollection<YearlyItem>> LoadYearIncomes(int year, string userId)
        {
            using var context = incomeDbFactory.CreateDbContext();

            // Load all incomes for the given year, grouped by month
            // Only load incomes for the current user
            // Store this in a dictionary with month number as key and total amount as value
            var yearIncomes = await context.Incomes
                .Where(income => income.Date.Year == year && income.UserId == userId)
                .GroupBy(income => income.Date.Month)
                .ToDictionaryAsync(group => group.Key, group => group.Sum(income => income.Amount));

            // Initialize dictionary with all months (1 to 12), defaulting to an amount of 0 if missing
            var yearIncomesAllMonths = Enumerable.Range(1, 12)
                .ToDictionary(
                    month => month,
                    month => yearIncomes.ContainsKey(month) ? yearIncomes[month] : 0
                );

            // Convert dictionary to list of YearlyItem objects
            var yearlyItems = yearIncomesAllMonths
                .Select(kvp => new YearlyItem
                {
                    Month = MonthToString(kvp.Key, year),
                    Amount = kvp.Value
                })
                .ToList();

            return yearlyItems;
        }

        public async Task<MonthlyData> LoadMonthIncomes(int year, int month, string userId)
        {
            using var context = incomeDbFactory.CreateDbContext();

            var monthIncomes = await context.Incomes
                .Where(income => income.Date >= new DateOnly(year, month, 1) &&
                                  income.Date <= new DateOnly(year, month, DateTime.DaysInMonth(year, month)) &&
                                  income.UserId == userId)
                // Flatten the Categories list so each category gets its own income entry
                .SelectMany(income => income.Categories, (income, category) => new { category, income.Amount })
                .GroupBy(item => item.category)
                .Select(group => new MonthlyItem
                {
                    Amount = group.Sum(item => item.Amount),
                    Category = group.Key
                })
                .ToListAsync();

            var monthData = new MonthlyData
            {
                Data = monthIncomes,
                Label = MonthToString(month, year)
            };

            return monthData;
        }

        public async Task<ICollection<YearlyItem>> LoadCurrentYearIncomes(string userId)
        {
            var yearlyItems = await LoadYearIncomes(currentYear, userId);

            // Trim the list to only include months up to the current month
            var filteredYearIncomes = yearlyItems
                .Where(income => DateTime.Parse(income.Month).Month <= currentMonth)
                .ToList();

            return filteredYearIncomes;
        }

        public async Task<MonthlyData> LoadCurrentMonthIncomes(string userId)
        {
            return await LoadMonthIncomes(currentYear, currentMonth, userId);
        }

        public async Task<List<ICategory>> GetExpenseCategories(string userId)
        {
            using var context = expenseDbFactory.CreateDbContext();

            var categories = await context.ExpenseCategories
                .Where(c => c.UserId == userId)
                .ToListAsync<ICategory>();

            return categories;
        }

        public async Task<List<ICategory>> GetIncomeCategories(string userId)
        {
            using var context = incomeDbFactory.CreateDbContext();

            var categories = await context.IncomeCategories
                .Where(c => c.UserId == userId)
                .ToListAsync<ICategory>();

            return categories;
        }


        private static string MonthToString(int month, int year)
        {
            return month switch
            {
                1 => $"January {year}",
                2 => $"February {year}",
                3 => $"March {year}",
                4 => $"April {year}",
                5 => $"May {year}",
                6 => $"June {year}",
                7 => $"July {year}",
                8 => $"August {year}",
                9 => $"September {year}",
                10 => $"October {year}",
                11 => $"November {year}",
                12 => $"December {year}",
                _ => throw new NotImplementedException(),
            };
        }

    }
}
