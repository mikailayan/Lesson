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
        //Asl?nda asp.Net uygulamalar? bir console
        //uygulamas?d?r.
        public static void Main(string[] args)
        {
            //Buras? uygulaman?n ba?lang?? noktas?d?r.
            //B?t?n hikaye burada ba?l?yor.
            //Asp.Net Core sunucuyu aya?a kald?r?yor.
            //Bu i?i geriye IHostBuilder t?r?nden bir de?er d?nd?ren 
            //a?a??daki CreateHostBuilder metodunu kulanarak yap?yor.

            CreateHostBuilder(args).Build().Run();
        }
        // Bir sunucu aya?a kald?r??l?rken ?e?itli konfig?rasyonlara 
        //ihtiya? duyar i?te bu metotta da bu konfig?rasyonlar?n 
        //nereden al?naca?? belirtiliyor.
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    //sunucu Startup class?ndaki konfig?rasyonlar 
                    //kullan?larak aya?a kald?r?l?yor.
                    webBuilder.UseStartup<Startup>();
                });
    }
}
