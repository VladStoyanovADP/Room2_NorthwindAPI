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

    public bool IsNull => _dbSet == null;


    public void Add(Employee entity)
    {
        _dbSet.Add(entity);   
    }

    public void AddRange(IEnumerable<Employee> entities)
    {
        _dbSet.AddRange(entities);
    }

<<<<<<< HEAD
    public virtual async Task<Employee?> FindAsync(int id)
=======
    public async virtual Task<Employee?> FindAsync(int id)
>>>>>>> dev
    {
        return await _dbSet.FindAsync(id);
    }

<<<<<<< HEAD
    public virtual async Task<IEnumerable<Employee>> GetAllAsync()
=======
    public async virtual Task<IEnumerable<Employee>> GetAllAsync()
>>>>>>> dev
    {
        return await _dbSet.ToListAsync();
    }

    public void Remove(Employee entity)
    {
        _dbSet.Remove(entity);
    }

    public async Task SaveAsync()
    {
        await _context.SaveChangesAsync();
    }

    public void Update(Employee entity)
    {
        _dbSet.Update(entity);
    }
}
