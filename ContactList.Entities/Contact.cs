using System.ComponentModel.DataAnnotations;

namespace ContactList.Entities
{
    public class Contact
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string PhoneNumber { get; set; }
        public string Comments { get; set; }
        public bool IsDeleted { get; set; }
    }
}
