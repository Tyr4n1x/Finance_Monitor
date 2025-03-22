using Microsoft.AspNetCore.Identity;

namespace Finance_Monitor.Models
{
    public class ApplicationUser : IdentityUser
    {
        /// <summary>
        /// Gets or sets the name for this user.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the first name for this user.
        /// </summary>
        public string FirstName { get; set; } = string.Empty;
    }
}
