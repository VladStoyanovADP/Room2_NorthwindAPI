using Microsoft.AspNetCore.Mvc;
using Moq;
using Room2_NorthwindAPI.Controllers;
using Room2_NorthwindAPI.Models;
using Room2_NorthwindAPI.Services;

namespace APITests;

internal class ControllerTests
{
    [Test]
    public async Task GivenAValidEmployee_PostEmployee_InsertsEmployee()
    {
        // Arrange
        var mockService = new Mock<INorthwindService<Employee>>();
        mockService.Setup(es => es.CreateAsync(It.IsAny<Employee>()).Result)
            .Returns(true);
        var _sut = new EmployeesController(mockService.Object);

        // Act
        var result = await _sut.PostEmployee(new Employee());

        // Assert
        Assert.That(result.Result, Is.InstanceOf<CreatedAtActionResult>());
    }

    [Test]
    public async Task GivenInvalidEmployee_PostEmployee_ReturnsProblem()
    {
        // Arrange
        var mockService = new Mock<INorthwindService<Employee>>();
        mockService.Setup(es => es.CreateAsync(It.IsAny<Employee>()).Result)
            .Returns(false);
        var _sut = new EmployeesController(mockService.Object);

        // Act
        var result = await _sut.PostEmployee(new Employee());

        // Assert
        Assert.That(result, Is.TypeOf<ActionResult<Employee>>());
        Assert.That(result.Result, Is.TypeOf<BadRequestResult>());
    }

    [Test]
    public async Task GivenValidIdAndEmployee_PutEmployeeDetails_UpdatesEmployee()
    {
        // Arrange
        var mockEmployeeService = new Mock<INorthwindService<Employee>>();
        int id = 1;
        var employee = new Employee
        {
            EmployeeId = 1,
            FirstName = "John",
            LastName = "Doe",
            Title = "Manager",
            Address = "67 Unicorn Street",
            City = "Stoke-on-Trent",
            PostalCode = "LE5 0SJ",
            Country = "UK"
        };
        mockEmployeeService.Setup(cs => cs.UpdateAsync(id, employee))
            .ReturnsAsync(true);
        var sut = new EmployeesController(mockEmployeeService.Object);

        // Act
        var result = await sut.PutEmployee(id, employee);

        // Assert
        mockEmployeeService.Verify(cs => cs.UpdateAsync(id, employee), Times.Once);
        Assert.IsInstanceOf<NoContentResult>(result);
    }

    [Category("Happy Path")]
    [Category("DeleteEmployee")]
    [Test]
    public async Task DeleteEmployee_GivenAValidId_ReturnsNoContent()
    {
        // Arrange
        int id = 1;
        var mockEmployeeService = new Mock<INorthwindService<Employee>>();
        mockEmployeeService.Setup(es => es.DeleteAsync(id).Result)
            .Returns(true);
        mockEmployeeService.Setup(es => es.GetAsync(id).Result)
            .Returns(new Employee());
        var sut = new EmployeesController(mockEmployeeService.Object);

        // Act
        var result = await sut.DeleteEmployee(id);

        // Assert
        Assert.That(result, Is.TypeOf<NoContentResult>());
        mockEmployeeService.Verify(es => es.DeleteAsync(id), Times.Once);
        mockEmployeeService.Verify(es => es.GetAsync(id), Times.Once);
    }

    [Category("Sad Path")]
    [Category("DeleteEmployee")]
    [Test]
    public async Task DeleteEmployee_GivenAnInvalidId_ReturnsNotFound()
    {
        // Arrange
        int id = 1;
        var mockEmployeeService = new Mock<INorthwindService<Employee>>();
        mockEmployeeService.Setup(es => es.DeleteAsync(id).Result)
            .Returns(false);
        var sut = new EmployeesController(mockEmployeeService.Object);

        // Act
        var result = await sut.DeleteEmployee(id);

        // Assert
        Assert.That(result, Is.TypeOf<NotFoundResult>());
    }
}
