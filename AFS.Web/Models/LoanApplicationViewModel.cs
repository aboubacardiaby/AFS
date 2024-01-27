
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AFS.Web.Models
{
    public class LoanApplicationViewModel
    {
        public string CustId { get; set; }
        [Required]
        [DisplayName("Primary Officer")]
        public string PrimaryOfficer { get; set; }
        [Required]
        [DisplayName("Prepared By")]
        public string PreparedBy { get; set; }

        [Required]
        [DisplayName("Date Prepared")]
        public string DatePrepared { get; set; }
        [Required]
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [Required]
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [Required]
        [DisplayName("Address")]
        public string Address { get; set; }
        [Required]
        [DisplayName("Village")]
        public string Village { get; set; }

        [Required]
        [DisplayName("Region")]
        public string Region { get; set; }
        [Required]
        [DisplayName("Departement")]
        public string Departement { get; set; }


        [Required]
        [DisplayName("Tephone Number")]
        public string Telephone { get; set; }
        [DisplayName("Email")]
        public string Email { get; set; }

        [Required]
        [DisplayName("Current Business")]
        public string CurrentBusiness { get; set; }

        [Required]
        [DisplayName("Business Purpose")]
        public string BusinessPurpose { get; set; }
        [Required]
        [DisplayName("Genre")]
        public string Genre { get; set; }
        [Required]
        [DisplayName("Amount")]
        public string Amount { get; set; }


        [Required]
        [DisplayName("National ID Number")]
        public string NationalIdNumber { get; set; }
        [Required]
        [DisplayName("Term")]
        public string Term { get; set; }
        public string Loanstatus { get; set; }

        public List<string> GenreOptions()
        {
            string[] values = { "Male", "Female" };
            return values.ToList();
        }

        public List<string> RegionOptions()
        {
            string[] values = { "Dakar", "Fatick", "Kaolack", "Diourbel", "Kolda", "Tamba", "Sedhiou", "Ziguinchor", "Matam", "Saint Louis" };
            return values.ToList();
        }
    }
}
