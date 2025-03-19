using FIAP.TechChallenge.ContactsDeleteProducer.Domain.Entities;

namespace FIAP.TechChallenge.ContactsDeleteProducer.Domain.Interfaces.Applications
{
    public interface ITokenApplication
    {
        public string GetToken(User usuario);
    }
}
