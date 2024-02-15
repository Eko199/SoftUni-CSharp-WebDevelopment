using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace TaskBoardApp.Data
{
    using Configurations;
    using Models;

    public class TaskBoardAppDbContext : IdentityDbContext
    {
        public TaskBoardAppDbContext(DbContextOptions<TaskBoardAppDbContext> options)
            : base(options) { }

        public DbSet<Board> Boards { get; set; } = null!;

        public DbSet<Task> Tasks { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserConfiguration())
                .ApplyConfiguration(new BoardConfiguration())
                .ApplyConfiguration(new TaskConfiguration());

            base.OnModelCreating(builder);
        }
    }
}
