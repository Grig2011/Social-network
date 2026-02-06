using System.ComponentModel.DataAnnotations;

namespace DevNet.Models
{
    public class Quesion
    {
        [Key]
        public int Id { get; set; }
        // Question fuilds
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public int ViewCount { get; set; }
        // Foreign Key for User
        public int UserId { get; set; }
        public Profile User { get; set; }
        public List<Answer> Answers { get; set; }


    }
}
