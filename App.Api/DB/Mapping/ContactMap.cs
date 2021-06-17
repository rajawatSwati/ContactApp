using App.Api.Models;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace App.Api.DB.Mapping
{
    public class ContactMap : ClassMap<Contact>
    {
        public ContactMap()
        {
            Id(x => x.Id).GeneratedBy.Identity();
            Table("Contacts");
            Map(x => x.FirstName);
            Map(x => x.LastName);
            Map(x => x.Email);
            Map(x => x.PhoneNumber);
            Map(x => x.Active);
        }
    }
}