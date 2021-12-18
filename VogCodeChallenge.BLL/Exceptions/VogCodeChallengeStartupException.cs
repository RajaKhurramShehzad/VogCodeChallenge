using System;

namespace VogCodeChallenge.BLL.Extensions
{
    public class VogCodeChallengeStartupException : Exception
    {
        public VogCodeChallengeStartupException()
        {
        }

        public VogCodeChallengeStartupException(string message)
            : base(message)
        {
        }

        public VogCodeChallengeStartupException(Exception exception, string message)
           : base(message, exception)
        {
        }

        public VogCodeChallengeStartupException(string message, Exception exception)
          : base(message, exception)
        {
        }
    }
}
