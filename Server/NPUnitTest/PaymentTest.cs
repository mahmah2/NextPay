using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using NP.Model;
using System.IO;
using System.Threading.Tasks;

namespace NPUnitTest
{
    [TestClass]
    public class PaymentTest
    {
        [TestMethod]
        public async Task TestMethod1()
        {
            //setup dependencies
            NP.Variables.CurrentFolder = Path.Combine(Directory.GetCurrentDirectory(), "..");

            //clear output
            var outputFile = Path.Combine(NP.Variables.CurrentFolder,
                                            NP.Variables.PaymentOutputFolder, 
                                            NP.Variables.PaymentOutputFileName);

            if (File.Exists(outputFile))
                File.Delete(outputFile);

            //run controller action
            var controller = new NP.Controllers.V1.PaymentController(new NP.OutputPayment.FileOutputPayment());
            var originalPayment = new NP.Model.PaymentInfo()
            {
                AccountName = "a",
                AccountNumber = 1234,
                Amount = 12,
                BSB = 32323
            };

            //check returned result
            var result = await controller.Post(originalPayment);

            var okResult = result as Microsoft.AspNetCore.Mvc.OkObjectResult;
            Assert.IsNotNull(okResult);

            var resultObject = okResult.Value as PaymentInfo;
            Assert.IsNotNull(resultObject);

            Assert.IsTrue( Helper.Compare.PublicInstancePropertiesEqual<PaymentInfo>(originalPayment, resultObject) );

            //compare results
            string contents = File.ReadAllText(outputFile);

            Assert.AreEqual(JsonConvert.SerializeObject(resultObject), contents.Trim());
        }
    }
}
