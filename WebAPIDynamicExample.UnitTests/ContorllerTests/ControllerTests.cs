using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Diagnostics.CodeAnalysis;
using WebAPIDynamicExample.Controllers;
using WebAPIDynamicExample.Managers.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebAPIDynamicExample.Models;
using System.Collections.Generic;

namespace WebAPIDynamicExample.UnitTests.ContorllerTests
{
    [ExcludeFromCodeCoverage]
    [TestClass]
    public class ControllerTests
    {
        private SpendingController SpendingCon { get; set; }
        private Mock<INYCSpendingDataManager> MockNYCSpendingDataManager { get; set; }

        [TestInitialize]
        public void Intialize()
        {
            // initialize the members of the controller
            // MockThing = new Mock<IThing>();
            // Thing = new Thing(MockThing.Object)
            // Initialize any test data here
            MockNYCSpendingDataManager = new Mock<INYCSpendingDataManager>();
            SpendingCon = new SpendingController(MockNYCSpendingDataManager.Object);
        }

        [TestMethod]
        public void Controller_Can_Be_Created()
        {
            Mock<INYCSpendingDataManager> m = new Mock<INYCSpendingDataManager>();
            SpendingController sc = new SpendingController(m.Object);

            Assert.IsNotNull(sc);
        }

        [TestMethod]
        public async Task GetSpendingData_BadRequest()
        {
            string x = string.Empty;
            var result = await SpendingCon.GetSpendingData(x);
            var badreq = result as BadRequestResult;

            Assert.IsInstanceOfType(badreq, typeof(BadRequestResult));

        }

        [TestMethod]
        public async Task GetSpendingData_NotFound()
        {
            string badyear = "1976";
            var result = await SpendingCon.GetSpendingData(badyear);
            var notfoundreq = result as NotFoundResult;

            Assert.IsInstanceOfType(notfoundreq, typeof(NotFoundResult));

        }

        [TestMethod]
        public async Task GetSpendingData_Success()
        {
            string goodyear = "2012";
            List<Expense> e = new List<Expense>() {
                new Expense
                {
                    Name="TestName", CheckAmount=100.00,  PayeeName="DeptX"
                }
            };
            MockNYCSpendingDataManager.Setup(x => x.GetSpendingData(It.IsAny<string>())).Returns(Task.FromResult(e));

            var result = await SpendingCon.GetSpendingData(goodyear);
            var goodreq = result as OkObjectResult;

            Assert.IsInstanceOfType(goodreq, typeof(OkObjectResult));

        }

    }
}
