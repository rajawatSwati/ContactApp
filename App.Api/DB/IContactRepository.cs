using App.Api.Models;
using System.Collections.Generic;

namespace App.Api.DB
{
    public interface IContactRepository
    {
        IEnumerable<Contact> GetContact();
        void SaveContact(Contact contact);
        void DeleteContact(Contact contact);
        Contact GetContactById(int id);
    }
}
