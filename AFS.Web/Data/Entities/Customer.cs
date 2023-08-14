using System.ComponentModel.DataAnnotations;

namespace AFS.Web.Data.Entities
{
    public class Customer: BaseEntity
    {
        [Key]
        public string CustId { get; set; }
        public string FirstName { get; set; }
        public string Name { get; set; }
       // public string Genre { get; set; }
      //  public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
       // public string City { get; set; }
       // public string Region { get; set; }
//public string PostalCode { get; set; }
        public string NationalIdNumber { get; set; }
        public ICollection<Loan> Loans { get; set; }

    }
}
