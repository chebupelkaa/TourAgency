using BLL.Interfaces;
using BLL.Services;
using DAL.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Microsoft.AspNetCore.Identity;

namespace BLL.Configuration
{
    public static class ConfigurationService
    {

        public static void ConfigureBLL(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDataAccessServices(configuration);

            services.AddScoped<IContractService, ContractService>()
                .AddScoped<IGroupService, GroupService>()
                .AddScoped<IGroupMemberService, GroupMemberService>()
                .AddScoped<IReservationService, ReservationService>()
                .AddScoped<IReviewService, ReviewService>()
                .AddScoped<ITourService, TourService>()
                .AddScoped<IEmailService, EmailService>()
                .AddScoped<IUserService, UserService>();



            services.AddAutoMapper(Assembly.GetExecutingAssembly());
        }
        public static void ConfigBLL(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDataAccessServices(configuration);

            services.AddScoped<IContractService, ContractService>()
                .AddScoped<IGroupService, GroupService>()
                .AddScoped<IGroupMemberService, GroupMemberService>()
                .AddScoped<IReservationService, ReservationService>()
                .AddScoped<IReviewService, ReviewService>()
                .AddScoped<ITourService, TourService>()
                .AddScoped<IEmailService, EmailService>();


            services.AddAutoMapper(Assembly.GetExecutingAssembly());
        }
    }
}
