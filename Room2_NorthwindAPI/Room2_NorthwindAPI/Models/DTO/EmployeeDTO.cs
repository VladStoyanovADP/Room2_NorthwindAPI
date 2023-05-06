namespace Room2_NorthwindAPI.Models.DTO;

public class EmployeeDTO
{
    public string LastName { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string? Title { get; set; }

    public string? TitleOfCourtesy { get; set; }

    public string FullName => $"{TitleOfCourtesy} {FirstName} {LastName}, {TitleOfCourtesy}";

    public string? City { get; set; }

    public string? PostalCode { get; set; }

    public string? Country { get; set; }

    public string? Region { get; set; }

    public string? Location => $"{City}, {PostalCode}, {Country}";

    public List<LinkDTO> Links { get; set; }

}
