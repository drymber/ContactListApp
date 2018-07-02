using ContactList.Models;
using Microsoft.EntityFrameworkCore;

namespace ContactList.Data
{
    public class ContactListDbContext : DbContext
    {
        public ContactListDbContext(DbContextOptions<ContactListDbContext> options) : base(options)
        {

        }

        public DbSet<Contact> Contacts { get; set; }
    }
}
