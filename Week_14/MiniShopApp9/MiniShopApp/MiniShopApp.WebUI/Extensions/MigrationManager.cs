using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MiniShopApp.Data.Concrete.EfCore;
using MiniShopApp.WebUI.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniShopApp.WebUI.Extensions
{
    public static class MigrationManager
    {
        public static IHost MigrateDataBase(this IHost host)
        {
            using (var scope = host.Services.CreateScope()) //dışarıdan bir şeyi içine koyuyoruz ınjection
            {
                using (var applicationContext = scope.ServiceProvider.GetRequiredService<ApplicationContext>()) //otomatik migration yapmak için 
                {
                    try
                    {
                        applicationContext.Database.Migrate();

                    }
                    catch (Exception)
                    {

                        throw;
                    };
                }
                using (var miniShopContext = scope.ServiceProvider.GetRequiredService<MiniShopContext>())
                {
                    try
                    {
                        miniShopContext.Database.Migrate();

                    }
                    catch (Exception)
                    {

                        throw;
                    };
                }
            }
            return host;
        }
    }
}
