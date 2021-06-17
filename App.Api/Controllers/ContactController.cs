using App.Api.Models;
using App.Api.Service;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace App.Api.Controllers
{
    public class ContactController : ApiController
    {
        private IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet]
        public List<Contact> Get()
        {
            return _contactService.GetContact().ToList();
        }

        [HttpGet]
        public Contact Get(int id)
        {
            var result = _contactService.GetContactById(id);
            return result;
        }

        [HttpPost]
        public void Post(Contact value)
        {
            _contactService.SaveContact((Contact)value);
        }

        [HttpPut]
        public void Put(int id, Contact value)
        {
            value.Id = id;
            _contactService.SaveContact((Contact)value);
        }

        [HttpDelete]
        public void Delete(int id)
        {
            Contact contact = Get(id);
            _contactService.DeleteContact(contact);
        }
    }
}