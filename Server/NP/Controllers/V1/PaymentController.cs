using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NP.Model;
using NP.Interface;
using System.IO;
using Newtonsoft.Json;
using NP.Business;
using System.Net.Http;
using System.Net;

namespace NP.Controllers.V1
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/Payment")]
    public class PaymentController : Controller
    {
        private IOutputPayment _output;
        public PaymentController(IOutputPayment output)
        {
            _output = output;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post(
            [FromBody]PaymentInfo value)
        {
            try
            {
                var fileName = Path.Combine(Variables.CurrentFolder
                    , Variables.PaymentOutputFolder
                    , Variables.PaymentOutputFileName);

                var paymentBusiness = new PaymentBusiness();

                await paymentBusiness.SaveToOutput(_output, fileName, value);

                return Ok(value);
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
