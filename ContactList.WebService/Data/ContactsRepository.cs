using ContactList.Data;
using ContactList.Models;
using System.Collections.Generic;
using System.Linq;

namespace ContactList.WebServices.Data
{
    public class ContactsRepository
    {
        private ContactListDbContext _context;

        public ContactsRepository(ContactListDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Contact> GetAll()
        {
            return _context.Contacts.Where(c => !c.IsDeleted);
        }
        public void Delete(int id)
        {
            var contact = _context.Contacts.Single(c => c.Id == id);
            contact.IsDeleted = true;
            _context.SaveChanges();
        }
        public Contact GetById(int id)
        {
            var contact = _context.Contacts.Single(c => c.Id == id);
            return contact;
        }

        public void Create(Contact contact)
        {
            _context.Contacts.Add(contact);
            _context.SaveChanges();
        }

        public void Update(Contact modified)
        {
            var existed = _context.Contacts.Single(c => c.Id == modified.Id);
            existed.Address1 = modified.Address1;
            existed.Address2 = modified.Address2;
            existed.Comments = modified.Comments;
            existed.FirstName = modified.FirstName;
            existed.LastName = modified.LastName;
            existed.PhoneNumber = modified.PhoneNumber;
            _context.SaveChanges();
        }
    }
}
