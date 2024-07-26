using System.ComponentModel.DataAnnotations;

namespace Agency.Models
{
    public class ModelUserForSignUp
    {
        [Display(Name = "Имя")]
        [Required(ErrorMessage = "Введите Имя")]
        public string Surname { get; set; } = String.Empty;

        [Required(ErrorMessage = "Введите Email")]
        [EmailAddress(ErrorMessage = "Неверный формат Email")]
        public string Email { get; set; } = String.Empty;
        [Required(AllowEmptyStrings = true)]
        [Display(Name = "Номер телефона")]
        public string Phone { get; set; } = String.Empty;

        [Required(ErrorMessage = "Введите пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = String.Empty;

        [Required(ErrorMessage = "Подтвердите пароль")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        public string ConfirmPassword { get; set; } = String.Empty;
    }
}
