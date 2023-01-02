using ShopManagement.Infrastructure.ProductCategory.DbContextModel;
using ShopManagement.Query.Contracts.Slide;

namespace ShopManagement.Query.Query
{
    public class SlideQuery : ISlideQuery
    {
        private readonly ShopContext _context;

        public SlideQuery(ShopContext context)
        {
            _context = context;
        }

        public List<SlideQueryModel> GetSlides()
        {
            return _context.slides.Where(x => x.IsRemoved == false)
                .Select(x => new SlideQueryModel
                {
                    Heading = x.Heading,
                    Link = x.Link,
                    PictureTitle = x.PictureTitle,
                    PicturePath = x.PicturePath,
                    Text = x.Text,
                    Title = x.Title,
                    BtnText = x.BtnText,
                    PictureAlt = x.PictureAlt
                }).ToList();

        }
    }
}
