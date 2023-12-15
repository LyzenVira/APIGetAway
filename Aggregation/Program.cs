
using Aggregation.Services;
using Aggregation.Services.Interfaces;

namespace Aggregation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            IConfiguration config = new ConfigurationBuilder().AddJsonFile("appsetings.json").Build();

            builder.Services.AddHttpClient<IDoctorService, DoctorService>
    (c => c.BaseAddress = new Uri(config["ApiSettings:DoctorServiceUrl"]));
            builder.Services.AddHttpClient<IPatientService, PatientService>
                (c => c.BaseAddress = new Uri(config["ApiSettings:PatientServiceUrl"]));
            builder.Services.AddHttpClient<IDocumentService, DocuntService>
                (c => c.BaseAddress = new Uri(config["ApiSettings:DocumentServiceUrl"]));
            builder.Services.AddHttpClient<IJwtService, JwtService>
                (c => c.BaseAddress = new Uri(config["ApiSettings:JwtServiceUrl"]));

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

            app.Run();
        }
    }
}