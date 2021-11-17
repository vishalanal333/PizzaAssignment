using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaAssignment
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddAuthentication(options =>
            {
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            })
           .AddCookie(options =>
           {
               options.LoginPath = "/account/google-login"; // Must be lowercase
           })
            .AddGoogle(googleOptions =>
            {
                googleOptions.ClientId = "845892227092-i1e0us9o185htf8hagpknqvfikinp2s1.apps.googleusercontent.com";
                googleOptions.ClientSecret = "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";
            })
            .AddFacebook(fbOptions =>
            {
                fbOptions.AppId = "5187185601330448";
                fbOptions.AppSecret = "b531db78e5ab669b3f8f693ca965956c";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles();
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
