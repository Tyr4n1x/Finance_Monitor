namespace Finance_Monitor.Services
{
    public class FinanceState
    {
        public event Func<Task>? OnFinanceAdded;
        public event Func<Task>? OnCategoryAdded;

        public async Task NotifyFinanceAdded()
        {
            if (OnFinanceAdded != null)
            {
                await OnFinanceAdded.Invoke();
            }
        }

        public async Task NotifyCategoryAdded()
        {
            if (OnCategoryAdded != null)
            {
                await OnCategoryAdded.Invoke();
            }
        }
    }
}
