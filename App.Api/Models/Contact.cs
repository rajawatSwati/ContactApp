﻿
namespace App.Api.Models
{
    public class Contact
    {
        public virtual int Id { get; set; }
        public virtual string FirstName { get; set; }         public virtual string LastName { get; set; }         public virtual string Email { get; set; }         public virtual string PhoneNumber { get; set; }         public virtual bool Active { get; set; }
    }
}