using ContactList.Services;
using ContactListApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ContactListApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ContactList.Services.IContactsService _contactsService;

        public HomeController(IContactsService contactService)
        {
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
