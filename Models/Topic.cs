namespace DevNet.Models
{
    public class Topic
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string? image { get; set; }
        //public Profile CreatedBy { get; set; }
        public List<Quesion> Quesions { get; set; } 
        public DateTime CreatedAt { get; set; }
    }
}
