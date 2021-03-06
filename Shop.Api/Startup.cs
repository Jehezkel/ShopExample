using System.Runtime.InteropServices;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
// using Microsoft.OpenApi.Models;
// using AutoMapper;

using Shop.Api.DAL;
using Shop.Api.Models;
using NSwag.Generation.Processors.Security;
using MediatR;
using System.Reflection;

namespace Shop.Api
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            // services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehaviour<,>));
            // services.AddTransient(typeof(IPipelineBehavior<,>), typeof(AuthorizationBehaviour<,>));
            // services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
            // services.AddTransient(typeof(IPipelineBehavior<,>), typeof(PerformanceBehaviour<,>));
            // services.AddPooledDbContextFactory<AppDbContext>(opt => opt.UseNpgsql(_configuration.GetConnectionString("ShopApi")));
            services.AddDbContext<AppDbContext>(opt => opt.UseNpgsql(_configuration.GetConnectionString("ShopApi")));
            services.AddDatabaseDeveloperPageExceptionFilter();
            // services.AddDefaultIdentity<AppUser>(opt => opt.SignIn.RequireConfirmedAccount = true)
            //     .AddEntityFrameworkStores<AppDbContext>();
            // services.AddIdentityServer()
            // .AddApiAuthorization<AppUser, AppDbContext>();
            // services.AddAuthentication()
            // .AddIdentityServerJwt();
            services.AddControllersWithViews();
            services.AddRazorPages();
            services.AddMvc();
            // services.AddSwaggerDocument();
            services.AddOpenApiDocument(configure =>
            {
                configure.Title = "Shop Api";
                // configure.AddSecurity("JWT", Enumerable.Empty<string>(), new NSwag.OpenApiSecurityScheme
                // {
                //     Type = NSwag.OpenApiSecuritySchemeType.ApiKey,
                //     Name = "Authorization",
                //     In = NSwag.OpenApiSecurityApiKeyLocation.Header,
                //     Description = "Type into the textbox: Bearer {your JWT}"
                // });
                // configure.OperationProcessors.Add(new AspNetCoreOperationSecurityScopeProcessor("JWT"));
            });
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
                // app.UseSwagger();
                // app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MojeApi v1"));
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseOpenApi(settings => {
                settings.Path = "/api/specification.json";
            });
            app.UseSwaggerUi3(settings =>
                {
                    settings.Path = "/api";
                    settings.DocumentPath = "/api/specification.json";
                });

            app.UseRouting();

            // app.UseAuthentication();
            // app.UseIdentityServer();
            // app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });


        }
    }
}
