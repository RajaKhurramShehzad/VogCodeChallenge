using AWSLambdaFunction.Interfaces;

namespace AWSLambdaFunction.Config
{
    public class AWSLambdaFunctionConfig : IAWSLambdaFunctionConfig
    {
        public AWSLambdaFunctionConfig(string functionName, string awsKey, string awsSecret)
        {
            this.FunctionName = functionName;
            this.AWSKey = awsKey;
            this.AWSSecret = awsSecret;
        }
        public string FunctionName { get; set; }
        public string AWSKey { get; set; }
        public string AWSSecret { get; set; }
    }
}
