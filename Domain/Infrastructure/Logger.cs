using System;

namespace VueDemo.Domain.Infrastructure
{
    public static class Logger
    {
        public static void LogException(Exception ex)
        {
            throw ex;
            // a rea app would do something more meaningful.
        }
    }
}
