using Database;
using Marten;
using Marten.Events;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Wineventory.Domain.Inventory;
using Wineventory.Domain.Utils;
using Wineventory.Logic.Inventory;
using Wineventory.Web.Utils;

namespace Web
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
            services.AddMvc().AddNewtonsoftJson();

            // In production, the React files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/build";
            });

            var sqlConnectionString = Configuration.GetConnectionString("VinmonopoletProducts");
            services.AddDbContext<WineContext>
                (options => options.UseNpgsql(sqlConnectionString));

            services.AddScoped(sp =>
           {
               var documentStore = DocumentStore.For(options =>
               {
                   var config = Configuration.GetSection("EventStore");
                   var connectionString = config.GetValue<string>("ConnectionString");
                   var schemaName = config.GetValue<string>("Schema");

                   options.Connection(connectionString);
                   options.AutoCreateSchemaObjects = AutoCreate.All;
                   options.Events.DatabaseSchemaName = schemaName;
                   options.DatabaseSchemaName = schemaName;

                   options.Events.StreamIdentity = StreamIdentity.AsString;
                   options.Events.InlineProjections.AggregateStreamsWith<InventoryWine>();
                   options.Events.InlineProjections.Add(new InventoryWineViewProjection());

                   options.Events.AddEventType(typeof(FirstBottleOfWineAdded));
                   options.Events.AddEventType(typeof(BottleOfWineAdded));
               });

               return documentStore.OpenSession();
           });

            services.AddHandlers();
            services.AddSingleton<Messaging>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
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

            //app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseMvc();

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseReactDevelopmentServer(npmScript: "start");
                }
            });
        }
    }
}
