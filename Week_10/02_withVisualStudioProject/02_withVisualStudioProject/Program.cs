using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _02_withVisualStudioProject
{
    public class Program 
    {
        //Aslýnda asp.Net uygulamalarý bir console
        //uygulamasýdýr.
        public static void Main(string[] args)
        {
            //Burasý uygulamanýn baþlangýç noktasýdýr.
            //Bütün hikaye burada baþlýyor.
            //Asp.Net Core sunucuyu ayaða kaldýrýyor.
            //Bu iþi geriye IHostBuilder türünden bir deðer döndüren 
            //aþaðýdaki CreateHostBuilder metodunu kulanarak yapýyor.

            CreateHostBuilder(args).Build().Run();
        }
        // Bir sunucu ayaða kaldýrýýlýrken çeþitli konfigürasyonlara 
        //ihtiyaç duyar iþte bu metotta da bu konfigürasyonlarýn 
        //nereden alýnacaðý belirtiliyor.
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    //sunucu Startup classýndaki konfigürasyonlar 
                    //kullanýlarak ayaða kaldýrýlýyor.
                    webBuilder.UseStartup<Startup>();
                });
    }
}
