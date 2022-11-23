using MyFramework.Domain;
using ShopManagement.Contracts.Slide;

namespace ShopManagement.Domain.SlideAgg
{
    public interface ISlideRepository : IRepository<long,SlideModel>
    {
        EditSlide GetDetails(long id);
        List<SlideViewModel> GetList();
    }
}
