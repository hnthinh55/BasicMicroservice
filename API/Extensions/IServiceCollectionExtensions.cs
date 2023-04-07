using API.Services;
using API.Services.SendMailService;
using Domain.Entities.UserEntity;
using Domain.Interfaces;
using Infrastructure;
using Infrastructure.Repositories.UserRepositories;
using Microsoft.EntityFrameworkCore;

namespace API.Extentions
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbcontext>(op =>
            {
                op.UseSqlServer(configuration.GetConnectionString("ManagementConnection"));
                op.UseLazyLoadingProxies();
            });
            services.AddScoped<Func<AppDbcontext>>((provider) => () => provider.GetService<AppDbcontext>());
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<DbFactory>();
            return services;
        }
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            return services
                    .AddScoped(typeof(IRepository<>), typeof(Repository<>))
                    .AddScoped<IUserRepository, UserReposirory>();
        }
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            return services
                .AddScoped<UserService>()
                .AddScoped<IMailService, MailService>();
        }
    }
}
