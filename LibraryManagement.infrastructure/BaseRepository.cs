using LibraryManagement.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace LibraryManagement.Infrastructure;

public class BaseRepository<T> : IBaseRepository<T> where T : class 
{
    protected readonly LibraryManagementContext _context;
    protected readonly DbSet<T> _dbSet;


    public BaseRepository(LibraryManagementContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }


    public async Task<List<T>> GetAllAsync(int pageNumber, int pageSize, CancellationToken token)
    {
        return await _dbSet
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync(token);
    }
    public async Task<T> GetByIdAsync(int id,CancellationToken token)
    {
        return await _dbSet.FindAsync(id,token);
    }

    public async Task AddAsync(T entity,CancellationToken token)
    {
        await _dbSet.AddAsync(entity,token);
        await _context.SaveChangesAsync(token);
    }

    public async Task UpdateAsync(T entity,CancellationToken token)
    {
        if (entity == null)
            return;

        _dbSet.Update(entity);
         await _context.SaveChangesAsync(token);
    }

    public async Task RemoveAsync(T entity,CancellationToken token)
    {
        if (entity == null)
            return;

        _dbSet.Remove(entity);
        await _context.SaveChangesAsync(token);
    }

    public async Task<bool> ExistsAsync( Expression<Func<T, bool>> predicate,CancellationToken token)
    {
        return await _dbSet.AnyAsync(predicate, token);
    }

}
