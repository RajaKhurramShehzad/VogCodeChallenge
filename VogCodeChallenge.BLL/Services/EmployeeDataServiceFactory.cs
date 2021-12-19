using Microsoft.Extensions.Logging;
using VogCodeChallenge.BLL.Interfaces;

namespace VogCodeChallenge.BLL.Services
{
    public class EmployeeDataServiceFactory : IEmployeeDataServiceFactory
    {
        private readonly ILogger logger;

        public EmployeeDataServiceFactory(ILogger<EmployeeDataServiceFactory> logger)
        {
            this.logger = logger;
        }
        public IEmployeeService GetEmployeeDataService(bool enableDBConnectivity)
        {
            string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
            this.logger.LogInformation($"Begin {methodName}");

            IEmployeeService ret;
            if (enableDBConnectivity)
            {
                ret = new EmployeeDataBaseService();
            }
            else
            {
                ret = new EmployeeMemoryService();
            }

            this.logger.LogInformation($"End {methodName}");
            return ret;
        }
    }
}
