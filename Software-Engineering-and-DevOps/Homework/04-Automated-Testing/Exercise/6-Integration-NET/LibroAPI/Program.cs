using LibroAPI.Business;
using LibroAPI.DataAccess;
using LibroAPI.Repositories;

namespace LibroApplication
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                var engine = new Engine();

                var contextFactory = new LibroDbContextFactory();

                using var context = contextFactory.CreateDbContext(args);

                var bookRepository = new BookRepository(context);
                var bookManager = new BookManager(bookRepository);


                await DatabaseSeeder.SeedDatabaseAsync(context, bookManager);

                await engine.Run(bookManager);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }            
        }   
    }
}
