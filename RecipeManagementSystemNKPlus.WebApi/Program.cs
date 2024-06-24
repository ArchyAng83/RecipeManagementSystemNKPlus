
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;
using RecipeManagementSystemNKPlus.Application.Interfaces;
using RecipeManagementSystemNKPlus.Domain.Entities;
using RecipeManagementSystemNKPlus.Infrastructure.DataAccess;
using RecipeManagementSystemNKPlus.Infrastructure.Repositories;
using System;

namespace RecipeManagementSystemNKPlus.WebApi
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

            builder.Services.AddDbContext<RecipeDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            builder.Services.AddScoped<IGenericOwnedRepository<CompositeType>, CompositeTypeRepository>();
            builder.Services.AddScoped<IGenericOwnedRepository<Ingredient>, IngredientRepository>();
            builder.Services.AddScoped<IGenericOwnedRepository<Product>, ProductRepository>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
                app.UseCors(policy =>
                {
                    policy.WithOrigins("https://localhost:7219")
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .WithHeaders(HeaderNames.ContentType);
                });
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
