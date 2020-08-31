using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace WebApplication1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHost(webBuilder =>
                {
                    webBuilder
                    .UseKestrel(option =>
                    {
                        option.Listen(IPAddress.Loopback, 5001);
                        option.Listen(IPAddress.Loopback, 5002, listenOption =>
                        {
                            listenOption.UseHttps("/home/seanzhu/.dotnet/corefx/cryptography/x509stores/my/F956142EDC8E0E62EC5BCE91989E9877ABD8FE02.pfx");
                        });
                    })
                    .UseStartup<Startup>();
                });
    }
}
