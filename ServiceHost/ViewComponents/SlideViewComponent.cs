using Microsoft.AspNetCore.Mvc;
using ShopManagement.Query.Contracts.Slide;

namespace ServiceHost.ViewComponents
{
    public class SlideViewComponent : ViewComponent
    {
        private readonly ISlideQuery _slideQuery;

        public SlideViewComponent(ISlideQuery slideQuery)
        {
            _slideQuery = slideQuery;
        }

        public IViewComponentResult Invoke()
        {
            var slide = _slideQuery.GetSlides();

            return View(slide);
        }

    }
}
