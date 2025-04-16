namespace Finance_Monitor.Models
{
    public interface ICategory
    {
        int Id { get; set; }

        string UserId { get; set; }

        string Category { get; set; }

        string ColorHex { get; set; }

    }
}
