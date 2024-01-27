namespace AFS.Web.Data.Entities
{
    public class Loan: BaseEntity
    {
        public string LoandNumber { get; set; }
        public string LoanName { get; set; }
        public string LoanType { get; set; }
        public string LoanAmount { get; set; }
        public Customer Customer { get; set; }
        public string CustId { get; set; }
        private ICollection<Payment> Payments { get; set; }

    }
}