using BackendTrainingMaster.Crud.Context;
using Microsoft.EntityFrameworkCore;

namespace BackendTrainingMaster.Crud
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //Configurar la BD
            var connectionString = 
                builder.Configuration.GetConnectionString("Connection");
            builder.Services.AddDbContext<AppDbContext>
                (options => options.UseSqlServer(connectionString));

            // Add services to the container.
            builder.Services.AddControllers()
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
            });

            builder.Services.AddControllers();

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
