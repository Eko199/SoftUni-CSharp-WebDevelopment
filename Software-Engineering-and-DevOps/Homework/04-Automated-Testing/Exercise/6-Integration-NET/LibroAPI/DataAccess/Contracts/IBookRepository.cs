using LibroAPI.Data.Models;

namespace LibroAPI.DataAccess.Contracts
{
    public interface IBookRepository
    {
        Task<Book> GetBookByISBNAsync(string isbn);
        Task<IEnumerable<Book>> GetAllBooksAsync();
        Task<IEnumerable<Book>> SearchBooksByTitleAsync(string titleFragment);
        Task AddBookAsync(Book book);
        Task UpdateBookAsync(Book book);
        Task DeleteBookAsync(string isbn);
    }
}
