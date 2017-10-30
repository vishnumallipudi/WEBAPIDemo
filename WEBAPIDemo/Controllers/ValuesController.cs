using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WEBAPIDemo.Controllers
{
    //[Authorize]
    public class ValuesController : ApiController
    {

        List<string> mylist = new List<string> {
            "value1", "value2","value3", "value4"
        };

        // GET api/values
        public IEnumerable<string> Get()
        {
            return mylist;
        }

        // GET api/values/5
        public string Get(int id)
        {
            return mylist[id];
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
            mylist.Add(value);
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
            mylist[id] = value;
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
            mylist.RemoveAt(id);
        }
    }
}
