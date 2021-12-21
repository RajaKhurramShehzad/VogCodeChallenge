using System.Collections.Generic;

namespace AWSLambdaFunction.Object
{
    public class Log
    {
        public Log()
        {
            this.Messages = new List<string>();
        }

        public List<string> Messages { get;}
    }
}
