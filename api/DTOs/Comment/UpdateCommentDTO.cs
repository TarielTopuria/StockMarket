﻿namespace api.DTOs.Comment
{
    public class UpdateCommentDTO
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public DateTime CreationTime { get; set; } = DateTime.Now;
        public int? StockId { get; set; }
    }
}