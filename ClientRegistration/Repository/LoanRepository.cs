using ClientRegistration.Contract.DataContract;
using ClientRegistration.Repository.Interface;

namespace ClientRegistration.Repository
{
    public class LoanRepository : ILoanRepository
    {
        private readonly DataContext _dbContext;

        public LoanRepository(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Loan GetLoan(int loanId)
        {
            Loan loan = new Loan();
            var query = from l in _dbContext.Loan
                        where l.Id == loanId
                        select l;
            loan = query.FirstOrDefault();
            return loan;
        }

        public void ApplyLoan(Loan loan)
        {
            var loanData = new Loan()
            {
                Id = loan.Id,
                Amount = loan.Amount,
                Currency = loan.Currency,
                LoanType = loan.LoanType,
                Period = loan.Period,
                Status = loan.Status,
            };
            _dbContext.Loan.Add(loanData);
            _dbContext.SaveChanges();
        }

        public void UpdateLoan(int id, Loan loan)
        {
            var loanData = _dbContext.Loan
                .Where(l => l.Id == id)
                .SingleOrDefault();
            loanData.Amount = loan.Amount;
            loanData.LoanType = loan.LoanType;
            loanData.Status = loan.Status;
            loanData.Period = loan.Period;
            _dbContext.SaveChanges();
        }

    }
}
