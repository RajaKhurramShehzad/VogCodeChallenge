using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using VogCodeChallenge.BLL.Config;
using VogCodeChallenge.BLL.Interfaces;
using VogCodeChallenge.BLL.Models;

namespace VogCodeChallenge.BLL
{
    public class VogCodeChallengeAPIHandler : IVogCodeChallengeAPIHandler
    {
        private readonly ILogger logger;
        private readonly IVogCodeChallengeConfig vogCodeChallengeConfig;
        private readonly IEmployeeDataServiceFactory employeeDataServiceFactory;
        public VogCodeChallengeAPIHandler(IEmployeeDataServiceFactory employeeDataServiceFactory, IVogCodeChallengeConfig vogCodeChallengeConfig, ILogger<VogCodeChallengeAPIHandler> logger)
        {
            this.employeeDataServiceFactory = employeeDataServiceFactory;
            this.vogCodeChallengeConfig = vogCodeChallengeConfig;
            this.logger = logger;
        }

        public IEnumerable<Employee> GetAll()
        {
            string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
            this.logger.LogInformation($"Begin {methodName}");

            var employeeDataService = this.employeeDataServiceFactory.GetEmployeeDataService(this.vogCodeChallengeConfig.EnableDBConnectivity);
            var ret = employeeDataService.GetAll();

            this.logger.LogInformation($"End {methodName}");
            return ret;
        }

        public IEnumerable<Employee> GetAll(int departmentId)
        {
            string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
            this.logger.LogInformation($"Begin {methodName}");

            var employeeDataService = this.employeeDataServiceFactory.GetEmployeeDataService(this.vogCodeChallengeConfig.EnableDBConnectivity);
            var ret = employeeDataService.GetAll();

            this.logger.LogInformation($"End {methodName}");
            return ret;
        }

        public IList<Employee> ListAll()
        {
            string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
            this.logger.LogInformation($"Begin {methodName}");

            var employeeDataService = this.employeeDataServiceFactory.GetEmployeeDataService(this.vogCodeChallengeConfig.EnableDBConnectivity);
            var ret = employeeDataService.ListAll();

            this.logger.LogInformation($"End {methodName}");
            return ret;
        }

        public IList<Employee> ListAll(int departmentId)
        {
            throw new System.NotImplementedException();
        }
    }
}
