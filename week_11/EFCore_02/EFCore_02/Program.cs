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
        //EFCore ile oluşturacağımız EF projelerinde
        //EF.netframeworkte yaptığımız gibi sihirbaz ile 
        //EF'i projeye dahil demeyiz! Bunun için Kod YAZMALIYIZ!

        //Yazacağımız kod, context ve entity classlarını oluşturarak modelimiz yaratacak.
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
