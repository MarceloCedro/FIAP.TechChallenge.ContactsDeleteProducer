using FIAP.TechChallenge.ContactsDeleteProducer.Domain.Entities;
using FIAP.TechChallenge.ContactsDeleteProducer.Domain.Interfaces.Repositories;
using FIAP.TechChallenge.ContactsDeleteProducer.Domain.Services;
using Microsoft.Extensions.Logging;
using Moq;

namespace FIAP.TechChallenge.ContactsDeleteProducer.UnitTest
{
    public class ContactDomainTest
    {
        private readonly Mock<IContactRepository> _contactRepository;

        private readonly Mock<ILogger<ContactService>> _loggerMock;

        private readonly ContactService _contactService;

        public ContactDomainTest()
        {
            _contactRepository = new Mock<IContactRepository> ();
            _loggerMock = new Mock<ILogger<ContactService>>();

            _contactService = new ContactService(_contactRepository.Object, _loggerMock.Object);
        }

        [Fact]
        public async Task DeleteContactExceptionAsync()
        {
            _contactRepository.Setup(u => u.DeleteAsync(It.IsAny<Contact>())).ThrowsAsync(new Exception());

            _contactService.DeleteAsync(null);
            _loggerMock.Verify(
                x => x.Log(
                    LogLevel.Error,
                    It.IsAny<EventId>(),
                    It.Is<It.IsAnyType>((o, t) => string.Equals("Some error occour when trying to delete a Contact.", o.ToString(), StringComparison.InvariantCultureIgnoreCase)),
                    It.IsAny<Exception>(),
                    It.IsAny<Func<It.IsAnyType, Exception?, string>>()),
                Times.Once);
        }

        [Fact]
        public async Task DeleteContactSuccessAsync()
        {
            _contactRepository.Setup(u => u.DeleteAsync(It.IsAny<Contact>()));

            _contactService.DeleteAsync(null);

            _contactRepository.Verify(u => u.DeleteAsync(It.IsAny<Contact>()), Times.Once());
        }
    }
}
