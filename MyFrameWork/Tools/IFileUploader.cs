using Microsoft.AspNetCore.Http;

namespace MyFramework.Tools
{
    public interface IFileUploader
    {
        public string? Upload(IFormFile file , string Slug);
    }
}
