using Room2_NorthwindAPI.Models;

namespace Room2_NorthwindAPI.Controllers;

public class Utils
{
    public static EmployeeDTO EmployeeToDTO(Employee employee) =>
         new EmployeeDTO
         {
             FullName = employee.FullName,
             Location = employee.Location,
             Photo = employee.Photo,
             Notes = employee.Notes,
             ReportsTo = employee.ReportsTo,
             PhotoPath = employee.PhotoPath,
             InverseReportsToNavigation = employee.InverseReportsToNavigation,
             ReportsToNavigation = employee.ReportsToNavigation
         };

}
