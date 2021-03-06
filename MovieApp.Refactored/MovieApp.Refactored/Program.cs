using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApp.Refactored
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var loggingPath = $@"{AppDomain.CurrentDomain.BaseDirectory}Logs\Notes_LOG_{DateTime.UtcNow.Date:dd-MM-yyyy}.txt";

            Log.Logger = new LoggerConfiguration()
                                .Enrich.FromLogContext()
                                .MinimumLevel.Information()
                                .WriteTo.RollingFile(loggingPath, LogEventLevel.Information,
                                    "{NewLine}{Timestamp:HH:mm:ss} [{Level}] ({CorrelationToken}) {Message}{NewLine}{Exception}")
                                .CreateLogger();
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                }).UseSerilog();
    }
}
