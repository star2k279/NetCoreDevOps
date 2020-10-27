using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace DotNetCoreDockerized.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private IConfiguration _config;

        public ValuesController(IConfiguration iConfig)
        {
            _config = iConfig;
        }

        // GET api/values
        [HttpGet("GetResponse")]
        public ActionResult<string> GetResponse()
        {
            string dbConn = _config.GetValue<string>("Database:myEnvironment");
            return new string(String.Format("Hello from {0} of Asp.Net Core Application. Updated by Najm once again", dbConn));
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
