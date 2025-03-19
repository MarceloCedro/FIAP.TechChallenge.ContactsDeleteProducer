using FIAP.TechChallenge.ContactsDeleteProducer.Domain.DTOs.EntityDTOs;
using FIAP.TechChallenge.ContactsDeleteProducer.Domain.Interfaces.Applications;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FIAP.TechChallenge.ContactsDeleteProducer.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactsController(IContactApplication contactService, ILogger<ContactsController> logger) : ControllerBase
    {
        private readonly IContactApplication _contactService = contactService;
        private readonly ILogger<ContactsController> _logger = logger;

        /// <summary>
        /// Método para deletar um contato de forma assíncrona.
        /// </summary>
        /// <param name="id">Objeto com o ID do contato a ser deletado</param>
        /// <returns>Não retorna nenhum valor, deleta o contato do banco de dados</returns>
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteContact(int id)
        {
            _logger.LogInformation("Deletando contato de ID {ID}", id);
            await _contactService.DeleteContactAsync(new ContactDeleteDto { Id = id });
            return Ok();
        }
    }
}
