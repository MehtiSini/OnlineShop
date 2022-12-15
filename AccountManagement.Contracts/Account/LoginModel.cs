using MyFramework.Tools;
using System.ComponentModel.DataAnnotations;

namespace AccountManagement.Contracts.Account
{
    public class LoginModel
    {
        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public string? Username { get; set; }

        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public string? Password { get; set; }
    }
}
