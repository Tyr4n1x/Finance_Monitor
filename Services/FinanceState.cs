namespace Finance_Monitor.Services
{
    public class FinanceState
    {
        public event Func<Task>? OnFinanceAdded;

        public async Task NotifyFinanceAdded()
        {
            if (OnFinanceAdded != null)
            {
                await OnFinanceAdded.Invoke();
            }
        }
    }
}
