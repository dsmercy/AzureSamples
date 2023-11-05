using AzureSamples.Controllers;
using FakeItEasy;
using Microsoft.Extensions.Logging;
using System;
using Xunit;

namespace AzureSamplesTests.Controllers
{
    public class HomeControllerTests
    {
        private ILogger<HomeController> fakeLogger;

        public HomeControllerTests()
        {
            this.fakeLogger = A.Fake<ILogger<HomeController>>();
        }

        private HomeController CreateHomeController()
        {
            return new HomeController(
                this.fakeLogger);
        }

        [Fact]
        public void Index_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var homeController = this.CreateHomeController();

            // Act
            var result = homeController.Index();

            // Assert
            Assert.True(false);
        }

        [Fact]
        public void Privacy_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var homeController = this.CreateHomeController();

            // Act
            var result = homeController.Privacy();

            // Assert
            Assert.True(false);
        }

        [Fact]
        public void Error_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var homeController = this.CreateHomeController();

            // Act
            var result = homeController.Error();

            // Assert
            Assert.True(false);
        }
    }
}
