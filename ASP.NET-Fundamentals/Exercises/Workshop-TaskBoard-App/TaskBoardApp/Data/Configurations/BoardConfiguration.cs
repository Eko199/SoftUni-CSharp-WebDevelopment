namespace TaskBoardApp.Data.Configurations;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

public class BoardConfiguration : IEntityTypeConfiguration<Board>
{
    public void Configure(EntityTypeBuilder<Board> builder)
        => builder.HasData(ConfigurationHelper.OpenBoard, 
            ConfigurationHelper.InProgressBoard,
            ConfigurationHelper.DoneBoard);
}