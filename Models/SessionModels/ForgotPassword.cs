using System.ComponentModel.DataAnnotations;

namespace CinemaProject.Models.SessionModels
{
    public class ForgotPassword
    {
        [Required, EmailAddress, Display(Name = "Registered email address")]
        public string Email { get; set; }

        public bool EmailSent { get; set; }
    }
}
