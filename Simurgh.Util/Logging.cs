using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.Extensions.Logging
{
    public static class MyLoggingExtentions
    {
        public static ILogger LogEntrance(this ILogger logger, string methodName, string data = null)
        {
            logger.LogInformation($"Entered method : {methodName} > {data}");

            return logger;
        }

        public static ILogger LogExit(this ILogger logger, string methodName, string data = null)
        {
            logger.LogInformation($"Exited method : {methodName} > {data}");

            return logger;
        }
    }
}
