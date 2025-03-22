using Microsoft.AspNetCore.Identity;

namespace Finance_Monitor.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; } = string.Empty;
    }
}
