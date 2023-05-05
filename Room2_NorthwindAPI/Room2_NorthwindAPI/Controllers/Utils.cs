using Room2_NorthwindAPI.Models;

namespace Room2_NorthwindAPI.Controllers;

public class Utils
{
    public static EmployeeDTO EmployeeToDTO(Employee employee) =>
         new EmployeeDTO
         {
             LastName = employee.LastName,
             FirstName = employee.FirstName,
             Title = employee.Title,
             TitleOfCourtesy = employee.TitleOfCourtesy,
             City = employee.City,
             Region = employee.Region,
             PostalCode = employee.PostalCode,
             Country = employee.Country,
             Photo = employee.Photo,
             Notes = employee.Notes,
             ReportsTo = employee.ReportsTo,
             PhotoPath = employee.PhotoPath,
             InverseReportsToNavigation = employee.InverseReportsToNavigation,
             ReportsToNavigation = employee.ReportsToNavigation
         };

}
