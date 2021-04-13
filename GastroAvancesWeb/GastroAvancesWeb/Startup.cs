using GastroAvancesWeb.Data;
using GastroAvancesWeb.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GastroAvancesWeb
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
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseMySql(
                  Configuration.GetConnectionString("DefaultConnection")));
            services.AddDbContext<base_pruebaContext>(options =>
            options.UseMySql(
            Configuration.GetConnectionString("DefaultConnection")));
            //services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
            //    .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddIdentity<usuario, IdentityRole<int>>()
                    .AddEntityFrameworkStores<ApplicationDbContext>()
                    .AddRoles<IdentityRole<int>>()
                    .AddDefaultUI();

            if (string.Equals(
                Environment.GetEnvironmentVariable("ASPNETCORE_FORWARDEDHEADERS_ENABLED"),
                "true", StringComparison.OrdinalIgnoreCase))
            {
                services.Configure<ForwardedHeadersOptions>(options =>
                {
                    options.ForwardedHeaders = ForwardedHeaders.XForwardedFor |
                        ForwardedHeaders.XForwardedProto;
                    // Only loopback proxies are allowed by default.
                    // Clear that restriction because forwarders are enabled by explicit 
                    // configuration.
                    options.KnownNetworks.Clear();
                    options.KnownProxies.Clear();
                });
            }

            services.AddControllersWithViews();
            services.AddRazorPages();
            //services.AddHttpsRedirection(opts =>
            //{
            //    opts.HttpsPort = 5001;
            //    opts.RedirectStatusCode = StatusCodes.Status307TemporaryRedirect;
            //});
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            });
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}