using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using VogCodeChallenge.BLL.Config;
using VogCodeChallenge.BLL.Interfaces;
using VogCodeChallenge.BLL.Models;
using VogCodeChallenge.BLL.Services;

namespace VogCodeChallenge.BLL
{
    public class VogCodeChallengeAPIHandler : IVogCodeChallengeAPIHandler
    {
        private readonly ILogger logger;
        private readonly IVogCodeChallengeConfig vogCodeChallengeConfig;
        public VogCodeChallengeAPIHandler(IVogCodeChallengeConfig vogCodeChallengeConfig, ILogger<VogCodeChallengeAPIHandler> logger)
        {
            this.logger = logger;
            this.vogCodeChallengeConfig = vogCodeChallengeConfig;
        }

        public IEnumerable<Employee> GetAll()
        {
            string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
            this.logger.LogInformation($"Begin {methodName}");

            var employeeDataService = EmployeeDataServiceFactory.GetEmployeeDataService(this.vogCodeChallengeConfig.EnableDBConnectivity);
            var ret = employeeDataService.GetAll();

            this.logger.LogInformation($"End {methodName}");
            return ret;
        }

        public IEnumerable<Employee> GetAll(int departmentId)
        {
            string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
            this.logger.LogInformation($"Begin {methodName}");

            var employeeDataService = EmployeeDataServiceFactory.GetEmployeeDataService(this.vogCodeChallengeConfig.EnableDBConnectivity);
            var ret = employeeDataService.GetAll();

            this.logger.LogInformation($"End {methodName}");
            return ret;
        }

        public IList<Employee> ListAll()
        {
            string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
            this.logger.LogInformation($"Begin {methodName}");

            var employeeDataService = EmployeeDataServiceFactory.GetEmployeeDataService(this.vogCodeChallengeConfig.EnableDBConnectivity);
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
