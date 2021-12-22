using AWSLambdaFunction.Object;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AWSLambdaFunction.Interfaces
{
    public interface ILambdaFunctionHandler
    {
        Task<List<Log>> RunLambdaFunction();
    }
}
