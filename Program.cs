using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Hosting.WindowsServices;

namespace mvcApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // var config = new ConfigurationBuilder()
            //    .SetBasePath(Directory.GetCurrentDirectory())
            //    .AddJsonFile("hosting.json", true)
            //    .Build();

            //BuildWebHost(args, config).Run();
             BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args /*, IConfiguration config*/) =>
            WebHost.CreateDefaultBuilder(args)
                .UseKestrel()
                .UseUrls("http://*:5001", "http://*:5002")
                //  .UseConfiguration(config)
                //.UseHttpSys()
                // .UseIISIntegration()
                .UseStartup<Startup>()
                .Build();
    }
}
