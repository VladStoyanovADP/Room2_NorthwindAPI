using Room2_NorthwindAPI.Models;

namespace Room2_NorthwindAPI.Controllers;

public class Utils
{
    public static EmployeeDTO EmployeeToDTO(Employee employee) =>
         new EmployeeDTO
         {
             EmployeeId = employee.EmployeeId,
             LastName = employee.LastName,
             FirstName = employee.FirstName,
             City = employee.City,
             PostalCode = employee.PostalCode
         };

}
