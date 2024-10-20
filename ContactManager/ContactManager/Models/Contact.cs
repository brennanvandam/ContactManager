using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ContactManager.Models
{
    public class Contact
    {
        public int ContactId { get; set; }

        [Required(ErrorMessage = "Please enter a name.")]
        public string Firstname { get; set; }

        [Required(ErrorMessage = "Please enter a last name.")]
        public string Lastname { get; set; }

        [Required(ErrorMessage = "Please enter an email.")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter a phone number.")]
        [Phone(ErrorMessage = "Please enter a valid phone number.")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Please enter an organization.")]
        public string Organization { get; set; }

        public int CategoryID { get; set; }

        public DateTime DateAdded { get; set; } = DateTime.Now;

        [ValidateNever]
        public Category Category { get; set; } = null!;
        public string Slug => $"{Firstname?.Replace(" ", "-").ToLower()}-{Lastname?.Replace(" ", "-").ToLower()}";
    }
}
