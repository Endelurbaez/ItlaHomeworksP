namespace Parking.Application.Contracts
{
    public interface ITarifaService<T> where T : class
    {
        Task<T> CreateAsync(T dto);           // ← Este es el PROBLEMA
        Task<T> UpdateAsync(int id, T dto);   // ← Este también
        Task<bool> DeleteAsync(int id);
        Task<T?> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T?> GetByNombreAsync(string nombre);  // ← Este te falta
    }
}