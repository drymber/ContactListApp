using ContactList.Entities;
using ContactListApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ContactListApp.Controllers
{
    public class ContactsController : Controller
    {
        private readonly ContactMapper _contactMapper;
        private readonly IContactsService _contactsService;

        public ContactsController(
            ContactMapper contactMapper,
            IContactsService contactsService)
        {
            _contactMapper = contactMapper;
            _contactsService = contactsService;
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
            var contact = _contactsService.GetById(id).Result;
            var viewModel = _contactMapper.Map(contact);
            viewModel.Heading = "Edit a contact";
            return PartialView("_ContactForm", viewModel);
        }

        [HttpPost]
        public IActionResult Create(ContactViewModel viewModel)
        {
            return ChangeContactDecorator(viewModel, _contactsService.Create);
        }
        [HttpPost]
        public IActionResult Update(ContactViewModel viewModel)
        {
            return ChangeContactDecorator(viewModel, _contactsService.Update);
        }

        private IActionResult ChangeContactDecorator(ContactViewModel viewModel, Func<Contact, Task> repositoryAction)
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