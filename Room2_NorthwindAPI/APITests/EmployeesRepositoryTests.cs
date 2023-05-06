using Microsoft.EntityFrameworkCore;
using Room2_NorthwindAPI.Data.Repository;
using Room2_NorthwindAPI.Models;

namespace APITests
{
    public class RepoTests
    {
        private EmployeesRepository _sut;
        private NorthwindContext _context;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            var options = new DbContextOptionsBuilder<NorthwindContext>()
                .UseInMemoryDatabase(databaseName: "NorthwindDB")
                .Options;

            _context = new NorthwindContext(options);
            _sut = new EmployeesRepository(_context);
        }

        [SetUp]
        public void Setup()
        {
            _context.Employees.RemoveRange(_context.Employees);
            _context.SaveChanges();

            _context.Employees.AddRange(
                new List<Employee>
                {
                    new Employee
                    {
                        EmployeeId = 1,
                        FirstName = "John",
                        LastName = "Doe",
                        Title = "Manager",
                    },
                    new Employee
                    {
                        EmployeeId = 2,
                        FirstName = "Jane",
                        LastName = "Doe",
                        Title = "Assistant Manager",
                    },
                });

            _context.SaveChanges();
        }

        [Category("Happy Path")]
        [Category("Find Async")]
        [Test]
        public void FindAsync_GivenValidID_ReturnsCorrectEmployee()
        {
            // Arrange
            int validEmployeeId = 1;

            // Act
            var result = _sut.FindAsync(validEmployeeId).Result;

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf<Employee>());
            Assert.That(result.EmployeeId, Is.EqualTo(validEmployeeId));
            Assert.That(result.FirstName, Is.EqualTo("John"));
        }

        [Category("Sad Path")]
        [Category("Find Async")]
        [Test]
        public void FindAsync_GivenInvalidID_ReturnsNull()
        {
            // Arrange
            int invalidEmployeeId = 1000;

            // Act
            var result = _sut.FindAsync(invalidEmployeeId).Result;

            // Assert
            Assert.That(result, Is.Null);
        }

        [Category("Happy Path")]
        [Category("GetAllAsync")]
        [Test]
        public void GetAllAsync_GivenEmployeesIsNotNull_ReturnsList()
        {
            // Act
            var result = _sut.GetAllAsync().Result;

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf<List<Employee>>());
            Assert.That(result.Count, Is.EqualTo(2));
        }

        [Category("Sad Path")]
        [Category("GetAllAsync")]
        [Test]
        public void GetAllAsync_GivenEmployeesIsNull_ReturnsListOfCount0()
        {
            // Arrange
            _context.Employees.RemoveRange(_context.Employees);
            _context.SaveChanges();

            // Act
            var result = _sut.GetAllAsync().Result;

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf<List<Employee>>());
            Assert.That(result.Count, Is.EqualTo(0));
        }
    }
}
