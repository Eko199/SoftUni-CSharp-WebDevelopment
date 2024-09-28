using LibroAPI.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace LibroAPI.IntegrationTests.NUnit
{

    public class TestLibroDbContext : LibroDbContext
    {
        private string _databaseName;
        public TestLibroDbContext(string databaseName = "TestDatabase")
            : base(new ConfigurationBuilder().AddInMemoryCollection().Build())
        {
            _databaseName = databaseName;
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseInMemoryDatabase(_databaseName);
            }
        }
    }
}
