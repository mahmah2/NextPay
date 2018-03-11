using Newtonsoft.Json;
using NP.Interface;
using NP.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NP.Business
{
    public class PaymentBusiness
    {
        public async Task<bool> SaveToOutput(IOutputPayment output, string config, PaymentInfo paymentInfo)
        {
            try
            {
                return await Task.Run(() => {
                    Thread.Sleep(3000);
                    output.Config(config);
                    output.Save(JsonConvert.SerializeObject(paymentInfo));
                    return true;
                });
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}
