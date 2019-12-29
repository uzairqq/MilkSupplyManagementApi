using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;

namespace MilkManagement.Api
{
    public class Program
    {
        public static int Main(string[] args)
        {
            //    Log.Logger = new LoggerConfiguration()
            //        .MinimumLevel.Debug()
            //        .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
            //        .Enrich.FromLogContext()
            //        .WriteTo.Console()
            //        .CreateLogger();

            //    try
            //    {
            //        Log.Information("Starting web host");
            //        CreateWebHostBuilder(args).Run();
            //        return 0;
            //    }
            //    catch (Exception ex)
            //    {
            //        Log.Fatal(ex, "Host terminated unexpectedly");
            //        return 1;
            //    }
            //    finally
            //    {
            //        Log.CloseAndFlush();
            //    }

            //}


            //public static IWebHost CreateWebHostBuilder(string[] args) =>
            //    WebHost.CreateDefaultBuilder(args)
            //        .UseStartup<Startup>()
            //        .UseSerilog()
            //        .Build();


            Console.Title = "API";

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .CreateLogger();

            try
            {
                Log.Information("Starting web host");
                var builder = CreateWebHostBuilder(args);
                builder.Build().Run();
                return 0;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Host terminated unexpectedly");
                return 1;
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }


        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseSerilog();
    }
}