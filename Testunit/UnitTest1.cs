using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using TheDisasterAlleviationFoundationPart2.Controllers;
using TheDisasterAlleviationFoundationPart2.Models;

namespace Testunit
{
    public class UnitTest1
    {
        [Fact]
        public void DonationManager()
        {
            // Arrange
            var loggerMock = new Mock<ILogger<HomeController>>();


            // Create a mock GoodsAllocationModel or instantiate a real one as needed
            //var DonationManagerModelMock = new Mock<DonationManager>();

            HomeController controller = new HomeController(loggerMock.Object);

            // Act
            IActionResult result = controller.DonationManager();

            // Assert using xUnit's Assert
            Xunit.Assert.IsType<ViewResult>(result);
        }


        [Fact]
        public void Purchase()
        {
           
            var loggerMock = new Mock<ILogger<HomeController>>();

            var PurchaseModelMock = new Mock<Purchase>();

            HomeController controller = new HomeController(loggerMock.Object);

            IActionResult result = controller.Purchase();

            Xunit.Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void GoodsAllocation()
        {

            var loggerMock = new Mock<ILogger<HomeController>>();

            var GoodsAllocationModelMock = new Mock<GoodsAllocation>();

            HomeController controller = new HomeController(loggerMock.Object);

            IActionResult result = controller.GoodsAllocation();

            Xunit.Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void Allocation()
        {

            var loggerMock = new Mock<ILogger<HomeController>>();

            var AllocationModelMock = new Mock<Allocation>();

            HomeController controller = new HomeController(loggerMock.Object);

            IActionResult result = controller.Allocation();

            Xunit.Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void Disasters()
        {

            var loggerMock = new Mock<ILogger<HomeController>>();

            var DisastersModelMock = new Mock<Disasters>();

            HomeController controller = new HomeController(loggerMock.Object);

            IActionResult result = controller.Disasters();

            Xunit.Assert.IsType<ViewResult>(result);
        }
    }
}
