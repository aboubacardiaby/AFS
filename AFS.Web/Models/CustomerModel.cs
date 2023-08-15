using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AFS.Web.Models
{
    public class CustomerModel
    {

        [DisplayName("Customer ID")]
        public string CustomerId { get; set; }
        [Required]
        [MinLength(4)]
        [DisplayName("First Name")]
        public string Firstname { get; set; }
        [Required]
        [MinLength(4)]
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        [DisplayName("Phone Number")]
        [Phone]
        [MinLength(4)]
        public string Phone { get; set; }
        public SelectList? Genres { get; set; }
        [Required]
        [DisplayName("Genre")]
        public string Genre { get; set; }
        [Required]
        [DisplayName("Region")]
        public string Region { get; set; }
        [Required]
        [DisplayName("National ID Number")]
        public string NationalIdNumber { get; set; }


        public string Name { get; set; }
        [Required]
        [DisplayName("Join Date")]       
        public DateTime JoinDate { get; set; }

        [EmailAddress]
        [DisplayName("Email Address")]
        public string Email { get; set; }


        public List<string> GenreOptions()
        {
            
            string[] values = { "Male", "Female" };
            return values.ToList(); 
        }
    }

}
