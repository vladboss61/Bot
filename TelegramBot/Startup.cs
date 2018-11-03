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
using TelegramBot.Infrastructure;

namespace TelegramBot
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            Options = Configuration.Get<ConfigurationOptions>();
        }

        public IConfiguration Configuration { get; }

        public ConfigurationOptions Options { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<ConfigurationOptions>(Configuration);

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddSpaStaticFiles(configuration => configuration.RootPath = "ClientApp/dist");

            var connectionString = Options.MssqlConnection == string.Empty ? 
                throw new System.InvalidOperationException("Bad connection string") : Options.MssqlConnection;

            services.AddDbContext<BotDbContext>(options => 
                options.UseNpgsql(connectionString));

            services.AddTelegramBot();

            services.AddScoped<IBotRepository, BotRepository>();

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
            app.UseMvc();
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
