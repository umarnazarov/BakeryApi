// Student ID: 00013630
using BakeryApi.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using BakeryApi.Models;


namespace BakeryApi.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    private readonly BakeryDbContext _context;
    private readonly DbSet<T> _set;

    public GenericRepository(BakeryDbContext context)
    {
        _context = context;
        _set = context.Set<T>();
    }

    public async Task<IEnumerable<T>> GetAllAsync() => await _set.ToListAsync();

    public async Task<T?> GetByIdAsync(int id) => await _set.FindAsync(id);

    public async Task<T> AddAsync(T entity)
    {
        _set.Add(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<T> UpdateAsync(T entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var entity = await _set.FindAsync(id);
        if (entity == null) return false;
        _set.Remove(entity);
        await _context.SaveChangesAsync();
        return true;
    }


}
