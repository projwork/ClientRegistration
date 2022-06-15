using ClientRegistration.Contract.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientRegistration.Contract.DataContract
{
    public class Loan
    {
        public int Id { get; set; }
        public LoanType LoanType { get; set; }
        public int Amount { get; set; }
        public string Currency { get; set; }
        public int Period { get; set; }
        public Status Status { get; set; }
    }
}
