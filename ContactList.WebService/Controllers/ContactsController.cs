using ContactList.Data;
using ContactList.Models;
using ContactList.WebServices.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        public void Create(Contact contact)
        {
            _contactsRepository.Create(contact);
        }

        [HttpPut]
        public void Update(Contact contact)
        {
            _contactsRepository.Update(contact);
        }
    }
}
