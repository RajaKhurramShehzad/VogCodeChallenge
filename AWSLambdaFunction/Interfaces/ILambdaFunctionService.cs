using System.Threading.Tasks;

namespace AWSLambdaFunction.Interfaces
{
    public interface ILambdaFunctionService
    {
        Task<string> InvokeDynamoDbEventFunction();
    }
}
