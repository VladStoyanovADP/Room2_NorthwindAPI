using Room2_NorthwindAPI.Models;
using Room2_NorthwindAPI.Data.Repositories;
using Room2_NorthwindAPI.Services;
using Moq;
using Microsoft.Extensions.Logging;

namespace APITests
{
    [TestFixture]
    public class EmployeeServiceTests
    {
        private EmployeeService _employeeService;
        private Mock<INorthwindRepository<Employee>> _employeeRepositoryMock;
        private Mock<ILogger<EmployeeService>> _loggerMock;

        [SetUp]
        public void SetUp()
        {
            _employeeRepositoryMock = new Mock<INorthwindRepository<Employee>>();
            _loggerMock = new Mock<ILogger<EmployeeService>>();
            _employeeService = new EmployeeService(_loggerMock.Object, _employeeRepositoryMock.Object);
        }

        [Category("Happy Path")]
        [Category("GetEmployees")]
        [Test]
        public async Task GivenThereAreEmployees_GetAllAsync_ReturnsAllEmployeesEntries()
        {
            var repositoryMock = new Mock<INorthwindRepository<Employee>>();
            List<Employee> employees = new List<Employee> { new Employee() };
            _employeeRepositoryMock.Setup(es => es.GetAllAsync()).ReturnsAsync(employees);
            _employeeRepositoryMock.Setup(es => es.IsNull).Returns(false);

            var sut = new EmployeeService(_loggerMock.Object, _employeeRepositoryMock.Object);
            var result = await sut.GetAllAsync();
            Assert.That(result, Is.EqualTo(employees));
        }

        [Category("Sad Path")]
        [Category("GetEmployees")]
        [Test]
        public async Task GivenThereAreNotEmployees_GetAllAsync_ReturnsNull()
        {
            var repositoryMock = new Mock<INorthwindRepository<Employee>>();
            List<Employee> employees = new List<Employee>();

            _employeeRepositoryMock.Setup(es => es.GetAllAsync()).ReturnsAsync(employees);
            _employeeRepositoryMock.Setup(es => es.IsNull).Returns(true);

            var sut = new EmployeeService(_loggerMock.Object, _employeeRepositoryMock.Object);
            var result = await sut.GetAllAsync();
            Assert.That(result, Is.Null);
        }

        [Category("Happy Path")]
        [Category("GetEmployee")]
        [Test]
        public async Task GivenThereAreEmployees_GetAsync_ReturnsCorrectEmployee()
        {
            var employee = new Employee
            {
                EmployeeId = 55,
                LastName = "Bloggs",
                FirstName = "Dave",
                Title = "Head Of Science things",
                TitleOfCourtesy = "Mr"
            };
            _employeeRepositoryMock.Setup(repo => repo.FindAsync(employee.EmployeeId)).ReturnsAsync(employee);

            var result = await _employeeService.GetAsync(employee.EmployeeId);

            Assert.That(result, Is.EqualTo(employee));
            Assert.That(result.EmployeeId, Is.EqualTo(55));
            Assert.That(result.LastName, Is.EqualTo("Bloggs"));
            Assert.That(result.FirstName, Is.EqualTo("Dave"));
            Assert.That(result.Title, Is.EqualTo("Head Of Science things"));
            Assert.That(result.TitleOfCourtesy, Is.EqualTo("Mr"));
        }

        [Category("Sad Path")]
        [Category("UpdateEmployee")]
        [Test]
        public async Task UpdateAsync_ShouldReturnFalse_WhenEmployeeNotFound()
        {
            // Arrange
            int id = 1;
            Employee employee = new Employee();

            _employeeRepositoryMock.Setup(repo => repo.FindAsync(id)).ReturnsAsync((Employee)null);

            // Act
            bool result = await _employeeService.UpdateAsync(id, employee);

            // Assert
            Assert.False(result);
        }

        [Category("Happy Path")]
        [Category("UpdateEmployee")]
        [Test]
        public async Task UpdateAsync_ShouldReturnTrue_WhenEmployeeFound()
        {
            // Arrange
            int id = 1;
            Employee employee = new Employee();

            _employeeRepositoryMock.Setup(repo => repo.FindAsync(id)).ReturnsAsync(new Employee());

            // Act
            bool result = await _employeeService.UpdateAsync(id, employee);

            // Assert
            Assert.True(result);
        }

        [Category("Sad Path")]
        [Category("DeleteEmployee")]
        [Test]
        public async Task DeleteAsync_ShouldReturnFalse_WhenEmployeeNotFound()
        {
            // Arrange
            int id = 1;

            _employeeRepositoryMock.Setup(repo => repo.FindAsync(id)).ReturnsAsync((Employee)null);

            // Act
            bool result = await _employeeService.DeleteAsync(id);

            // Assert
            Assert.False(result);
        }

        [Category("Happy Path")]
        [Category("DeleteEmployee")]
        [Test]
        public async Task DeleteAsync_ShouldReturnTrue_WhenEmployeeFound()
        {
            // Arrange
            int id = 1;

            _employeeRepositoryMock.Setup(repo => repo.FindAsync(id)).ReturnsAsync(new Employee());

            // Act
            bool result = await _employeeService.DeleteAsync(id);

            // Assert
            Assert.True(result);
        }

        [Category("Happy Path")]
        [Category("CreateEmployee")]
        [Test]
        public async Task CreateAsync_ShouldReturnTrue_WhenEmployeeIsAdded()
        {
            // Arrange
            Employee employee = new Employee();

            _employeeRepositoryMock.Setup(repo => repo.Add(employee));
            _employeeRepositoryMock.Setup(repo => repo.SaveAsync()).Returns(Task.FromResult(true));

            // Act
            bool result = await _employeeService.CreateAsync(employee);

            // Assert
            Assert.True(result);
        }
    }
}
