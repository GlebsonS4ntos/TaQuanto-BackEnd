
using System.Text.Json;
using System.Text.Json.Serialization;
using TaQuanto.Infraestructure.Helpers;
using TaQuanto.Service.Helpers;

namespace TaQuanto.Application
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddInfraestructure(builder.Configuration);
            builder.Services.AddService(builder.Configuration);

            builder.Services.AddControllers()
                .AddJsonOptions(opt => opt.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles)
                .AddJsonOptions(opt => opt.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower);

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
