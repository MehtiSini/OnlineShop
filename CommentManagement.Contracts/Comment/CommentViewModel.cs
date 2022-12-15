namespace CommentManagement.Contracts.Comment
{
    public class CommentViewModel
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Message { get; set; }
        public int OnwerRecordID { get; set; }
        public string? OnwerName { get; set; }
        public string? Website { get; set; }
        public int CommentStatus { get; set; }
        public string? CreationDate { get; set; }
        public int Type { get; set; }
        public string? TypeName { get; set; }
    }
}
