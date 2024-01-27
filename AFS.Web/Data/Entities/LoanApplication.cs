namespace AFS.Web.Data.Entities
{
    public class LoanApplication : BaseEntity
    {
        public string CustId { get; set; }
        public string PrimaryOfficer { get; set; }
        public string PreparedBy { get; set; }
        public string BusinessPurpose { get; set; }
        public string PreviousBusiness { get; set; }
        public string Amount { get; set; }
        public string Term { get; set; }
        public string ApplicationStatus { get; set; }
        public Customer Customer { get; set; }

    }
}
