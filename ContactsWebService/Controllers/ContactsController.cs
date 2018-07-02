using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactListApp.Data;
using ContactListApp.Models;
using ContactListApp.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ContactListApp.Controllers
{
    public class ContactsController : Controller
    {
        private readonly ContactsRepository _contactsRepository;
        private readonly ContactMapper _contactMapper;

        public ContactsController(ContactsRepository contactsRepository, ContactMapper contactMapper)
        {
            _contactsRepository = contactsRepository;
            _contactMapper = contactMapper;
        }
        public IActionResult Create()
        {
            var viewModel = new ContactViewModel()
            {
                Heading = "Create new contact"
            };
            return PartialView("_ContactForm", viewModel);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var contact = _contactsRepository.GetById(id);
            var viewModel = _contactMapper.Map(contact);
            viewModel.Heading = "Edit a contact";
            return PartialView("_ContactForm", viewModel);
            //return PartialView("_ContactForm", new ContactViewModel());
        }

        [HttpPost]
        public IActionResult Create(ContactViewModel viewModel)
        {
            return ChangeContactDecorator(viewModel, _contactsRepository.Create);
        }
        [HttpPost]
        public IActionResult Update(ContactViewModel viewModel)
        {
            return ChangeContactDecorator(viewModel, _contactsRepository.Update);
        }

        private IActionResult ChangeContactDecorator(ContactViewModel viewModel, Action<Contact> repositoryAction)
        {
            if (!ModelState.IsValid)
            {
                return PartialView("_ContactForm", viewModel);
            }
            var model = _contactMapper.Map(viewModel);

            repositoryAction(model);

            return PartialView("_EditContactSuccess");
        }
    }
}