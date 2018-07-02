using ContactList.Entities;
using ContactList.WebService.Data;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ContactList.WebService.Controllers
{
    [Route("api/[controller]")]
    public class ContactsController : Controller
    {
        private ContactsRepository _contactsRepository;

        public ContactsController(ContactsRepository contactsRepository)
        {
            _contactsRepository = contactsRepository;
        }

        [HttpGet("Get")]
        public IEnumerable<Contact> Get()
        {
            return _contactsRepository.GetAll();
        }

        [HttpGet("GetById/{id}")]
        public Contact GetById(int id)
        {
            return _contactsRepository.GetById(id);
        }

        [HttpPost]
        public void Create([FromBody] Contact contact)
        {
            _contactsRepository.Create(contact);
        }

        [HttpPut]
        public void Update([FromBody] Contact contact)
        {
            _contactsRepository.Update(contact);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _contactsRepository.Delete(id);
        }
    }
}
