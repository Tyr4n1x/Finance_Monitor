namespace Finance_Monitor.Services
{
    public class MonthlyData
    {
        public ICollection<MonthlyItem> Data { get; set; } = new List<MonthlyItem>();
        public string Label { get; set; } = string.Empty;
    }
}