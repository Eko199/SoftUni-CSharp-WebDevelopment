namespace Eventmi.Data;

using Microsoft.EntityFrameworkCore;

using Models;

public class EventmiDbContext : DbContext
{
    protected EventmiDbContext() { }

    public EventmiDbContext(DbContextOptions options) : base(options) { }

    public DbSet<Event> Events { get; set; } = null!;
}