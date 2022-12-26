using MyFramework.Tools;
using System.ComponentModel.DataAnnotations;

namespace AccountManagement.Contracts.Role
{
    public class CreateRole
    {
        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public string? Name { get; set; }
        public List<int>? Permissions { get; set; }

    }

}
