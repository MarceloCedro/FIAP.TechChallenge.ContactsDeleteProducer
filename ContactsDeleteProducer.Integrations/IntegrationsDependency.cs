using FIAP.TechChallenge.ContactsDeleteProducer.Domain.Interfaces.Integrations;
using FIAP.TechChallenge.ContactsDeleteProducer.Integrations;
using Microsoft.Extensions.DependencyInjection;

namespace FIAP.TechChallenge.ContactsDeleteProducer.Infrastructure
{
    public static class IntegrationsDependency
    {
        public static IServiceCollection AddIntegrationsDependency(this IServiceCollection service)
        {
            service.AddScoped<IContactConsultManager, ContactConsultManager>();

            return service;
        }
    }
}
