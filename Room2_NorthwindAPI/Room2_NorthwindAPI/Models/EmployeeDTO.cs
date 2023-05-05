namespace Room2_NorthwindAPI.Models;

public class EmployeeDTO
{
    public string LastName { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string? Title { get; set; }

    public string? TitleOfCourtesy { get; set; }

    public string FullName => $"{TitleOfCourtesy} {FirstName} {LastName}, {TitleOfCourtesy}";

    public string? City { get; set; }

    public string? Region { get; set; }

    public string? PostalCode { get; set; }

    public string? Country { get; set; }

    public string? Location => $"{City}, {Region}, {PostalCode}, {Country}";

    public byte[]? Photo { get; set; }

    public string? Notes { get; set; }

    public int? ReportsTo { get; set; }

    public string? PhotoPath { get; set; }

    public virtual ICollection<Employee> InverseReportsToNavigation { get; set; } = new List<Employee>();

    public virtual Employee? ReportsToNavigation { get; set; }

}
