namespace DevNet.Models
{
    public class Answer
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
     
        public int UserId { get; set; }
        public Profile User { get; set; }
    }
}
