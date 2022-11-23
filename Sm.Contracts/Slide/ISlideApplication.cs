using MyFramework.Tools;

namespace ShopManagement.Contracts.Slide
{
    public interface ISlideApplication 
    {
        OperationResult Create(CreateSlide cmd);
        OperationResult Edit(EditSlide cmd);
        OperationResult Remove(long id);
        OperationResult Activate(long id);
        EditSlide GetDetails(long Id);
        List<SlideViewModel> GetList();
    }
}
