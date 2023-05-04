namespace Room2_NorthwindAPI.Models;

public class EmployeeDTO
{
    public int EmployeeId { get; set; }
    public string LastName { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string? City { get; set; }

    public string? PostalCode { get; set; }

    public virtual ICollection<Employee> InverseReportsToNavigation { get; set; } = new List<Employee>();

    public virtual Employee? ReportsToNavigation { get; set; }

}
