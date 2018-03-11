using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NP.Model
{
    public class PaymentInfo
    {
        public int BSB  { get; set; }
        public int AccountNumber  { get; set; }
        public string AccountName  { get; set; }
        public decimal Amount  { get; set; }
    }
}
