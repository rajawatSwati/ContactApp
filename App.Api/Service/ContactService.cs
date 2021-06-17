using App.Api.DB;
using App.Api.Models;
using System.Collections.Generic;

namespace App.Api.Service
{
    public class ContactService : IContactService
    {
        private IContactRepository _contactRepo;

        public ContactService(IContactRepository contactRepo)
        {
            _contactRepo = contactRepo;
        }

        public IEnumerable<Contact> GetContact()
        {
            return _contactRepo.GetContact();
        }

        public Contact GetContactById(int id)
        {
            return _contactRepo.GetContactById(id);
        }

        public void SaveContact(Contact contact)
        {
            _contactRepo.SaveContact(contact);
        }

        public void DeleteContact(Contact contact)
        {
            _contactRepo.DeleteContact(contact);
        }
    }
}