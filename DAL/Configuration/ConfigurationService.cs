using Microsoft.EntityFrameworkCore;
using DAL.Data;
using DAL.Interfaces;
using DAL.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using DAL.Entities;
using Microsoft.AspNetCore.Identity;

namespace DAL.Configuration
{
    public static class ConfigurationService
    {
        public static IServiceCollection AddDataAccessServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationContext>(options =>
                    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                    builder => builder.MigrationsAssembly(typeof(ApplicationContext).Assembly.FullName)));

            services.AddScoped<IContractRepository, ContractRepository>()
                .AddScoped<IGroupRepository, GroupRepository>()
                .AddScoped<IGroupMemberRepository, GroupMemberRepository>()
                .AddScoped<IReservationRepository, ReservationRepository>()
                .AddScoped<IReviewRepository, ReviewRepository>()
                .AddScoped<ITourRepository, TourRepository>();



            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.Password.RequireNonAlphanumeric = false;
            })
            .AddEntityFrameworkStores<ApplicationContext>()
            .AddDefaultTokenProviders();

            return services;
        }
    }
}
