using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _03_Mvc_01
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //bu servisi ekleyerek uygulamamýzýn mvc mimarisini 
            //kullanacaðýný belirtmiþ olduk.
            //Dolayýsýyla artýk bu uygulamaya gelen bir request 
            //karþýlanabilir haldedir. Karþýlayacak olan þey, 
            //Controller'dýr. Tabi ki sonuç olarak html yaratmasýný istediðimiz için de 
            //viewarla çalýþacaðýmýzý da beirtmiþ olduk.
            //*Model ise bir service deðildir. Bu yüzden burada onu ekleme gibi bir iþlem yok.
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //Gelen requestlarýn rotasý bu middleware sayesinde belirlenecektir.
            app.UseRouting();
            //Bu middleware en önemlilerinden biridir.
            //endpoints, gelen requestin varýþ noktasý diye düþünülebilir.. Yani yapýlan requestin adresi.
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
                //abc.com
                //abc.com/urunler
                //abc.com/urunler/getir
                //abc.com/urunler/getir/5
            });
        }
    }
}
