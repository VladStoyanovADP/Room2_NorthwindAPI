using Room2_NorthwindAPI.Models.DTO;
using Room2_NorthwindAPI.Models;

public class Utils 
{
    public static EmployeeDTO EmployeeToDTO(Employee employee)
    {
        return new EmployeeDTO
        {
            LastName = employee.LastName,
            FirstName = employee.FirstName,
            Title = employee.Title,
            TitleOfCourtesy = employee.TitleOfCourtesy,
            City = employee.City,
            PostalCode = employee.PostalCode,
            Country = employee.Country,
            Links = new List<LinkDTO>
            {
                new LinkDTO
                {
                    Href = $"api/employees/{employee.EmployeeId}",
                    Rel = "self",
                    Method = HttpMethod.Get.ToString()
                },
                new LinkDTO
                {
                    Href = $"api/employees/{employee.EmployeeId}",
                    Rel = "update_employee",
                    Method = HttpMethod.Put.ToString()
                },
                new LinkDTO
                {
                    Href = $"api/employees/{employee.EmployeeId}",
                    Rel = "delete_employee",
                    Method = HttpMethod.Delete.ToString()
                }
            }
        };
    }

}

