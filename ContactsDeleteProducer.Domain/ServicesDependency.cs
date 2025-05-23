﻿using FIAP.TechChallenge.ContactsDeleteProducer.Domain.Interfaces.Services;
using FIAP.TechChallenge.ContactsDeleteProducer.Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace FIAP.TechChallenge.ContactsDeleteProducer.Domain
{
    public static class ServicesDependency
    {
        public static IServiceCollection AddServicesDependency(this IServiceCollection service)
        {
            service.AddScoped<IContactService, ContactService>();

            return service;
        }
    }
}
