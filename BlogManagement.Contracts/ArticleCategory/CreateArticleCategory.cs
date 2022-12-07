using Microsoft.AspNetCore.Http;
using MyFramework.Tools;
using System.ComponentModel.DataAnnotations;

namespace BlogManagement.Contracts.ArticleCategory
{
    public class CreateArticleCategory 
    {
        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public string? Name { get;  set; }

        [MaxFileSize(MaxFileSize: 1 * 1024 * 1024, ErrorMessage = ValidationMessage.MaxFileSize)]
        //[FileExtensionsLimitation(new string[] { ".jpeg", ".jpg", ".png" }, ErrorMessage = ValidationMessage.InValidFileFormat)]
        public IFormFile? PicturePath { get;  set; }

        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public string? PictureAlt { get;  set; }

        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public string? PictureTitle { get;  set; }

        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public string? Description { get;  set; }

        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public int ShowOrder { get;  set; }

        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public string? Slug { get;  set; }

        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public string? MetaDescription { get;  set; }

        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public string? Keywords { get;  set; }

        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public string? CanonicalAddress { get;  set; }
    }
}
