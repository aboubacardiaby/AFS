namespace AFS.Web.Models
{
    /// <summary>
    /// employee Model
    /// </summary>
    public partial class Employee
    {

        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Designation { get; set; }
        public decimal Salary { get; set; }
        public DateTime JoiningDate { get; set; }
    }
}