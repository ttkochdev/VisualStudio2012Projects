using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Routing;

namespace cac615p4_part1.Controllers
{
    public class SayingsController : ApiController
    {

        static Dictionary<String, IEnumerable<String>> sayingsMap = new Dictionary<string, IEnumerable<string>>();
        static SayingsController()
        {
            List<String> aphorisms = new List<String> {"What goes up", "Must come down"};
            sayingsMap.Add("Muganda", aphorisms);

            aphorisms = new List<String> {"Newton was a great man", "Euler was pretty good too" };
            sayingsMap.Add("Yogi", aphorisms);
        }


        // GET api/sayings
        public HttpResponseMessage Get()
        {
            return Request.CreateResponse<Dictionary<String, IEnumerable<String>>>(HttpStatusCode.OK, sayingsMap);
            //return new string[] { "value1", "value2" };
        } 

        // GET api/sayings/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/sayings
        public void Post([FromBody]string value)
        {
        }

        // PUT api/sayings/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/sayings/5
        public void Delete(int id)
        {
        }
    }
}
