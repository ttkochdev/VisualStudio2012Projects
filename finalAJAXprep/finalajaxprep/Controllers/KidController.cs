using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;


namespace finalAJAXprep.Controllers
{
    public class KidController : ApiController
    {
        //
        // GET: /Kid/

        public HttpResponseMessage Get()
        {
            var kid = new
            {
                Name = "Abby",
                Age = 12,
                Scores = new int[] { 90, 98, 100 }
            };

            return Request.CreateResponse(HttpStatusCode.OK, kid, Configuration.Formatters.JsonFormatter);

        }


        public HttpResponseMessage Post()
        {
            string data = Request.Content.ReadAsStringAsync().Result;

            if (data == null || data.Length == 0)
            {

                return Request.CreateResponse<string>(HttpStatusCode.Conflict, "No data");

            }


            return Request.CreateResponse(HttpStatusCode.OK, data, Configuration.Formatters.JsonFormatter);
            

      
        }

    }
}
