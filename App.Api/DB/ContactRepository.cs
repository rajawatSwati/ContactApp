using App.Api.Models;
using NHibernate;
using System.Collections.Generic;
using System.Linq;

namespace App.Api.DB
{
    public class ContactRepository : IContactRepository
    {
        private readonly ISession _db;

        public ContactRepository(ISession db)
        {
            _db = db;
        }

        public IEnumerable<Contact> GetContact()
        {
            return _db.Query<Contact>();
        }

        public Contact GetContactById(int id)
        {
            var result = _db.Query<Contact>().Where(c => c.Id == id).FirstOrDefault();
            return result;
        }

        public void SaveContact(Contact contact)
        {
            _db.SaveOrUpdate(contact);
            _db.Flush();
        }

        public void DeleteContact(Contact contact)
        {
            _db.Delete(contact);
            _db.Flush();
        }
    }
}