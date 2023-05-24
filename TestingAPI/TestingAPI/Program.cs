using LearningAPI.Data;
using LearningAPI.Logging;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace TestingAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            //DataBase
            builder.Services.AddDbContext<ApplicationdbContext>(option
                =>
            { option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultSQLConnection")); });

                //Log in file
            //Log.Logger = new LoggerConfiguration().MinimumLevel.Debug().WriteTo.File("log/placeslogs.txt", 
            //    rollingInterval: RollingInterval.Day).CreateLogger();
            //builder.Host.UseSerilog();

            builder.Services.AddControllers(option => { option.ReturnHttpNotAcceptable = true;
                }).AddNewtonsoftJson().AddXmlDataContractSerializerFormatters();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddScoped<ILogging, Logging>(); //Build Custom serives // Dependency injection.
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            
            app.MapControllers();

            /*
             * Multiple conventional routes
             app.MapControllerRoute(name: "blog",
                pattern: "blog/{*article}",
                defaults: new { controller = "Blog", action = "Article" });
            app.MapControllerRoute(name: "default",
               pattern: "{controller=Home}/{action=Index}/{id?}");
             */
            app.Run();
        }
    }
}