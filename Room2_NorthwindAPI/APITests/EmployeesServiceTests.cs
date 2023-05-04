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

namespace APITests;

internal class EmployeesServiceTests
{

    private INorthwindRepository _repository;

    [OneTimeSetUp]
    private static void OneTimeSetup()
    {
        _repository = Mock.Of<INorthwindRepository<Employee>>;
    }

    [Category("Happy Path")]
    [Category("GetEmployees")]
    [Test]
    public async Task GivenThereAreEmployees_GetAllAsync_ReturnsAllEmployeesEntries()
    {
        List<Employee> employees = new List<Employee> { It.IsAny<Employee>() };
        Mock
            .Get(_repository)
            .Setup(es => es.GetAllAsync().Result)
            .Returns(employees);

        Mock
            .Get(_repository)
            .Setup(es => es.IsNull)
            .Returns(false);

        var _sut = new NorthwindService<Employee>(_repository);
        var result = await _sut.GetAllAsync();
        Assert.That(result, Is.InstanceOf<IEnumerable<Employee>>);
        Assert.That(result.IsFalse);
    }

    [Category("Sad Path")]
    [Category("GetEmployees")]
    [Test]
    public async Task GivenThereAreNotEmployees_GetAllAsync_ReturnsNull()
    {
        List<Employee> employees = new List<EmployeesController>();

        Mock
            .Get(_repository)
            .Setup(es => es.GetAllAsync().Result)
            .Returns(employees);

        Mock.Get(_repository)
            .Setup(es => es.IsNull)
            .Returns(true);

        var _sut = new NorthwindService<Employee>(_repository);
        var result = await _sut.GetAllAsync();
        Assert.That(result, Is.Null);
        Assert.That(result.IsTrue);
    }

    [Category("Happy Path")]
    [Category("GetEmployee")]
    [Test]
    public async Task GivenThereAreEmployees_GetAsync_ReturnsCorrectEmployee()
    {
        Employee employee = new Employee()
        {

        };
        Mock
            .Get(_repository)
            .Setup(es => es.FindAsync(employee.EmployeeId).Result)
            .Returns(employee);

        Mock
            .Get(_repository)
            .Setup(es => es.IsNull)
            .Returns(false);

        var _sut = new NorthwindService<Employee>(_repository);
        var result = await _sut.FindAsync();
        Assert.That(result, Is.EqualTo(employee));
        Assert.That(result.IsNull.IsFalse);
    }

    [Category("Sad Path")]
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
}
