using Microsoft.EntityFrameworkCore;
using Room2_NorthwindAPI.Models;

<<<<<<< HEAD
namespace Room2_NorthwindAPI.Data.Repositories;

=======


namespace Room2_NorthwindAPI.Data.Repositories;



>>>>>>> dev
public class EmployeesRepository : NorthwindRepository
{
    public EmployeesRepository(NorthwindContext context) : base(context)
    {
    }

<<<<<<< HEAD
=======


>>>>>>> dev
    public override async Task<Employee?> FindAsync(int id)
    {
        return await _dbSet.Where(c => c.EmployeeId == id).FirstOrDefaultAsync();
    }

<<<<<<< HEAD
=======


>>>>>>> dev
    public override async Task<IEnumerable<Employee>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> dev
