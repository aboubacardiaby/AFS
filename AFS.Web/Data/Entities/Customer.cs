using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AFS.Web.Data.Entities
{
    public class Customer: BaseEntity
    {
        [Key]
        public string? CustId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Genre { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }      
        public string? Region { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? JoinDate { get; set; }
        public string? NationalIdNumber { get; set; }
        public ICollection<Loan> Loans { get; set; }

    }
}
