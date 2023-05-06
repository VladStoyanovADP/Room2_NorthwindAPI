using Microsoft.EntityFrameworkCore;
using Room2_NorthwindAPI.Data.Repositories;
using Room2_NorthwindAPI.Models;

namespace Room2_NorthwindAPI.Data.Repository
{
    public class EmployeesRepository : NorthwindRepository<Employee>
    {
        public EmployeesRepository(NorthwindContext context) : base(context)
        {

        }

        public override async Task<Employee?> FindAsync(int id)
        {
            return await _dbSet
                .Where(e => e.EmployeeId == id)
                .Include(e => e.Orders)
                .FirstOrDefaultAsync();
        }
        public override async Task<IEnumerable<Employee>> GetAllAsync()
        {
            return await _dbSet
                .ToListAsync();
        }
    }
}