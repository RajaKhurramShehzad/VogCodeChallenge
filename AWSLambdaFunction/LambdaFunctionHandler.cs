using AWSLambdaFunction.Interfaces;
using AWSLambdaFunction.Object;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AWSLambdaFunction
{
    public class LambdaFunctionHandler : ILambdaFunctionHandler
    {
        private readonly ILogger logger;
        private readonly IAWSLambdaFunctionConfig awsLambdaFunctionConfig;
        private readonly ILambdaFunctionService lambdaFunctionService;
        public LambdaFunctionHandler(ILambdaFunctionService lambdaFunctionService, IAWSLambdaFunctionConfig awsLambdaFunctionConfig, ILogger<LambdaFunctionHandler> logger)
        {
            this.awsLambdaFunctionConfig = awsLambdaFunctionConfig;
            this.lambdaFunctionService = lambdaFunctionService;
            this.logger = logger;
        }

        public async Task<List<Log>> RunLambdaFunction()
        {
            string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
            this.logger.LogInformation($"Begin {methodName}");
            var ret = await this.lambdaFunctionService.InvokeDynamoDbEventFunction();
            var result = JsonConvert.DeserializeObject<List<Log>>(ret);
            this.logger.LogInformation($"End {methodName}");
            return result;

        }
    }
}
