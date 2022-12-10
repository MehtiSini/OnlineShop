namespace CommentManagement.Query.Contracts.Comment
{
    public class CommentQueryModel
    {
        public long Id { get; set; }
        public long ProductId { get;  set; }
        public string? Name { get;  set; }
        public string? Email { get;  set; }
        public string? Message { get;  set; }
        public string? CreationDate { get;  set; }
        public int CommentStatus { get; set; }
        public long ParentId { get; set; }
        public string? ParentName { get; set; }

    }
}
