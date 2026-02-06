namespace DevNet.Models
{
    public class Profile
    {
        public int Id { get; set; }
        public string? ProfilePicture { get; set; }
        public string ProfileName { get; set; }
        public int Streak { get; set; }
        public string Note { get; set; }
        public int FollowersNumber { get; set; }
        public List<Profile> Followers { get; set; }
        public int UserId { get; set; }
        public ApplicationUser User { get; set; }   
        public  List<Review> Reviews { get; set; }
        List<Post> Posts { get; set; }
        List<Topic> Topics { get; set; }
    }
}
