using System.ComponentModel.DataAnnotations;

namespace MovieDatabaseBlazorServerApp.Views
{
    public class EditableUser
    {
        public string Id { get; set; }
        public bool Admin { get; set; }
        public bool Staff { get; set; }
        public bool Premium { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }

        public string? Password { get; set; }

        [Display(Name = "Confirm Password")]
        public string? PasswordConfirmation { get; set; }

        public bool Enabled { get; set; }
    }
}
