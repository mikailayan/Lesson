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
            //Bu uygulamada kullanlacak olan servislerin belirlendi�i 
            //metottur.
            //Service demek belli bir yak�m i�leri yapmak i�in kodlar�n
            //i�inde bulundu�u yap�lard�r. Mod�l,K�t�phane gibi d���nebilirsiniz.
        }

       
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //Bu metot uygulamada kullan�lacak olan ara katmanlar�n 
            //belirtildi�i metottur. Ara katman MiddleWare ad�yla da 
            //bilinir..
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            // Bu MiddleWare routing i�lemini devreye al�r.
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
