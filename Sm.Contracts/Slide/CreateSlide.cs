using MyFramework.Tools;
using System.ComponentModel.DataAnnotations;

namespace ShopManagement.Contracts.Slide
{
    public class CreateSlide
    {
        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public string? PicturePath { get; set; }

        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public string? PictureTitle { get; set; }

        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public string? PictureAlt { get; set; }

        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public string? Heading { get; set; }

        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public string? Title { get; set; }

        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public string? Text { get; set; }

        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public string? BtnText { get; set; }

        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public string? Link { get; set; }
    }
}
