using Room2_NorthwindAPI.Data.Repositories;
using Room2_NorthwindAPI.Models;

namespace Room2_NorthwindAPI.Services
{
    public class EmployeeService : NorthwindService<Employee>
    {
        private readonly INorthwindRepository<Employee> _employeeRepository;

        public EmployeeService(
            ILogger<INorthwindService<Employee>> logger,
            INorthwindRepository<Employee> repository) : base(logger, repository)
        {
            _employeeRepository = repository;
        }

        public override async Task<bool> UpdateAsync(int id, Employee entity)
        {
            var employee = await _employeeRepository.FindAsync(id);

            if (employee == null)
            {
                return false;
            }

            employee.Address = entity.Address ?? employee.Address;
            employee.BirthDate = entity.BirthDate ?? employee.BirthDate;
            employee.City = entity.City ?? employee.City;
            employee.Country = entity.Country ?? employee.Country;
            employee.FirstName = entity.FirstName ?? employee.FirstName;
            employee.HireDate = entity.HireDate ?? employee.HireDate;
            employee.HomePhone = entity.HomePhone ?? employee.HomePhone;
            employee.LastName = entity.LastName ?? employee.LastName;
            employee.Notes = entity.Notes ?? employee.Notes;
            employee.PostalCode = entity.PostalCode ?? employee.PostalCode;
            employee.Title = entity.Title ?? employee.Title;
            employee.TitleOfCourtesy = entity.TitleOfCourtesy ?? employee.TitleOfCourtesy;
            employee.ReportsTo = entity.ReportsTo ?? employee.ReportsTo;
            employee.Region = entity.Region ?? employee.Region;

            await _employeeRepository.SaveAsync();

            return true;
        }
    }
}
