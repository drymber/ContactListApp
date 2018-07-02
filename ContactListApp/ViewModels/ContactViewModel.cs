using ContactListApp.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ContactListApp.ViewModels
{
    public class ContactViewModel
    {
        public int Id { get; set; }

        public string Heading { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "You must provide a phone number")]
        [Display(Name = "Phone number")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [StringLength(100)]
        [Display(Name = "Address №1")]
        public string Address1 { get; set; }

        [Display(Name = "Address №2")]
        [StringLength(100)]
        public string Address2 { get; set; }

        public string Comments { get; set; }

        public string Action
        {
            get
            {
                Expression<Func<ContactsController, IActionResult>> update =
                    (c => c.Update(this));
                Expression<Func<ContactsController, IActionResult>> create =
                    (c => c.Create(this));

                var action = (Id != 0) ? update : create;
                var actionName = (action.Body as MethodCallExpression).Method.Name;
                return actionName;
            }
        }
    }
}
