using Microsoft.EntityFrameworkCore;
using Room2_NorthwindAPI.Models;

namespace Room2_NorthwindAPI.Data.Repositories;


public class EmployeesRepository : NorthwindRepository
{
    public EmployeesRepository(NorthwindContext context) : base(context)
    {
    }

    public override async Task<Employee?> FindAsync(int id)
    {
        return await _dbSet.Where(c => c.EmployeeId == id).FirstOrDefaultAsync();
    }

    public override async Task<IEnumerable<Employee>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();

    }

}

