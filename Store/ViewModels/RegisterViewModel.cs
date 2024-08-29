using System.ComponentModel.DataAnnotations;

namespace Store.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Поле 'Имя' обязательно для заполнения.")]
        [Display(Name = "Имя")]
        public required string FirstName { get; set; }

        [Required(ErrorMessage = "Поле 'Фамилия' обязательно для заполнения.")]
        [Display(Name = "Фамилия")]
        public required string LastName { get; set; }

        [Required(ErrorMessage = "Поле 'Электронная почта' обязательно для заполнения.")]
        [EmailAddress(ErrorMessage = "Неверный формат электронной почты.")]
        [Display(Name = "Электронная почта")]
        public required string Email { get; set; }

        [Required(ErrorMessage = "Поле 'Пароль' обязательно для заполнения.")]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public required string Password { get; set; }

        [Required(ErrorMessage = "Поле 'Подтверждение пароля' обязательно для заполнения.")]
        [DataType(DataType.Password)]
        [Display(Name = "Подтверждение пароля")]
        [Compare("Password", ErrorMessage = "Пароли не совпадают.")]
        public required string ConfirmPassword { get; set; }
    }

    
}
