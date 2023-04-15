using System.ComponentModel.DataAnnotations;

namespace AFS.Web.Models
{
    public class CustomerModel
    {
       
        public string CustomerId { get; set; }
        [Required]
        [MinLength(4)]     
        public string Firstname { get; set; }
        [Required]
        [MinLength(4)]
        public string LastName { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Phone { get; set; }
    }
}
