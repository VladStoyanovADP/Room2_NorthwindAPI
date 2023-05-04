using Room2_NorthwindAPI.Models;

namespace Room2_NorthwindAPI.Services;

public interface INorthwindService
{
    Task<bool> CreateAsync(Employee entity);
    Task<bool> UpdateAsync(int id, Employee entity);
    Task<bool> DeleteAsync(int id);
    Task<IEnumerable<Employee>?> GetAllAsync();
    Task<Employee?> GetAsync(int id);
}
