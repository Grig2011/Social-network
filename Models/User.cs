namespace DevNet.Models
{
    public class User
    {
        public int Id { get; set; }
        public string? ProfilePicture { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public int streak { get; set; }
        public string note { get; set; }
        public List<Post> Posts { get; set; }
        public List<User> Folowers { get; set; }
    }
}
