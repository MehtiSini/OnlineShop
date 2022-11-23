using Blog.Domain.Tools;
using MyFramework.Infrastructure;
using ShopManagement.Contracts.Slide;
using ShopManagement.Domain.SlideAgg;
using ShopManagement.Infrastructure.ProductCategory.DbContextModel;

namespace ShopManagement.Infrastructure.EfCore.Slide
{
    public class SlideRepository : RepositoryBase<long, SlideModel>, ISlideRepository
    {
        private readonly ShopContext _context;

        public SlideRepository(ShopContext context) : base(context)
        {
            _context = context;
        }

        public EditSlide GetDetails(long id)
        {
            return _context.slides.Select(x => new EditSlide
            {
                Id = x.Id,
                BtnText = x.BtnText,
                PictureAlt = x.PictureAlt,
                PicturePath = x.PicturePath,
                PictureTitle = x.PictureTitle,
                Heading = x.Heading,
                Text = x.Text,
                Title=x.Title,
                Link=x.Link

            }).FirstOrDefault(x=>x.Id==id);

        }

        public List<SlideViewModel> GetList()
        {
            return _context.slides.Select(x => new SlideViewModel
            {
                Id = x.Id,
                PicturePath = x.PicturePath,
                Heading = x.Heading,
                Title=x.Title,
                IsRemoved=x.IsRemoved,
                CreationDate=x.CreationDate.ToShamsi()
            }).OrderByDescending(x=>x.Id).ToList();

        }
    }
}
