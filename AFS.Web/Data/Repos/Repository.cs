using AFS.Web.Data.Entities;
using AFS.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace AFS.Web.Data.Repos
{
    public class Repository : IRepository
    {
        private readonly ApplicationDbContext _context;

        public Repository(ApplicationDbContext context)
        {
            this._context = context;
        }

        public async Task AddCustomer(Customer customer)
        {
            try
            {
                await _context.Database
                                       .ExecuteSqlInterpolatedAsync(
                                        $"Usp_AddOrEditCustomer  @CustId ={customer.CustId}, @FirstName ={customer.FirstName}, @LastName ={customer.LastName}, @Genre= {customer.Genre},@Email ={customer.Email}, @PhoneNumber = {customer.PhoneNumber},@Address = {customer.Address},@Region ={customer.Region},@City={customer.City},  @NationalIdNumber = {customer.NationalIdNumber}, @JoinDate={customer.JoinDate}");
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }

        public async Task CreateLoanApplication(LoanApplicationViewModel model)
        {
            model.CustId = "00120";
            model.BusinessPurpose = "test1";
            model.CurrentBusiness = "test1";
            model.DatePrepared = DateTime.Now.ToString();
            
            try
            {

               await  _context.tblCustomer.AddAsync(new Customer()
                {
                    CustId = model.CustId,
                    Address = model.Address,
                    City = model.Village,
                    CreateDate = DateTime.Now,
                    CreatedBy = "abou Diaby",
                    Email = model.Email,
                    FirstName = model.FirstName,
                    Genre = model.Genre,
                    LastName = model.LastName,
                    JoinDate = Convert.ToDateTime( model.DatePrepared),
                    NationalIdNumber = model.NationalIdNumber,
                    PhoneNumber = model.Telephone,
                   Region = model.Region,
                  

                });
                await _context.TblLoanApplication.AddAsync(new LoanApplication()
                {
                    CreateDate = DateTime.Now,
                    CreatedBy = " abou Diaby",
                    Amount = model.Amount,
                    ApplicationStatus = model.Loanstatus,
                    BusinessPurpose = model.BusinessPurpose,
                    CustId = model.CustId,
                    PreparedBy = model.PreparedBy,
                    PreviousBusiness = model.CurrentBusiness,
                    PrimaryOfficer = model.PrimaryOfficer,
                    Term = model.Term

                });
                await _context.SaveChangesAsync();

              //  await _context.Database.ExecuteSqlRawAsync(
              //             // $"Usp_Addnewapplication @CustId=4011, @FirstName=John, @LastName=Harris, @Genre=Male, @Email=adv@gmail.com, @PhoneNumber=6125648817, @Address=17 1st ave N, @Region=MN, @City=MPLS, @NationalIdNumber=012hg, @JoinDate={DateTime.Now}, @Prepareby=Abou Diaby, @PrimaryOfficer=Abou Diaby, @Amount=50, @Term=term1, @BusinessPurpose=SalingBaignee, @PreviousBusiness=Salingbaignee, @ApplicationStatus=New");
              //$"exec [dbo].[Usp_Addnewapplication] @CustId ={model.CustId}, @FirstName ={model.FirstName}, @LastName ={model.LastName}, @Genre= {model.Genre},@Email ={model.Email}, @PhoneNumber = {model.Telephone},@Address = {model.Address},@Region ={model.Region},@City={model.Village}, @NationalIdNumber = {model.NationalIdNumber}, @JoinDate = {DateTime.Now}, @Prepareby= {model.PreparedBy}, @PrimaryOfficer = {model.PrimaryOfficer},@Amount = {model.Amount}, @Term ={model.Term}, @BusinessPurpose = {model.BusinessPurpose} ,@PreviousBusiness = {model.CurrentBusiness},@ApplicationStatus= {model.Loanstatus}");
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }




        public async Task<Customer> GetCustomerById(string customerid)
        {
            var customer = await _context.tblCustomer.FindAsync(customerid);
            return customer;
        }

        public async Task<Customer> GetCustomerDetails(string customerid)
        {
            var customer = await _context.tblCustomer.FirstOrDefaultAsync(m => m.CustId == customerid);
            if (customer == null)
            {
                return null;
            }
            return customer;
        }

        public List<Customer> GetCustomers()
        {
            //var customers = _context?.tblCustomer?
            //                        .FromSqlRaw<Customer>($"Usp_GetAllCustomer").ToList();
            return _context.tblCustomer.ToList();
        }

        #region Loan Repos

        public async Task<Loan> GetLoanInfobyCustomerAsync(string customerid)
        {
            return null;
            //return _context.tblCustomer.
        }

        #endregion Loan Repos
    }
}