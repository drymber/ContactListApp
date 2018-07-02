using ContactList.Entities;
using Microsoft.EntityFrameworkCore;

namespace ContactList.WebService.Data
{
    public class ContactListDbContext : DbContext
    {
        public ContactListDbContext(DbContextOptions<ContactListDbContext> options) : base(options)
        {

        }

        public DbSet<Contact> Contacts { get; set; }
    }
}
