using Room2_NorthwindAPI.Models;

namespace Room2_NorthwindAPI.Data.Repositories;

public interface INorthwindRepository
{
    bool IsNull { get; }
    Task<IEnumerable<Employee>> GetAllAsync();
    Task<Employee?> FindAsync(int id);
    void Add(Employee entity);
    void AddRange(IEnumerable<Employee> entities);
    void Update(Employee entity);
    void Remove(Employee entity);
    Task SaveAsync();
}
