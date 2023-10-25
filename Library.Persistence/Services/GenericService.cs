using Library.Application.Interfaces;
using Library.Persistence.DB;
using Microsoft.EntityFrameworkCore;

namespace Library.Persistence.Services;

public class GenericService<T> : IGenericService<T> where T : class
{
    protected readonly DBContext _dbContext;

    public GenericService(DBContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<List<T>> GetAllEntity(int pageNumber, int pageSize)
    {
        var itemsToSkip = (pageNumber - 1) * pageSize;
        return await _dbContext.Set<T>().Skip(itemsToSkip).Take(pageSize).ToListAsync();
    }

    public async Task<T?> GetEntity(int id)
    {
        var entity = await _dbContext.Set<T>().FindAsync(id);
        return entity;
    }

    public async Task<T> AddEntity(T entity)
    {
        await _dbContext.Set<T>().AddAsync(entity);
        await _dbContext.SaveChangesAsync();
        return entity;
    }

    public async Task<T> UpdateEntity(int id, T req)
    {
        var entity = await GetEntity(id);
        if (entity == null)
            throw new InvalidOperationException("Couldn't find!");
        var entryObject = _dbContext.Entry(entity);
        entryObject.CurrentValues.SetValues(req);
        await _dbContext.SaveChangesAsync();
        return entity;
    }

    public async Task<List<T>?> DeleteEntity(int id)
    {
        var entities = _dbContext.Set<T>();
        var entity = await entities.FindAsync(id);
        if (entity is null)
            return null;

        entities.Remove(entity);
        await _dbContext.SaveChangesAsync();
        return await entities.ToListAsync();
    }
}