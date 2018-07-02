using ContactList.Entities;

namespace ContactListApp.ViewModels
{
    public class ContactMapper
    {
        public Contact Map(ContactViewModel viewModel)
        {
            var model = new Contact()
            {
                Address1 = viewModel.Address1,
                Address2 = viewModel.Address2,
                Comments = viewModel.Comments,
                Id = viewModel.Id,
                FirstName = viewModel.FirstName,
                LastName = viewModel.LastName,
                PhoneNumber = viewModel.PhoneNumber
            };
            return model;
        }
        public ContactViewModel Map(Contact model)
        {
            var viewModel = new ContactViewModel()
            {
                Address1 = model.Address1,
                Address2 = model.Address2,
                Comments = model.Comments,
                Id = model.Id,
                FirstName = model.FirstName,
                LastName = model.LastName,
                PhoneNumber = model.PhoneNumber
            };
            return viewModel;
        }
    }
}
