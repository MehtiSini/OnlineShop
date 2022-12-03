using MyFramework.Tools;
using ShopManagement.Contracts.Slide;
using ShopManagement.Domain.SlideAgg;

namespace ShopManagement.Application.Slide
{
    public class SlideApplication : ISlideApplication
    {
        private readonly ISlideRepository _repository;

        private readonly IFileUploader _fileUploader;

        public SlideApplication(ISlideRepository slideRepository, IFileUploader fileUploader)
        {
            _repository = slideRepository;
            _fileUploader = fileUploader;
        }

        public OperationResult Create(CreateSlide cmd)
        {
            var operation = new OperationResult();

            var FileName = _fileUploader.Upload(cmd.PicturePath, "Slides");

            var slide = new SlideModel(FileName, cmd.PictureTitle, cmd.PictureAlt
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

            var FileName = _fileUploader.Upload(cmd.PicturePath, "Slides");

            slide.Edit(FileName, cmd.PictureTitle, cmd.PictureAlt
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
