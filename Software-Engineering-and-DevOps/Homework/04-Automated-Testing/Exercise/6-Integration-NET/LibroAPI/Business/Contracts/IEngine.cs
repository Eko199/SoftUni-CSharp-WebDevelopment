using LibroAPI.DataAccess;
using LibroAPI.DataAccess.Contracts;

namespace LibroAPI.Business.Contracts
{
    public interface IEngine
    {
        Task Run(IBookManager bookManager);
    }
}
