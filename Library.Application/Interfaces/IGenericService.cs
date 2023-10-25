namespace Library.Application.Interfaces;

public interface IGenericService<T>
{
    Task<List<T>> GetAllEntity(int pageNumber, int pageSize);
    Task<T?> GetEntity(int id);
    Task<T> AddEntity(T entity);
    Task<T> UpdateEntity(int id, T req);
    Task<List<T>?> DeleteEntity(int id);
}