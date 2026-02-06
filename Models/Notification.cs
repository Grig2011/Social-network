namespace DevNet.Models
{
    public class Notification
    {
    public int Id { get; set; }
    public int SenderId { get; set; }
    public int ReceiverId { get; set; }
    public ApplicationUser ApplicationUser { get; set; }
    public string Message {  get; set; }
    public bool IsRead {  get; set; }
    public NotificationType Type { get; set; } 
    public DateTime CreatedAt { get; set; }
    }
}
