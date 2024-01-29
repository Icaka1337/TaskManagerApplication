using Microsoft.EntityFrameworkCore;
using TaskManagerApp.Models;
using Microsoft.CodeAnalysis;

namespace TaskManagerApp.Data
{
    public class TaskManagerDbContext : DbContext
    {
        public TaskManagerDbContext(DbContextOptions options) : base(options)
        {
        }

        public virtual DbSet<Models.Project> Projects { get; set; }
        public virtual DbSet<Models.Task> Tasks { get; set; }
        public virtual DbSet<Models.User> Users { get; set; }
        public DbSet<TaskManagerApp.Models.Task> Task { get; set; } = default!;
        public DbSet<TaskManagerApp.Models.ProjectUser> ProjectUser { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=localhost;Database=TaskManagerDB;User Id=SA;Password=Icaka-1337;TrustServerCertificate=True;Integrated Security=False;");


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProjectUser>()
                .HasKey(pu => new { pu.UserId, pu.ProjectId });

            modelBuilder.Entity<ProjectUser>()
                .HasOne(pu => pu.User)
                .WithMany(u => u.Projects)
                .HasForeignKey(pu => pu.UserId);

            modelBuilder.Entity<ProjectUser>()
                .HasOne(pu => pu.Project)
                .WithMany(p => p.Users)
                .HasForeignKey(pu => pu.ProjectId);

            modelBuilder.Entity<Models.Task>()
                .HasOne(t => t.User)
                .WithMany(u => u.Tasks)
                .HasForeignKey(t => t.UserId);
        }
    }
}
