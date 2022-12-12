using AccountManagement.Contracts.Role;
using Microsoft.AspNetCore.Http;
using MyFramework.Tools;
using System.ComponentModel.DataAnnotations;

namespace AccountManagement.Contracts.Account
{
    public class CreateAccount
    {
        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public string? FullName { get; set; }

        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public string? Username { get; set; }

        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public string? Password { get; set; }

        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public string? Mobile { get; set; }

        public IFormFile? ProfilePhoto { get; set; }

        [Range(1, long.MaxValue, ErrorMessage = ValidationMessage.IsRequired)]
        public long RoleId { get; set; }

        public List<RoleViewModel>? Roles{ get; set; }

    }

}


