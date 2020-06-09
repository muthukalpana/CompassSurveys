using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace CompassSurveys
{

    /// <summary>  
    /// Program.  
    /// </summary> 

    public class Program
    {

        /// <summary>  
        /// Main.  
        /// </summary> 
        /// <param name="args"></param>

        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        /// <summary>  
        /// CreateHostBuilder.  
        /// </summary> 
        /// <param name="args"></param>

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}