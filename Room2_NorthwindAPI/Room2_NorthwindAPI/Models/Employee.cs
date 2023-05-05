using System;
using System.Collections.Generic;

namespace Room2_NorthwindAPI.Models;

public partial class Employee
{
    // ID should be secret
    public int EmployeeId { get; set; }

    //Name formatted as title, first name, last name, titleofcourtesy 
    public string LastName { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string? Title { get; set; }

    public string? TitleOfCourtesy { get; set; } 

    public string FullName => $"{TitleOfCourtesy} {FirstName} {LastName}, {TitleOfCourtesy}";

    // Birthday should be secret. Law requirement
    public DateTime? BirthDate { get; set; }

    public DateTime? HireDate { get; set; }

    //SECRET. Law
    public string? Address { get; set; }

    //Below details formatted into one 
    public string? City { get; set; }

    public string? Region { get; set; }

    public string? PostalCode { get; set; }

    public string? Country { get; set; }

    public string? Location => $"{City}, {Region}, {PostalCode}, {Country}";

    //Secret
    public string? HomePhone { get; set; }

    //Secret
    public string? Extension { get; set; }

    public byte[]? Photo { get; set; }

    public string? Notes { get; set; }

    public int? ReportsTo { get; set; }

    public string? PhotoPath { get; set; }

    public virtual ICollection<Employee> InverseReportsToNavigation { get; set; } = new List<Employee>();

    public virtual Employee? ReportsToNavigation { get; set; }
}
