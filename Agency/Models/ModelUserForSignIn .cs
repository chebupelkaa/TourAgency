using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Agency.Models
{
    public class ModelUserForSignIn
    {

        [Required(ErrorMessage = "Введите почту")]
        [EmailAddress(ErrorMessage = "Некорректный адрес электронной почты")]
        public string Email { get; set; }=String.Empty;

        [Required(ErrorMessage = "Введите пароль")]
        [DataType(DataType.Password,ErrorMessage ="Неправильный пароль")]
        public string Password { get; set; } = String.Empty;

    }
}
