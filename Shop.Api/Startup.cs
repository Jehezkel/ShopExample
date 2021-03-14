using System.Runtime.InteropServices;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
// using Microsoft.AspNetCore.SpaServices;
// using Microsoft.OpenApi.Models;
// using AutoMapper;

using Shop.Api.DAL;
using Shop.Api.Models;
using NSwag.Generation.Processors.Security;
using MediatR;
using System.Reflection;
using VueCliMiddleware;

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
            services.AddDbContext<AppDbContext>(opt => opt.UseNpgsql(_configuration.GetConnectionString("ShopApi")), ServiceLifetime.Transient);
            services.AddDefaultIdentity<AppUser>(options =>
                        options.SignIn.RequireConfirmedAccount = true)
          .AddEntityFrameworkStores<AppDbContext>();
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
            services.AddSpaStaticFiles(options => options.RootPath = "client-app/dist");
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
            services.AddAuthentication()
                .AddGoogle(opt =>
                {
                    IConfigurationSection googleAuthNSection = _configuration.GetSection("Authentication:Google");
                    opt.ClientId = googleAuthNSection["ClientId"];
                    opt.ClientSecret = googleAuthNSection["ClientSecret"];
                });
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            _ = CommandLine.Arguments.TryGetOptions(System.Environment.GetCommandLineArgs(), false, out string mode, out ushort port, out bool https);
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
            app.UseOpenApi();
            app.UseSwaggerUi3(settings =>
                {
                    settings.Path = "/api";
                });

            app.UseRouting();

            app.UseAuthentication();
            // app.UseIdentityServer();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
            app.UseSpaStaticFiles();
            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "client-app";

                if (env.IsDevelopment())
                {

                    // run npm process with client app
                    if (mode == "start")
                    {
                        spa.UseVueCli(npmScript: "serve", port: port, forceKill: true, https: https);
                    }

                    // if you just prefer to proxy requests from client app, use proxy to SPA dev server instead,
                    // app should be already running before starting a .NET client:
                    // run npm process with client app
                    if (mode == "attach")
                    {
                        spa.UseProxyToSpaDevelopmentServer($"{(https ? "https" : "http")}://localhost:{port}"); // your Vue app port
                    }
                }
            });


        }
    }
}
