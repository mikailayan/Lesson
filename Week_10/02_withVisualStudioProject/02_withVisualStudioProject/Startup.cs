using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _02_withVisualStudioProject
{
    public class Startup
    {

       
        public void ConfigureServices(IServiceCollection services)
        {
            //Bu uygulamada kullanlacak olan servislerin belirlendiði 
            //metottur.
            //Service demek belli bir yakým iþleri yapmak için kodlarýn
            //içinde bulunduðu yapýlardýr. Modül,Kütüphane gibi düþünebilirsiniz.
        }

       
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //Bu metot uygulamada kullanýlacak olan ara katmanlarýn 
            //belirtildiði metottur. Ara katman MiddleWare adýyla da 
            //bilinir..
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            // Bu MiddleWare routing iþlemini devreye alýr.
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
            });
        }
    }
}
