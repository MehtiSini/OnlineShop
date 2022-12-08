namespace BlogManagement.Contracts.Article
{
    public class ArticleViewModel
    {
        public long Id { get; set; }
        public string? Title { get; set; }
        public long CategoryId { get; set; }
        public string? Slug { get; set; }
        public string? Category { get; set; }
        public string? PicturePath { get; set; }
        public string? Description { get; set; }
        public string? CreationDate { get; set; }
        public string? PublishDate { get; set; }

    }
}
