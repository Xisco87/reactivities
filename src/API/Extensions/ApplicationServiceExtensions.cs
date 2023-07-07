using Application.Activities;
using Application.Core;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddDbContext<DataContext>(opt => {
                opt.UseSqlite(configuration.GetConnectionString("DefaultConnection"));
            });
            services.AddCors
            (
                opt => opt.AddPolicy
                (
                    "ReactivitiesCorsPolicy", 
                    policy => policy.AllowAnyHeader()
                                    .AllowAnyMethod()
                                    .WithOrigins("http://localhost:3000")
                )
            );
            services.AddMediatR(typeof(List.Handler));
            services.AddAutoMapper(typeof(MappingProfile).Assembly);
            
            return services;
        }
    }
}