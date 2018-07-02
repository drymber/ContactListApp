using ContactList.Models;
using ContactList.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ContactListApp.Data
{
    public class ContactsService : IContactsService
    {
        public async Task<IEnumerable<Contact>> GetAll()
        {
            var client = CreateClient();

            var response = await client.GetAsync("api/contacts/get");
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                return Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<Contact>>(data);
            }
            return new List<Contact>();
        }

        public async Task<Contact> GetById(int id)
        {
            var client = CreateClient();

            var response = await client.GetAsync($"api/contacts/GetById/{id}");
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                return Newtonsoft.Json.JsonConvert.DeserializeObject<Contact>(data);
            }
            return new Contact();
        }

        public async Task Create(Contact model)
        {
            var client = CreateClient();
            var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
            //var newModel = J
            var response = await client.PostAsJsonAsync("api/contacts", model);
            var created = await response.Content.ReadAsAsync<Contact>();
        }

        public async Task Update(Contact model)
        {
            var client = CreateClient();
            var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
            var response = await client.PutAsync("api/contacts", content);
        }

        private HttpClient CreateClient()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:45344");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            return client;
        }
    }
}
