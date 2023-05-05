using Microsoft.EntityFrameworkCore;
using Room2_NorthwindAPI.Models;

namespace Room2_NorthwindAPI.Data.Repositories;

public class NorthwindRepository : INorthwindRepository
{

    private readonly NorthwindContext _context;
    protected readonly DbSet<Employee> _dbSet;

    public NorthwindRepository(NorthwindContext context)
    {
        _context = context;
        _dbSet = context.Set<Employee>();
    }


    public bool IsNull => throw new NotImplementedException();


    public void Add(Employee entity)
    {
        throw new NotImplementedException();
    }

    public void AddRange(IEnumerable<Employee> entities)
    {
        throw new NotImplementedException();
    }

    public virtual async Task<Employee?> FindAsync(int id)
    {
        return await _dbSet.FindAsync(id);
    }

    public virtual async Task<IEnumerable<Employee>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public void Remove(Employee entity)
    {
        throw new NotImplementedException();
    }

    public Task SaveAsync()
    {
        throw new NotImplementedException();
    }

    public void Update(Employee entity)
    {
        throw new NotImplementedException();
    }
}
