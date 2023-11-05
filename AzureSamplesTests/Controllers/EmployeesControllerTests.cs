using AzureSamples.Controllers;
using AzureSamples.Models;
using FakeItEasy;
using System;
using System.Threading.Tasks;
using Xunit;

namespace AzureSamplesTests.Controllers
{
    public class EmployeesControllerTests
    {
        private AzureSamplesDBContext fakeAzureSamplesDBContext;

        public EmployeesControllerTests()
        {
            this.fakeAzureSamplesDBContext = A.Fake<AzureSamplesDBContext>();
        }

        private EmployeesController CreateEmployeesController()
        {
            return new EmployeesController(
                this.fakeAzureSamplesDBContext);
        }

        [Fact]
        public async Task Index_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var employeesController = this.CreateEmployeesController();

            // Act
            var result = await employeesController.Index();

            // Assert
            Assert.True(false);
        }

        [Fact]
        public async Task Details_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var employeesController = this.CreateEmployeesController();
            int? id = null;

            // Act
            var result = await employeesController.Details(
                id);

            // Assert
            Assert.True(false);
        }

        [Fact]
        public void Create_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var employeesController = this.CreateEmployeesController();

            // Act
            var result = employeesController.Create();

            // Assert
            Assert.True(false);
        }

        [Fact]
        public async Task Create_StateUnderTest_ExpectedBehavior1()
        {
            // Arrange
            var employeesController = this.CreateEmployeesController();
            Employee employee = null;

            // Act
            var result = await employeesController.Create(
                employee);

            // Assert
            Assert.True(false);
        }

        [Fact]
        public async Task Edit_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var employeesController = this.CreateEmployeesController();
            int? id = null;

            // Act
            var result = await employeesController.Edit(
                id);

            // Assert
            Assert.True(false);
        }

        [Fact]
        public async Task Edit_StateUnderTest_ExpectedBehavior1()
        {
            // Arrange
            var employeesController = this.CreateEmployeesController();
            int id = 0;
            Employee employee = null;

            // Act
            var result = await employeesController.Edit(
                id,
                employee);

            // Assert
            Assert.True(false);
        }

        [Fact]
        public async Task Delete_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var employeesController = this.CreateEmployeesController();
            int? id = null;

            // Act
            var result = await employeesController.Delete(
                id);

            // Assert
            Assert.True(false);
        }

        [Fact]
        public async Task DeleteConfirmed_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var employeesController = this.CreateEmployeesController();
            int id = 0;

            // Act
            var result = await employeesController.DeleteConfirmed(
                id);

            // Assert
            Assert.True(false);
        }
    }
}
