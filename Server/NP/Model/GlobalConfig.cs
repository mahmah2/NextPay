using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NP.Model
{
    public class GlobalConfig
    {
        public string CurrentPath { get; set; }
        public string PaymentsSaveFolder { get; set; } = "PaymentStorage";
        public string PaymentsFileName { get; set; } = "payments.txt";
    }
}
