using Amazon;
using Amazon.Lambda;
using Amazon.Lambda.Model;
using AWSLambdaFunction.Interfaces;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace AWSLambdaFunction.Services
{
    public class LambdaFunctionService : ILambdaFunctionService
    {
        private readonly ILogger logger;
        private readonly IAWSLambdaFunctionConfig awsLambdaFunctionConfig;
        public LambdaFunctionService(IAWSLambdaFunctionConfig awsLambdaFunctionConfig, ILogger<LambdaFunctionService> logger)
        {
            this.awsLambdaFunctionConfig = awsLambdaFunctionConfig;
            this.logger = logger;
        }

        public async Task<string> InvokeDynamoDbEventFunction()
        {
            string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
            this.logger.LogInformation($"Begin {methodName}");
            var lambdaClient = new AmazonLambdaClient(this.awsLambdaFunctionConfig.AWSKey, this.awsLambdaFunctionConfig.AWSSecret, RegionEndpoint.USEast1);

            var invokeRequest = new InvokeRequest
            {
                FunctionName = this.awsLambdaFunctionConfig.FunctionName,
                InvocationType = InvocationType.RequestResponse
            };

            var response = await lambdaClient.InvokeAsync(invokeRequest);
            this.logger.LogInformation($"End {methodName}");
            return response.LogResult;
        }
    }
}
