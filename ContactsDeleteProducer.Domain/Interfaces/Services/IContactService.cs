using FIAP.TechChallenge.ContactsDeleteProducer.Domain.Entities;

namespace FIAP.TechChallenge.ContactsDeleteProducer.Domain.Interfaces.Services
{
    public interface IContactService
    {
        Task DeleteAsync(Contact contact);
    }
}