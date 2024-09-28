using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace LibroAPI.DataAccess
{
    public class LibroDbContextFactory : IDesignTimeDbContextFactory<LibroDbContext>
    {
        public LibroDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<LibroDbContext>();

            builder.UseInMemoryDatabase("InMemoryLibroDb");

            return new LibroDbContext(builder.Options);
        }
    }
}
