using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using VogCodeChallenge.BLL.Interfaces;
using VogCodeChallenge.BLL.Objects;

namespace VogCodeChallenge.BLL
{
    public class VogCodeChallengeAPIHandler : IVogCodeChallengeAPIHandler
    {
        private readonly ILogger logger;
        public VogCodeChallengeAPIHandler(ILogger<VogCodeChallengeAPIHandler> logger)
        {
            this.logger = logger;
        }

        public IEnumerable<Employee> GetAll()
        {
            string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
            this.logger.LogInformation($"Begin {methodName}");

            throw new System.NotImplementedException();

            this.logger.LogInformation($"End {methodName}");
        }

        public IList<Employee> ListAll()
        {
            string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
            this.logger.LogInformation($"Begin {methodName}");

            throw new System.NotImplementedException();

            this.logger.LogInformation($"End {methodName}");
        }
    }
}
