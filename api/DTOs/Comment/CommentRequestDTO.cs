using Microsoft.AspNetCore.Mvc;

namespace api.DTOs.Comment
{
    public class CommentRequestDTO
    {
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
    }
}
