using Microsoft.EntityFrameworkCore;
using DevNet.Models;
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Post> Posts { get; set; }
    public DbSet<Rewiew> Rewiews { get; set; }
    public DbSet<Quesion> Quesions { get; set; }
    public DbSet<Answer> Answers { get; set; }

}
