using FIAP.TechChallenge.ContactsDeleteProducer.Domain.Interfaces.Repositories;
using FIAP.TechChallenge.ContactsDeleteProducer.Infrastructure.Repositories;
using FIAP.TechChallenge.ContactsDeleteProducer.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace FIAP.TechChallenge.ContactsDeleteProducer.Infrastructure
{
    public static class DatabaseDependency
    {
        public static IServiceCollection AddRepositoriesDependency(this IServiceCollection service)
        {
            service.AddScoped<IContactRepository, ContactRepository>();

            return service;
        }

        public static IServiceCollection AddDbContextDependency(this IServiceCollection service, string connectionString)
        {
            service.AddDbContext<ContactsDbContext>(options => options.UseMySql(connectionString,
                                                               new MySqlServerVersion(new Version(8, 0, 21)),
                                                               mySqlOptions => mySqlOptions.MigrationsAssembly("FIAP.TechChallenge.ContactsDeleteProducer.Infrastructure")));

            return service;
        }
    }
}
