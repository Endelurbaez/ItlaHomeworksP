
namespace Parking.Application.Contracts
{
    public interface ITicketService<T> where T : class
    {
        Task<T> CreateAsync(T dto);
        Task<T> UpdateAsync(int id, T dto);
        Task<bool> DeleteAsync(int id);
        Task<T?> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
    }
}
