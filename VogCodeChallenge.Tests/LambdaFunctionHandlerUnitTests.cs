using AWSLambdaFunction;
using AWSLambdaFunction.Interfaces;
using AWSLambdaFunction.Object;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace VogCodeChallenge.Tests
{
    [TestClass]
    public class LambdaFunctionHandlerUnitTests
    {
        [TestMethod]
        public void  RunLambdaFunction()
        {

            var log = new Log();
            log.Messages.Add("message");
            log.Messages.Add("message2");
            var ret = JsonConvert.SerializeObject(log);

            var logger = new NullLogger<LambdaFunctionHandler>();
            var awsLambdaFunctionConfig = new Mock<IAWSLambdaFunctionConfig>();
            var lambdaFunctionService = new Mock<ILambdaFunctionService>();
            lambdaFunctionService.Setup(x => x.InvokeDynamoDbEventFunction()).Returns(Task.FromResult(ret));

            var lambdaFunctionHandler = new LambdaFunctionHandler(lambdaFunctionService.Object, awsLambdaFunctionConfig.Object, logger);

            var response = lambdaFunctionHandler.RunLambdaFunction();

            Assert.IsNotNull(response);
        }
    }
}
