namespace ShopManagement.Contracts.Slide
{
    public class SlideViewModel
    {
        public long Id { get; set; }
        public string? PicturePath { get; set; }
        public string? Heading { get; set; }
        public string? Title { get; set; }
        public bool IsRemoved { get; set; }
    }
}
