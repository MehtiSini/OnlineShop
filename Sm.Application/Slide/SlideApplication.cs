using MyFramework.Tools;
using ShopManagement.Contracts.Slide;
using ShopManagement.Domain.SlideAgg;

namespace ShopManagement.Application.Slide
{
    public class SlideApplication : ISlideApplication
    {
        private readonly ISlideRepository _repository;

        public SlideApplication(ISlideRepository slideRepository)
        {
            _repository = slideRepository;
        }

        public OperationResult Create(CreateSlide cmd)
        {
            var operation = new OperationResult();

            var slide = new SlideModel(cmd.PicturePath, cmd.PictureTitle, cmd.PictureAlt
                , cmd.Heading, cmd.Title, cmd.Link, cmd.Text, cmd.BtnText);

            _repository.Create(slide);

            _repository.Save();

            return operation.Succeed();
        }

        public OperationResult Edit(EditSlide cmd)
        {
            var operation = new OperationResult();

            var slide = _repository.GetById(cmd.Id);

            if (slide == null)
            {
                return operation.Failed(OperationMessage.NotFound);
            }

            slide.Edit(cmd.PicturePath, cmd.PictureTitle, cmd.PictureAlt
              , cmd.Heading, cmd.Title, cmd.Link, cmd.Text, cmd.BtnText);

            _repository.Save();

            return operation.Succeed();

        }

        public EditSlide GetDetails(long Id)
        {
            return _repository.GetDetails(Id);

        }

        public List<SlideViewModel> GetList()
        {
            return _repository.GetList();
        }

        public OperationResult Remove(long id)
        {
            var operation = new OperationResult();

            var slide = _repository.GetById(id);

            if (slide == null)
            {
                return operation.Failed(OperationMessage.NotFound);
            }

            slide.Remove();
            _repository.Save();

            return operation.Succeed();

        }

        public OperationResult Activate(long id)
        {
            var operation = new OperationResult();

            var slide = _repository.GetById(id);

            if (slide == null)
            {
                return operation.Failed(OperationMessage.NotFound);
            }

            slide.Activate();
            _repository.Save();

            return operation.Succeed();
        }

    }
}
