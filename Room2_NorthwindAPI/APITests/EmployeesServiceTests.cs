using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Room2_NorthwindAPI.Models;
using Room2_NorthwindAPI.Data.Repositories;
using Room2_NorthwindAPI.Controllers;
using Room2_NorthwindAPI.Services;
using Moq;
using Microsoft.IdentityModel.Tokens;

namespace APITests;

internal class EmployeesServiceTests
{

    //private INorthwindRepository _repository;

/*    [OneTimeSetUp]
    private static void OneTimeSetup()
    {
        _repository = Mock.Of<INorthwindRepository>();
    }*/

    [Category("Happy Path")]
    [Category("GetEmployees")]
    [Test]
    public async Task GivenThereAreEmployees_GetAllAsync_ReturnsAllEmployeesEntries()
    {
        INorthwindRepository _repository = Mock.Of<INorthwindRepository>();
        List <Employee> employees = new List<Employee> { It.IsAny<Employee>() };
        Mock
            .Get(_repository)
            .Setup(es => es.GetAllAsync().Result)
            .Returns(employees);

        Mock
            .Get(_repository)
            .Setup(es => es.IsNull)
            .Returns(false);

        var _sut = new NorthwindService();
        var result = await _sut.GetAllAsync();
        Assert.That(result, Is.EqualTo(employees));
    }

    [Category("Sad Path")]
    [Category("GetEmployees")]
    [Test]
    public async Task GivenThereAreNotEmployees_GetAllAsync_ReturnsNull()
    {
        INorthwindRepository _repository = Mock.Of<INorthwindRepository>();
        List<Employee> employees = new List<Employee>();

        Mock
            .Get(_repository)
            .Setup(es => es.GetAllAsync().Result)
            .Returns(employees);

        Mock.Get(_repository)
            .Setup(es => es.IsNull)
            .Returns(true);

        var _sut = new NorthwindService();
        var result = await _sut.GetAllAsync();
        Assert.That(result, Is.Null);
        Assert.That(result.IsNullOrEmpty);
    }

    [Category("Happy Path")]
    [Category("GetEmployee")]
    [Test]
    public async Task GivenThereAreEmployees_GetAsync_ReturnsCorrectEmployee()
    {
        var _repository = new Mock<INorthwindRepository>();


        Employee employee = new Employee()
        {
            EmployeeId = 55,
            LastName = "Bloggs",
            FirstName = "Dave",
            Title = "Head Of Science things",
            TitleOfCourtesy = "Mr"
        };

        _repository
            .Setup(es => es.FindAsync(employee.EmployeeId))
            .Returns(Task.FromResult(employee));

        var _sut = new NorthwindService();


        var result = await _sut.GetAsync(employee.EmployeeId);

        Assert.That(result, Is.EqualTo(employee));
        Assert.That(result.EmployeeId, Is.EqualTo(55));
        Assert.That(result.LastName, Is.EqualTo("Bloggs"));
        Assert.That(result.FirstName, Is.EqualTo("Dave"));
        Assert.That(result.Title, Is.EqualTo("Head Of Science things"));
        Assert.That(result.TitleOfCourtesy, Is.EqualTo("Mr"));

    }

/*    [Category("Sad Path")]
    [Category("GetEmployee")]
    [Test]
    public async Task GivenThereIsNoEmployee_GetAsync_ReturnsNull()
    {

        Mock
            .Get(_repository)
            .Setup(es => es.FindAsync(0).Result)
            .Returns(null);

        Mock
            .Get(_repository)
            .Setup(es => es.IsNull)
            .Returns(true);
    }

    [Category("Happy Path")]
    [Category("UpdateEmployee")]
    [Test]
    public async Task GivenThereIsAnEmployeeToUpdate_UpdateAsync_ReturnsTrue()
    {
        Mock
            .Get(_repository)
            .Setup(es => es.Update(employee))
            .Returns(true);
    }*/
}
