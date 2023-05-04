using Room2_NorthwindAPI.Models;

namespace Room2_NorthwindAPI.Services;

public class NorthwindService : INorthwindService
{
   
    public Task<bool> CreateAsync(Employee entity)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Employee>?> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Employee?> GetAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateAsync(int id, Employee entity)
    {
        throw new NotImplementedException();
    }
}
