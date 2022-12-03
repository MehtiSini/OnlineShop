using Microsoft.AspNetCore.Http;
using MyFramework.Tools;
using System.ComponentModel.DataAnnotations;

namespace ShopManagement.Contracts.Slide
{
    public class CreateSlide
    {
        [MaxFileSize(MaxFileSize: 3 * 1024 * 1024, ErrorMessage = ValidationMessage.MaxFileSize)]
        //[FileExtensionsLimitation(new string[] { ".jpeg", ".jpg", ".png" }, ErrorMessage = ValidationMessage.InValidFileFormat)]
        public IFormFile? PicturePath { get; set; }

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
