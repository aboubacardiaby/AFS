using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AFS.Web.Models
{
    public class LoanModel
    {
        [Required]
        [MinLength(4)]
        [DisplayName("Loan Number")]
        public string LoanNumber { get; set; }
        [Required]
        [MinLength(4)]
        [DisplayName("LoanNumber")]
        public string LoanName { get; set; }
        [Required]       
        [DisplayName("Amount")]
        public decimal LoanAmount { get; set; }
        [Required]
      
        [DisplayName("Type")]
        public LoanType LoanType { get; set;}
    }
    public enum LoanType
    {
        
        creditVendeur,
        CreitPaysant

    }
}
