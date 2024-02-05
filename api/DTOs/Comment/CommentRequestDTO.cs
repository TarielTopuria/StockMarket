namespace api.DTOs.Comment
{
    public class CommentRequestDTO
    {
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public DateTime CreationTime { get; set; } = DateTime.Now;
        public int? StockId { get; set; }
    }
}
