using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore_02
{
    public class Program
    {
        //EFCore ile olu�turaca��m�z EF projelerinde
        //EF.netframeworkte yapt���m�z gibi sihirbaz ile 
        //EF'i projeye dahil demeyiz! Bunun i�in Kod YAZMALIYIZ!

        //Yazaca��m�z kod, context ve entity classlar�n� olu�turarak modelimiz yaratacak.
        public static void Main(string[] args)
        {
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
