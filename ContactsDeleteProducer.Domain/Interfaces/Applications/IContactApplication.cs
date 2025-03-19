using FIAP.TechChallenge.ContactsDeleteProducer.Domain.DTOs.Application;
using FIAP.TechChallenge.ContactsDeleteProducer.Domain.DTOs.EntityDTOs;

namespace FIAP.TechChallenge.ContactsDeleteProducer.Domain.Interfaces.Applications
{
    public interface IContactApplication
    {
        Task<UpsertContactResponse> DeleteContactAsync(ContactDeleteDto contactDeleteDto);
    }
}