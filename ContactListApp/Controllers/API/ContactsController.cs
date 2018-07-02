using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactListApp.Data;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ContactListApp.Controllers.API
{
    [Route("api/[controller]")]
    public class ContactsController : Controller
    {
        private readonly ContactsRepository _contactsRepository;

        public ContactsController(ContactsRepository contactsRepository)
        {
            _contactsRepository = contactsRepository;
        }
        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _contactsRepository.Delete(id);
        }
    }
}
