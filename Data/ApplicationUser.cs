using Microsoft.AspNetCore.Identity;

namespace MovieDatabaseBlazorServerApp.Data
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public string? Firstname { get; set; }
        public string? Lastname { get; set;}
        public bool Enabled { get; set; }
    }

}
