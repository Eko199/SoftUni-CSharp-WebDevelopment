namespace P01_HospitalDatabase.Data;

using Microsoft.EntityFrameworkCore;

public class HospitalContext : DbContext
{
    public HospitalContext() { }

    public HospitalContext(DbContextOptions options) : base(options) { }
}