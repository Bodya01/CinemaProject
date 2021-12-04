using System.ComponentModel.DataAnnotations;

namespace CinemaProject.Models.ModelViews
{
    public class RegisterViewModel
    {


        [Required]
        [Display(Name = "UserName")]
        public string UserName { get; set; }
        
        [Required]
        [Display(Name = "UserSurname")]
        public string Surname { get; set; }

        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Phone")]
        public string Phone { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        [DataType(DataType.Password)]
        [Display(Name = "Подтвердить пароль")]
        public string PasswordConfirm { get; set; }
    }
}
