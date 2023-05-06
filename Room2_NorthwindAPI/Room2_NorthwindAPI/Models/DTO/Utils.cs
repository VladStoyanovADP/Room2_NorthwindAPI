namespace Room2_NorthwindAPI.Models.DTO;

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
             PostalCode = employee.PostalCode,
             Country = employee.Country,
         };

}
