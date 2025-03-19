using FIAP.TechChallenge.ContactsDeleteProducer.Application;
using FIAP.TechChallenge.ContactsDeleteProducer.Domain;
using FIAP.TechChallenge.ContactsDeleteProducer.Infrastructure;

namespace FIAP.TechChallenge.ContactsDeleteProducer.Api.IoC
{
    public static class DependencyResolver
    {
        public static void AddDependencyResolver(this IServiceCollection services, string connectionString)
        {
            services.AddRepositoriesDependency();
            services.AddDbContextDependency(connectionString);
            services.AddServicesDependency();
            services.AddApplicationDependency();
            services.AddAuthenticationDependency();
            services.AddIntegrationsDependency();
        }
    }
}
