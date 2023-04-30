using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace TestTransaction.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        public class Payload
        {
            public string? transactionId { get; set; }
            public string? clientRequestTime { get; set; }
        }

        private static readonly string[] Names = new[]
        {
            "Ataur", "Nesar", "Rokib"
        };

        [HttpGet("/GetData", Name = "GetData")]
        public IEnumerable<string> GetData()
        {
            return Names;
        }

        [HttpPost("/WriteData", Name = "WriteData")]

        public string WriteData(string transactionId, string clientRequestTime)
        {
            string retVal = transactionId;
            try
            {
                //string strConnectionString = ReadConfigurationValue("DBConnectionString");

                string strDockerName = System.Environment.MachineName;
                double anount = 1.1;

                try
                {
                    DBUtility.ConnectionString = "Data Source=localhost;Initial Catalog=Demo;User=sa;Password=orion123@;TrustServerCertificate=True";
                    DBUtility.InsertTable(transactionId, anount, clientRequestTime);
              
                }
                catch (Exception ex)
                {
                    throw;
                }

                return retVal;
            }
            catch (Exception)
            {
                //return transactionId + " - Error: " + ex.Message;
                throw;
            }
        }

    }
}
