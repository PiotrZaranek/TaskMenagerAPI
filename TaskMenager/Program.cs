using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TaskMenager.Aplication.Interface;
using TaskMenager.Aplication.Service;
using TaskMenager.Infrastructure;
using TaskMenager.Infrastructure.Repository;
using TaskMenager.Model.Interface;
using TaskMenager.Aplication;

namespace TaskMenager
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            var connectionString = builder.Configuration.GetConnectionString("DefaultConnetion");

            builder.Services.AddDbContext<Context>(options =>
                options.UseSqlServer(connectionString)
            );

            // Dependency from infrastructure
            builder.Services.AddInfrastructure();

            // Dependency from application
            builder.Services.AddApplication();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddCors(options => 
            {
                options.AddPolicy("react", setup =>
                {
                    setup.AllowAnyHeader()
                        .AllowAnyHeader()
                        .WithOrigins("http://localhost:3000");
                });
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseCors("react");

            app.MapControllers();

            app.Run();
        }
    }
}