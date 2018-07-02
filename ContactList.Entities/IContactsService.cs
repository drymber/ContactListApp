﻿using ContactList.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ContactList.Services
{
    public interface IContactsService
    {
        Task<IEnumerable<Contact>> GetAll();
        Task<Contact> GetById(int id);
        Task Update(Contact model);
        Task Create(Contact model);
        Task Delete(int id);
    }
}
