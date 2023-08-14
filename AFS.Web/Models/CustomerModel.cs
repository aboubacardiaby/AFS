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
        [MinLength(4)]
        public string Phone { get; set; }
        [Required]
        [DisplayName("National ID Number")]
        public string NationalIdNumber { get; set; }
    }
}
