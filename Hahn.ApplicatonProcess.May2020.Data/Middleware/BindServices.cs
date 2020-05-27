
namespace Hahn.ApplicatonProcess.May2020.Data.Middleware
{

    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using Repositories;
    using Domain.IRepository;
    using Services;

    public static class BindServices
    {
        public static IServiceCollection InjectServices(this IServiceCollection services,string connectionString)
        {
            services.AddDbContext<Context.ApplicationProcessContext>(options =>
            {
                options.UseInMemoryDatabase(connectionString);
            });
            services.AddScoped<IApplicantRepository, ApplicantRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IApplicantService, ApplicantService>();
            
            return services;
        }

    }
}