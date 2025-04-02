using System.Globalization;

namespace Finance_Monitor.Services
{
    public class YearlyItem
    {
        public required string Month { get; set; }
        public decimal Amount { get; set; }
        public override string ToString()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            return $"{Month}: {Amount:C2}"; // Formats the amount as currency
        }
    }
}