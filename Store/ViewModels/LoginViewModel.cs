using System.ComponentModel.DataAnnotations;

namespace Store.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Поле 'Электронная почта' обязательно для заполнения.")]
        [EmailAddress(ErrorMessage = "Неверный формат электронной почты.")]
        [Display(Name = "Электронная почта")]
        public required string Email { get; set; }

        [Required(ErrorMessage = "Поле 'Пароль' обязательно для заполнения.")]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public required string Password { get; set; }

        [Display(Name = "Запомнить меня")]
        public bool RememberMe { get; set; }
    }

    public class SendCodeViewModel
    {
        public bool RememberMe { get; set; }
    }
}