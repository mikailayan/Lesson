using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MiniShopApp.Business.Abstract;
using MiniShopApp.Business.Concrete;
using MiniShopApp.Data.Abstract;
using MiniShopApp.Data.Concrete.EfCore;
using MiniShopApp.WebUI.EmailServices;
using MiniShopApp.WebUI.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniShopApp.WebUI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationContext>(options => options.UseSqlite("Data Source=MiniShopAppDb"));
            services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<ApplicationContext>().AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(option => {
                //Pasword
                option.Password.RequireDigit = true; //þifremin içinde rakam bulunsun
                option.Password.RequireLowercase = true; //þifremde küçük harf bulunmalý
                option.Password.RequireUppercase = true; //büyükharf bulunmalý
                option.Password.RequiredLength = 6; // en az 6 karakter olmalý

                //Lockout kullanýcýnýn üst üste sürekli olarka giriþ yapmasýný engelliyoruz
                option.Lockout.MaxFailedAccessAttempts = 3; //3 kere deneyebilirsin fazla denersen hesap kitlenir.
                option.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(10); //3 kere üst üste hatalý girerse hesabý 10 dakika kitlenecek
                option.Lockout.AllowedForNewUsers = true;

                //User 
                option.User.RequireUniqueEmail = true; //bir kiþinin mail adresi benzersiz olmalý

                //SignIn
                option.SignIn.RequireConfirmedEmail = true; 

            });
            //Burada Identity ile ilgili çeþitli seçenekleri tanýmlayacaðýz.
            services.AddScoped<IEmailSender, SmtpEmailSender>(i => new SmtpEmailSender(
                Configuration["EmailSender:Host"],
                Configuration.GetValue<int>("EmailSender:Port"),
                Configuration.GetValue<bool>("EmailSender:EnableSSL"),
                Configuration["EmailSender:UserName"],
                Configuration["EmailSender:Password"]
                ));

            services.AddScoped<IProductRepository, EfCoreProductRepository>();
            services.AddScoped<ICategoryRepository, EfCoreCategoryRepository>();
            services.AddScoped<IProductService, ProductManager>();
            //Proje boyunca ICategoryService çaðrýldýðýnda, CategoryManager'i kullan.
            services.AddScoped<ICategoryService, CategoryManager>();
            //Projemizin MVC yapýsýnda olmasýný saðlar.
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                SeedDatabase.Seed();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "admincategorycreate",
                    pattern: "admin/category/create",
                    defaults: new { controller = "Admin", action = "CategoryCreate" }
                    );
                endpoints.MapControllerRoute(
                    name: "adminproductcreate",
                    pattern: "admin/products/create",
                    defaults: new { controller = "Admin", action = "ProductCreate" }
                    );
                endpoints.MapControllerRoute(
                   name: "admincategory",
                   pattern: "admin/category",
                   defaults: new { controller = "Admin", action = "CategoryList" }
                   );
                endpoints.MapControllerRoute(
                    name: "adminproducts",
                    pattern: "admin/products",
                    defaults: new { controller = "Admin", action = "ProductList" }
                    );
                endpoints.MapControllerRoute(
                    name: "search",
                    pattern: "search",
                    defaults: new { controller = "MiniShop", action = "Search" }
                    );
                endpoints.MapControllerRoute(
                   name: "products",
                   pattern: "products/{category?}",
                   defaults: new { controller = "MiniShop", action = "List" }
                   );
                endpoints.MapControllerRoute(
                    name: "adminproductedit",
                    pattern: "admin/products/{id?}",
                    defaults: new { controller = "Admin", action = "ProductEdit" }
                    );
                endpoints.MapControllerRoute(
                    name: "productdetails",
                    pattern: "{url}",
                    defaults: new { controller = "MiniShop", action = "Details" }
                    );

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
