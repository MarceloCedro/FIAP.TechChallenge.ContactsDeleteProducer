using FIAP.TechChallenge.ContactsDeleteProducer.Domain.Entities;

namespace FIAP.TechChallenge.ContactsDeleteProducer.Domain.Interfaces.Integrations
{
    public interface IContactConsultManager
    {
        Task<string> GetToken();
        Task<Contact> GetContactById(int id, string token);
    }
}
