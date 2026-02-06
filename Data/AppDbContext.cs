using Microsoft.EntityFrameworkCore;
using DevNet.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
public class AppDbContext: IdentityDbContext<ApplicationUser>
    {
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }
    public DbSet<Profile> Profiles { get; set; }
    public DbSet<Notification> notifications { get; set; }
    public DbSet<Follow> Follows { get; set; }
    public DbSet<ChatMessage> chatMessages { get; set; }
    public DbSet<Topic> Topics { get; set; }
    public DbSet<Post> Posts { get; set; }
    public DbSet<Review> Rewiews { get; set; }
    public DbSet<Quesion> Quesions { get; set; }
    public DbSet<Answer> Answers { get; set; }
    public DbSet<ChatRoom> ChatRooms { get; set; }
}
