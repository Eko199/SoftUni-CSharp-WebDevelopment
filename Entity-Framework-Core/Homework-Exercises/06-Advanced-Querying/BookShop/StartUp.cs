namespace BookShop;

using System.Globalization;

using Microsoft.EntityFrameworkCore;
using Z.EntityFramework.Plus;

using Data;
using Initializer;
using Models;
using Models.Enums;

public class StartUp
{
    public static void Main()
    {
        using var db = new BookShopContext();
        DbInitializer.ResetDatabase(db);

        Console.WriteLine(RemoveBooks(db));
    }

    //Problem 02.
    public static string GetBooksByAgeRestriction(BookShopContext context, string command)
    {
        if (!Enum.TryParse(command, true, out AgeRestriction ageRestriction))
            return null;

        return string.Join(Environment.NewLine, context.Books
            .AsNoTracking()
            .Where(b => b.AgeRestriction == ageRestriction)
            .Select(b => b.Title)
            .OrderBy(b => b)
            .ToArray());
    }

    //Problem 03.
    public static string GetGoldenBooks(BookShopContext context) 
        => string.Join(Environment.NewLine, context.Books
            .AsNoTracking()
            .Where(b => b.EditionType == EditionType.Gold && b.Copies < 5000)
            .OrderBy(b => b.BookId)
            .Select(b => b.Title)
            .ToArray());

    //Problem04.
    public static string GetBooksByPrice(BookShopContext context) 
        => string.Join(Environment.NewLine, context.Books
            .AsNoTracking()
            .Where(b => b.Price > 40)
            .OrderByDescending(b => b.Price)
            .Select(b => $"{b.Title} - ${b.Price:F2}")
            .ToArray());

    //Problem 05.
    public static string GetBooksNotReleasedIn(BookShopContext context, int year) 
        => string.Join(Environment.NewLine, context.Books
            .AsNoTracking()
            .Where(b => b.ReleaseDate.HasValue && b.ReleaseDate.Value.Year != year)
            .OrderBy(b => b.BookId)
            .Select(b => b.Title)
            .ToArray());

    //Problem 06.
    public static string GetBooksByCategory(BookShopContext context, string input)
    {
        string[] categories = input.ToLower().Split(' ', StringSplitOptions.RemoveEmptyEntries);

        return string.Join(Environment.NewLine, context.Books
            .AsNoTracking()
            .Where(b => b.BookCategories.Any(bc => categories.Contains(bc.Category.Name.ToLower())))
            .Select(b => b.Title)
            .OrderBy(b => b)
            .ToArray());
    }

    //Problem 07.
    public static string GetBooksReleasedBefore(BookShopContext context, string date) 
        => string.Join(Environment.NewLine, context.Books
            .AsNoTracking()
            .Where(b => b.ReleaseDate < DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture))
            .OrderByDescending(b => b.ReleaseDate)
            .Select(b => new
            {
                b.Title,
                b.EditionType,
                b.Price
            })
            .ToArray()
            .Select(b => $"{b.Title} - {b.EditionType} - ${b.Price:F2}"));

    //Problem 08.
    public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        => string.Join(Environment.NewLine, context.Authors
            .AsNoTracking()
            .Where(a => a.FirstName.EndsWith(input))
            .Select(a => $"{a.FirstName} {a.LastName}")
            .ToArray()
            .OrderBy(a => a));

    //Problem 09.
    public static string GetBookTitlesContaining(BookShopContext context, string input)
        => string.Join(Environment.NewLine, context.Books
            .AsNoTracking()
            .Select(b => b.Title)
            .Where(b => b.ToLower().Contains(input.ToLower()))
            .OrderBy(b => b)
            .ToArray());

    //Problem 10.
    public static string GetBooksByAuthor(BookShopContext context, string input)
        => string.Join(Environment.NewLine, context.Books
            .AsNoTracking()
            .Where(b => b.Author.LastName.ToLower().StartsWith(input.ToLower()))
            .OrderBy(b => b.BookId)
            .Select(b => $"{b.Title} ({b.Author.FirstName} {b.Author.LastName})")
            .ToArray());

    //Problem 11.
    public static int CountBooks(BookShopContext context, int lengthCheck)
        => context.Books.Count(b => b.Title.Length > lengthCheck);

    //Problem 12.
    public static string CountCopiesByAuthor(BookShopContext context)
        => string.Join(Environment.NewLine, context.Authors
            .AsNoTracking()
            .OrderByDescending(a => a.Books.Sum(b => b.Copies))
            .Select(a => $"{a.FirstName} {a.LastName} - {a.Books.Sum(b => b.Copies)}")
            .ToArray());

    //Problem 13.
    public static string GetTotalProfitByCategory(BookShopContext context)
        => string.Join(Environment.NewLine, context.Categories
            .AsNoTracking()
            .Select(c => new
            {
                c.Name,
                Profit = c.CategoryBooks.Sum(cb => cb.Book.Price * cb.Book.Copies)
            })
            .OrderByDescending(c => c.Profit)
            .ThenBy(c => c.Name)
            .Select(c => $"{c.Name} ${c.Profit:F2}")
            .ToArray());

    //Problem 14.
    public static string GetMostRecentBooks(BookShopContext context)
        => string.Join(Environment.NewLine, context.Categories
            .AsNoTracking()
            .Select(c => new
            {
                Name = "--" + c.Name,
                MostRecentBooks = c.CategoryBooks
                    .Where(cb => cb.Book.ReleaseDate.HasValue)
                    .OrderByDescending(cb => cb.Book.ReleaseDate)
                    .Take(3)
                    .Select(cb => $"{cb.Book.Title} ({cb.Book.ReleaseDate!.Value.Year})")
                    .ToArray()
            })
            .OrderBy(c => c.Name)
            .Select(c => c.Name + Environment.NewLine + string.Join(Environment.NewLine, c.MostRecentBooks))
            .ToArray());

    //Problem 15.
    public static void IncreasePrices(BookShopContext context)
    {
        List<Book> books = context.Books
            .Where(b => b.ReleaseDate.HasValue && b.ReleaseDate.Value.Year < 2010)
            .ToList();

        books.ForEach(b => b.Price += 5);
        context.BulkUpdate(books);
    }

    //Problem 16.
    public static int RemoveBooks(BookShopContext context)
        => context.Books
            .Where(b => b.Copies < 4200)
            .Delete();
}