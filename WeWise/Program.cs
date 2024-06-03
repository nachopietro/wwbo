using Microsoft.OpenApi.Models;
using MongoDB.Driver;
using Infrastructure.Repositories;
using Domain.Interfaces;

public class Program
{
    public static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            });
}

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "WeWise API", Version = "v1" });
        });

        // Agrega otros servicios necesarios, como el cliente MongoDB y los repositorios
        services.AddSingleton<IMongoClient>(s =>
        {
            var connectionString = "mongodb+srv://pietronignacio:corner321@wewise.dpixtmv.mongodb.net/?retryWrites=true&w=majority&appName=WeWise";
            return new MongoClient(connectionString);
        });
        services.AddScoped<IClientRepo, ClientRepo>();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "WeWise API V1");
            });
        }

        app.UseHttpsRedirection();
        app.UseRouting();
        app.UseAuthorization();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}
