using ClientRegistration.Contract.DataContract;

namespace ClientRegistration.Repository.Interface
{
    public interface ILoanRepository
    {
        Loan GetLoan(int id);
        void ApplyLoan(Loan model);
        void UpdateLoan(int id, Loan model);
    }
}
