using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using VogCodeChallenge.BLL;
using VogCodeChallenge.BLL.Config;
using VogCodeChallenge.BLL.Interfaces;
using VogCodeChallenge.BLL.Models;

namespace VogCodeChallenge.Tests
{
    [TestClass]
    public class VogCodeChallengeAPIHandlerUnitTests
    {
        [TestMethod]
        public void ListAll_Good()
        {

            var employees = new Employee[]
            {

                    new Employee {FirstName="James Wadje", LastName="Butt", JobTitle = "technician" , Address = "6649 N Blue Gum St,New Orleans, LA, 70116",  DepartmentId = 1},
                    new Employee {FirstName="Nickolas", LastName="Juvera", JobTitle = "supervisor " , Address = "62 W Austin St,Syosset, NY, 11791",  DepartmentId = 2},
            };

            var logger = new NullLogger<VogCodeChallengeAPIHandler>();
            var vogCodeChallengeConfig = new Mock<IVogCodeChallengeConfig>();
            var employeeMemoryService = new Mock<IEmployeeService>();
            employeeMemoryService.Setup(dbs => dbs.ListAll()).Returns(employees);
            var employeeDataServiceFactory = new Mock<IEmployeeDataServiceFactory>();
            employeeDataServiceFactory.Setup(dbs => dbs.GetEmployeeDataService(It.IsAny<bool>())).Returns(employeeMemoryService.Object);

            var vogCodeChallengeAPIHandler = new VogCodeChallengeAPIHandler(employeeDataServiceFactory.Object,vogCodeChallengeConfig.Object, logger );

            var ret = vogCodeChallengeAPIHandler.ListAll();

            Assert.IsNotNull(ret);
            Assert.AreEqual(ret.Count.ToString(), "2");
            Assert.AreEqual(ret[0].FirstName, "James Wadje");
            Assert.AreEqual(ret[0].LastName, "Butt");
            Assert.AreEqual(ret[0].JobTitle, "technician");
            Assert.AreEqual(ret[0].Address, "6649 N Blue Gum St,New Orleans, LA, 70116");
            Assert.AreEqual(ret[0].DepartmentId.ToString(), "1");
            Assert.AreEqual(ret[0].FirstName, "Nickolas");
            Assert.AreEqual(ret[0].LastName, "Juvera");
            Assert.AreEqual(ret[0].JobTitle, "supervisor");
            Assert.AreEqual(ret[0].Address, "62 W Austin St,Syosset, NY, 11791");
            Assert.AreEqual(ret[0].DepartmentId.ToString(), "2");




        }
    }
}
