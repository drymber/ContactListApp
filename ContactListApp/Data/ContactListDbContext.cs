using ContactList.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactListApp.Data
{
    public class ContactListDbContext : DbContext
    {
        public ContactListDbContext(DbContextOptions<ContactListDbContext> options) : base(options)
        {

        }

        public DbSet<Contact> Contacts { get; set; }
    }
}
