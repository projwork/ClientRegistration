using ClientRegistration.Contract.DataContract;
using ClientRegistration.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClientRegistration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoanController : ControllerBase
    {
        private readonly ILoanRepository _loanRepository;

        public LoanController(ILoanRepository loanRepository)
        {
            _loanRepository = loanRepository;
        }

        [HttpGet]
        /// <summary>
        /// Gets loan details.
        /// </summary>
        /// <param name="loanId">The  CSS Id.</param>
        /// <response code="200">The user has been retrieved.</response>
        /// <response code="404">The use info was not found.</response>
        [Route("getloan")]
        public async Task<IActionResult> Get(int id)
        {
            var item = _loanRepository.GetLoan(id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        [HttpPost]
        /// <summary>
        /// Add loan details.
        /// </summary>
        /// <param name="Loan model">The  CSS Id.</param>
        /// <response code="200">The loan details has been retrieved.</response>
        /// <response code="404">The loan details was not found.</response>
        [Route("saveloandetails")]
        public void CreateLoan([FromBody] Loan loan)
        {
            if (loan == null)
            {
                throw new ArgumentNullException(nameof(loan));
            }
            _loanRepository.ApplyLoan(loan);
        }

        [HttpPut]
        /// <summary>
        /// Add loan details.
        /// </summary>
        /// <param name="Loan model">The  CSS Id.</param>
        /// <response code="200">The loan details has been updated.</response>
        [Route("updateloandetails")]
        public void UpdateLoan(int id, [FromBody] Loan loan)
        {
            _loanRepository.UpdateLoan(id, loan);
        }
    }
}
