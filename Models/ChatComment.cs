namespace DevNet.Models
{
    public class ChatComment
    {
        public int Id { get; set; }
        public int ChatMessageId { get; set; }
        public int SenderId { get; set; }
        public string CommentText { get; set; }
        public NotificationType NotificationType { get; set; } = NotificationType.Comment;
        public Notification? Notification { get; set; }
        public DateTime CommentedAt { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}
