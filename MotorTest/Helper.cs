using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Serilog;

namespace MotorTest
{
    public static class Helper
    {

        public static void Create()
        {
            Log.Logger = new LoggerConfiguration()
           .MinimumLevel.Debug()
           .WriteTo.Console()
           .WriteTo.File("logs/myapp.txt", rollingInterval: RollingInterval.Day)
           .CreateLogger();
            Log.Information("Hello, world!");
        }

        public static void Test()
        {
            Log.Information("Hello, world!");
        }
    }
}
