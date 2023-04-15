namespace AFS.Web.Data.Entities
{
    public class Payment: BaseEntity
    {
        public string LoanNumber { get; set; }
        public DateTime DueDate { get; set; }
        public string PaymentAmount { get; set; }
        public string PaymentType { get; set; }
        public string Comment { get; set; }
    }
}