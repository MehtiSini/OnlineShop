using MyFramework.Domain;

namespace ShopManagement.Domain.SlideAgg
{
    public class SlideModel : EntityBase
    {
        public string? PicturePath { get; private set; }
        public string? PictureTitle { get; private set; }
        public string? PictureAlt { get; private set; }
        public string? Heading { get; private set; }
        public string? Title { get; private set; }
        public string? Text { get; private set; }
        public string? BtnText { get; private set; }
        public bool IsRemoved { get; private set; }

        public SlideModel(string? picturePath,
         string? pictureTitle, string? pictureAlt,
         string? heading, string? title, string? text, string? btnText)
        {
            PicturePath = picturePath;
            PictureTitle = pictureTitle;
            PictureAlt = pictureAlt;
            Heading = heading;
            Title = title;
            Text = text;
            BtnText = btnText;
            IsRemoved = false;
        }

        public void Edit(string? picturePath,
        string? pictureTitle, string? pictureAlt,
        string? heading, string? title, string? text, string? btnText)
        {
            PicturePath = picturePath;
            PictureTitle = pictureTitle;
            PictureAlt = pictureAlt;
            Heading = heading;
            Title = title;
            Text = text;
            BtnText = btnText;
        }

        public void Remove()
        {
            IsRemoved = true;
        }

        public void Activate()
        {
            IsRemoved = false;
        }
    }
}
