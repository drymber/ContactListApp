using ContactList.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ContactListApp.Controllers.API
{
    [Route("api/[controller]")]
    public class ContactsController : Controller
    {
        private IContactsService _contactsService;

        public ContactsController(IContactsService contactsService)
        {
            _contactsService = contactsService;
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public async void Delete(int id)
        {
            await _contactsService.Delete(id);
        }
    }
}
