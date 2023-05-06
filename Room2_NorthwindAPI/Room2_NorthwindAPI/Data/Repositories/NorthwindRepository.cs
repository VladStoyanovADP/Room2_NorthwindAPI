﻿using Microsoft.EntityFrameworkCore;
using Room2_NorthwindAPI.Models;

namespace Room2_NorthwindAPI.Data.Repositories;

public class NorthwindRepository<T> : INorthwindRepository<T> where T : class
{
    protected readonly NorthwindContext _context;
    protected readonly DbSet<T> _dbSet;

    public NorthwindRepository(NorthwindContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }

    public bool IsNull => _dbSet == null;

    public void Add(T entity)
    {
        _dbSet.Add(entity);
    }

    public void AddRange(IEnumerable<T> entities)
    {
        _dbSet.AddRange(entities);
    }

    public virtual async Task<T?> FindAsync(int id)
    {
        return await _dbSet.FindAsync(id);
    }

    public virtual async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public virtual void Remove(T entity)
    {
        _dbSet.Remove(entity);
    }

    public async Task SaveAsync()
    {
        await _context.SaveChangesAsync();
    }

    public virtual void Update(T entity)
    {
        _dbSet.Update(entity);
    }
}