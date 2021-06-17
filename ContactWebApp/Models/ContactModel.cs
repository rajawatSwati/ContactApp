using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ContactWebApp.Models
{
    public class ContactModel
    {
        public virtual int Id { get; set; }

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "First Name is Required")]
        public virtual string FirstName { get; set; }          [Display(Name = "Last Name")]         [Required(ErrorMessage = "Last Name is Required")]
        public virtual string LastName { get; set; }          [Required(ErrorMessage = "Email is Required")]
        [DataType(DataType.EmailAddress)]
        [Remote("IsAlreadySigned", "Contact", HttpMethod = "POST", ErrorMessage = "Email already exists", AdditionalFields = "InitialEmail")]
        public virtual string Email { get; set; }          [Display(Name = "Phone Number")]         [RegularExpression("^[0-9]{10}$", ErrorMessage = "Please enter a valid Phone Number (10 Digits)")]
        public virtual string PhoneNumber { get; set; }          public virtual bool Active { get; set; }
    }
}