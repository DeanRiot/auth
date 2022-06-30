using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace notify
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var sql_provider_name = Environment.GetEnvironmentVariable("PROVIDER_NAME");
            if (sql_provider_name is null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("PROVIDER_NAME enviroment var is misconfigured");
                Console.ForegroundColor = ConsoleColor.White;
                return;
            }

            string sql_cs = Environment.GetEnvironmentVariable(sql_provider_name);
            
            if (sql_cs is null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("DB Connection string enviroment var is misconfigured");
                Console.ForegroundColor = ConsoleColor.White;
                return;
            }

            if (Environment.GetEnvironmentVariable("MAIL_LOGIN") is null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("MAIL_LOGIN enviroment var is misconfigured");
                Console.ForegroundColor = ConsoleColor.White;
                return;
            }

            if (Environment.GetEnvironmentVariable("MAIL_PASSWORD") is null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("MAIL_PASSWORD enviroment var is misconfigured");
                Console.ForegroundColor = ConsoleColor.White;
                return;
            }

            if (Environment.GetEnvironmentVariable("SMS_COM_PORT") is null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("SMS_COM_PORT enviroment var is misconfigured");
                Console.ForegroundColor = ConsoleColor.White;
                return;
            }

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
