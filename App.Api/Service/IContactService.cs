using App.Api.Models;
using System.Collections.Generic;

namespace App.Api.Service
{
    public interface IContactService
    {
        IEnumerable<Contact> GetContact();
        void SaveContact(Contact contact);
        void DeleteContact(Contact contact);
        Contact GetContactById(int id);
    }
}
