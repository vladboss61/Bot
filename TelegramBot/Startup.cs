using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

using TelegramBot.Extensions;
using TelegramBot.Models.Commands;
using TelegramBot.Models;
using Telegram.Bot;

namespace TelegramBot
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IConfiguration>(provider => Configuration);
            services.AddScoped<IBotRepository, BotRepository>();            

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);            
            services.AddSpaStaticFiles(configuration => configuration.RootPath = "ClientApp/dist");

            var connectionString = Configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<BotDbContext>(options => options.UseNpgsql(connectionString));
            services.AddTelegramBot();

            //this method adds telegram commands.
            //Further request it as IReadOnlyList<Command>
            services.AddTelegramBotCommands();
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                //app.UseHsts();
            }
            //Https redirection and HSTS disabled because ngrok translates https requests to http
            //app.UseHttpsRedirection();
            app.UseStaticFiles();
            //app.UseSpaStaticFiles();
            app.UseMvc(routes => routes.MapRoute(name: "default", template: "{controller}/{action=Index}/{id?}"));
            // app.UseSpa(spa =>
            // {
            //     spa.Options.SourcePath = "ClientApp";

            //     if (env.IsDevelopment())
            //     {
            //         spa.UseAngularCliServer(npmScript: "start");
            //     }
            // });

            
        }
    }
}
