using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using indranu7.models;
using indranu7.buisinessLogic;

namespace indranu7.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("AllowMyOrigin")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/metadata
        [HttpGet]
        public ActionResult<FieldModel[]> Get()
        {
            return formatMetadata.GetTarifFields();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        [EnableCors("AllowMyOrigin")]
        public dynamic Post([FromBody] dynamic value)
        {
            Console.Write(value);
            string test = "a";
            return "test";
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
