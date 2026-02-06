namespace DevNet.Models
{
    public class ChatMessage
    {
        public int Id { get; set; }
        public int ChatRoomId { get; set; }
        public string SenderId { get; set; }
        public string ChatMessages { get; set; }
        public List<ChatComment> Comments { get; set; }
        public DateTime SentAt { get; set; }
    }
}
