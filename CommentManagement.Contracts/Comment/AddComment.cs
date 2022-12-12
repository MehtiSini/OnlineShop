using MyFramework.Tools;
using System.ComponentModel.DataAnnotations;

namespace CommentManagement.Contracts.Comment
{
    public class AddComment
    {
        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public string? Name { get; set; }

        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public string? Email { get; set; }

        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public string? Message { get; set; }

        [Required(ErrorMessage = ValidationMessage.IsRequired)]

        public string? Website { get; set; }
        public int OwnerRecordId { get; set; }
        public int Type { get; set; }
        public long ParentId { get; set; }
    }
}
