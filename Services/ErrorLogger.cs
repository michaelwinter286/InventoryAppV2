using System;
using Serilog;

namespace InventorySystem.Services
{
    internal class ErrorLogger
    {
        public static void StartLogger()
        {
            //var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            //var parentDirectory = new DirectoryInfo(baseDirectory);

            //while (parentDirectory != null && parentDirectory.Name != "InventorySystemV2")
            //{
            //    parentDirectory = Directory.GetParent(parentDirectory.FullName);
            //}

            //var logPath = Path.Combine(parentDirectory?.FullName!, "ErrorLog.txt");

            Log.Logger = new LoggerConfiguration()
             .MinimumLevel.Debug()
             .WriteTo.File("errorlog.txt",
                outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}")

             .CreateLogger();
            
        }
    }
}
