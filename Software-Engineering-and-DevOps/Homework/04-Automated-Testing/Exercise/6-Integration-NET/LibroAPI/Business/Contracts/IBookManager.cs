using LibroAPI.Data.Models;

namespace LibroAPI.Business.Contracts
{
    public interface IBookManager
    {
        Task AddAsync(Book book);
        Task<IEnumerable<Book>> GetAllAsync();
        Task<IEnumerable<Book>> SearchByTitleAsync(string titleFragment);
        Task<Book> GetSpecificAsync(string isbn);
        Task UpdateAsync(Book book);
        Task DeleteAsync(string isbn);
    }
}
