using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
//http://localhost:51223/api/Sayings/
namespace WebApplication7.Controllers
{
    public class SayingsController : ApiController
    {
        static Dictionary<String, IEnumerable<String>> map = new Dictionary<string, IEnumerable<string>>();
        static SayingsController()
        {
            List<String> aList = new List<string> { "a", "b" };
            map.Add("Muganda", aList);


        }
        // GET api/sayings
        public Dictionary<String, IEnumerable<String>> Get()
        {
            return map;
        }

        // GET api/sayings/person
        public IEnumerable<String> Get(String person)
        {
            return map[person];
        }

        // GET api/sayings/person/id
        public String Get(String person, int id)
        {
            return map[person].ElementAt(id);
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
