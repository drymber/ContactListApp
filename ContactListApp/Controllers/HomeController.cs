using ContactList.Entities;
using ContactListApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace ContactListApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IContactsService _contactsService;

        public HomeController(IContactsService contactService)
        {
            _contactsService = contactService;
        }
        public IActionResult Index()
        {
            var contacts = new List<Contact>();
            try
            {
                contacts = _contactsService.GetAll().Result.ToList();
            }
            catch (System.Exception)
            {
            }
            return View(contacts);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
