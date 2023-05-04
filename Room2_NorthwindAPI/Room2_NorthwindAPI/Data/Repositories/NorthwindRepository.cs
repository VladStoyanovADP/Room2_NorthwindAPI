using Room2_NorthwindAPI.Models;

namespace Room2_NorthwindAPI.Data.Repositories;

public class NorthwindRepository : INorthwindRepository
{

    private readonly NorthwindContext _context;

    public NorthwindRepository(NorthwindContext context)
    {
        _context = context;
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

    public Task<Employee?> FindAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Employee>> GetAllAsync()
    {
        throw new NotImplementedException();
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
