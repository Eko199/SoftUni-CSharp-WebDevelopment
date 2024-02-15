namespace TaskBoardApp.Data.Configurations;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;
using static ConfigurationHelper;

public class TaskConfiguration : IEntityTypeConfiguration<Task>
{
    public void Configure(EntityTypeBuilder<Task> builder)
    {
        builder.HasOne(t => t.Board)
            .WithMany(t => t.Tasks)
            .HasForeignKey(t => t.BoardId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasData(GetTasks());
    }

    private static IEnumerable<Task> GetTasks()
        => new Task[]
        {
            new()
            {
                Id = 1,
                Title = "Improve CSS styles",
                Description = "Implement better styling for all public pages",
                CreatedOn = DateTime.Now.AddDays(-200),
                OwnerId = TestUser.Id,
                BoardId = OpenBoard.Id
            },
            new()
            {
                Id = 2,
                Title = "Android Client App",
                Description = "Create Android client app fot the TaskBoard RESTful API",
                CreatedOn = DateTime.Now.AddMonths(-5),
                OwnerId = TestUser.Id,
                BoardId = OpenBoard.Id
            },
            new()
            {
                Id = 3,
                Title = "Desktop Client App",
                Description = "Create Windows Forms desktop app client fot the TaskBoard RESTful API",
                CreatedOn = DateTime.Now.AddMonths(-1),
                OwnerId = TestUser.Id,
                BoardId = InProgressBoard.Id
            },
            new()
            {
                Id = 4,
                Title = "Create Tasks",
                Description = "Implement [Create Task] page for adding new tasks",
                CreatedOn = DateTime.Now.AddYears(-1),
                OwnerId = TestUser.Id,
                BoardId = DoneBoard.Id
            }
        };
}