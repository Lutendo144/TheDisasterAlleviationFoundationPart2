using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using TheDisasterAlleviationFoundationPart2.Controllers;
using TheDisasterAlleviationFoundationPart2.Models;
using Xunit.Sdk;

namespace UnitTesting
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]

        public void DonationManager_Returns_ViewResult()
        {
            // Arrange
            var loggerMock = new Mock<ILogger<HomeController>>();

            // Create a mock of DonationManager or instantiate a real one as needed
            var donationManagerMock = new Mock<DonationManager>();

           

            // Act
            ActionResult result = (ActionResult)controller.DonationManager();

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }
    }
}

