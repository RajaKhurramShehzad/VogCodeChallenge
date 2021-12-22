namespace AWSLambdaFunction.Interfaces
{
    public interface  IAWSLambdaFunctionConfig
    {
       string FunctionName { get; set; }
       string AWSKey { get; set; }
       string AWSSecret { get; set; }

    }
}
