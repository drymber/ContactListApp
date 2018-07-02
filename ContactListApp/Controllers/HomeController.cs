using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ContactListApp.Data;
using ContactListApp.ViewModels;
using ContactList.Services;

namespace ContactListApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ContactsRepository _contactsRepository;
        private readonly ContactList.Services.IContactsService _contactsService;

        public HomeController(ContactsRepository contactsRepository, ContactList.Services.IContactsService contactService)
        {
            _contactsRepository = contactsRepository;
            _contactsService = contactService;
        }
        public IActionResult Index()
        {
            var contacts = _contactsService.GetAll().Result;
            return View(contacts);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
