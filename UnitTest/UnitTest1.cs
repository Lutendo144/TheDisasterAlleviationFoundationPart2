using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestClass]
        public class HomeControllerTests
        {
            [TestMethod]
            public void DonationManager_Returns_ViewResult()
            {
                // Arrange
                var loggerMock = new Mock<ILogger<HomeController>>();
                var donationManagerMock = new Mock<IDonationManager>();
                var controller = new HomeController(loggerMock.Object, donationManagerMock.Object);

                // Act
                var result = controller.DonationManager();

                // Assert
                Assert.IsInstanceOfType(result, typeof(ViewResult));
            }
        }
    }