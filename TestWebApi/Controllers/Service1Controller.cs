using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace TestWebApi.Controllers
{
    public class Service1Controller : ApiController
    {
        [HttpGet]
        async public Task<string> ExecuteMethod()
        {
            await Task.Delay(250);
            return "Done";
        }
    }
}
