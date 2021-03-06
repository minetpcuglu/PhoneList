using Autofac;
using Autofac.Extensions.DependencyInjection;
using BusinessLayer.Utilities.IoC;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneListWebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
             Host.CreateDefaultBuilder(args)

             .UseServiceProviderFactory(new AutofacServiceProviderFactory()) // projenin ya?am s?relerini autofac ile belle?e kaydetme 
             .ConfigureContainer<ContainerBuilder>(builder =>
             {
                 builder.RegisterModule(new RepositoryModule());
             })
                 .ConfigureWebHostDefaults(webBuilder =>
                 {
                     webBuilder.UseStartup<Startup>();
                 });
    }
}
