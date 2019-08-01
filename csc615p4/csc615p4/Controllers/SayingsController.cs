using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace csc615p4.Controllers
{
    public class SayingsController : ApiController
    {
        static Dictionary<String, IEnumerable<String>> sayingsMap = new Dictionary<string, IEnumerable<string>>();
        static SayingsController()
        {
            List<String> aphorisms = new List<String> { "What goes up", "Must come down" };
            sayingsMap.Add("Muganda", aphorisms);

            aphorisms = new List<String> { "Newton was a great man", "Euler was pretty good too" };
            sayingsMap.Add("Yogi", aphorisms);
        }
        // GET api/sayings
        public HttpResponseMessage Get()
        {
            return Request.CreateResponse<Dictionary<string, IEnumerable<string>>>(HttpStatusCode.OK, sayingsMap);
        }

        // GET api/sayings/person
        public HttpResponseMessage Get(String person)
        {
            return Request.CreateResponse(HttpStatusCode.OK, sayingsMap[person]);
        }

        // GET api/sayings/person/id
        public HttpResponseMessage Get(String person, int id)
        {
            if (sayingsMap.ContainsKey(person) == false)
            {
                return Request.CreateResponse<string>(HttpStatusCode.Conflict, String.Format("Person {0} already exists", person));
            }
            else
            {
                List<String> sList = sayingsMap[person] as List<string>;

                try
                {

                    if (id <= sayingsMap.Count)
                    {
                        String sSelected = sList.ElementAt(id);
                        return Request.CreateResponse(HttpStatusCode.OK, sSelected);
                        //return Request.CreateResponse(HttpStatusCode.OK, sayingsMap[person].ElementAt(id));
                    }
                    else
                    {
                        //so that the compiler wouldn't complain
                        return Request.CreateResponse<string>(HttpStatusCode.Conflict, String.Format("Index {0} is out of bounds.", id));
                    }

                    //catch the out of bounds int
                }
                catch (Exception e)
                {
                    return Request.CreateResponse<string>(HttpStatusCode.Conflict, String.Format("Index {0} is out of bounds.", id));
                }
            }

        }

        // POST api/sayings/person
        // POST api/sayings/person [newSaying]
        public HttpResponseMessage Post(String person)
        {
            string saying = Request.Content.ReadAsStringAsync().Result;
            if (saying == null || saying.Length == 0)
            {
                if (sayingsMap.ContainsKey(person))
                {
                    return Request.CreateResponse<string>(HttpStatusCode.Conflict, String.Format("Person {0} already exists", person));
                }
                sayingsMap[person] = new List<string>();
                return Request.CreateResponse<string>(HttpStatusCode.Created, person);
            }

            if (!sayingsMap.ContainsKey(person))
            {
                return Request.CreateResponse<string>(HttpStatusCode.NotFound, String.Format("Person {0} does not exist", person));
            }

            List<string> personSayings = sayingsMap[person] as List<string>;
            personSayings.Add(saying);

            Dictionary<string, IEnumerable<string>> dict = new Dictionary<string, IEnumerable<string>>();
            dict.Add(person, personSayings);
            return Request.CreateResponse<Dictionary<string, IEnumerable<string>>>(HttpStatusCode.OK, dict);
        }

        // PUT api/sayings/person
        public HttpResponseMessage Put(String person)
        {
            string newName = Request.Content.ReadAsStringAsync().Result;

            if (sayingsMap.ContainsKey(person) == false)
            {
                return Request.CreateResponse<string>(HttpStatusCode.NotFound, String.Format("Person {0} does not exist", person));
            }
            else if (sayingsMap.ContainsKey(newName) == true)
            {
                return Request.CreateResponse<string>(HttpStatusCode.Conflict, String.Format("Person {0} already exists", person));
            }
            else
            {
                sayingsMap.Add(newName, sayingsMap[person] as List<string>);
                sayingsMap.Remove(person);
                return Request.CreateResponse(HttpStatusCode.OK, sayingsMap[newName]);
            }
        }

        public HttpResponseMessage Put(String person, int id)
        {

            string saying = Request.Content.ReadAsStringAsync().Result;

            if (sayingsMap.ContainsKey(person) == false)
            {
                return Request.CreateResponse<string>(HttpStatusCode.NotFound, String.Format("Person {0} does not exist", person));
            }
            else
            {
                List<String> sList = sayingsMap[person] as List<string>;
                try
                {

                    if (id <= sayingsMap.Count)
                    {
                        sList.RemoveAt(id);
                        sList.Insert(id, saying);
                        //sList.set(id, saying); //in java

                        return Request.CreateResponse(HttpStatusCode.OK, sayingsMap[person]);
                    }
                    else
                    {
                        //for compiler
                        return Request.CreateResponse<string>(HttpStatusCode.Conflict, String.Format("Index {0} is out of bounds.", id));
                    }

                    //catch the out of bounds int
                }
                catch (Exception e)
                {
                    return Request.CreateResponse<string>(HttpStatusCode.Conflict, String.Format("Index {0} is out of bounds.", id));
                }
            }
        }

        // DELETE api/sayings/person
        public HttpResponseMessage Delete(String person)
        {
            if (sayingsMap.ContainsKey(person) == false)
            {
                return Request.CreateResponse<string>(HttpStatusCode.NotFound, String.Format("Person {0} does not exist", person));
            }
            else
            {
                List<String> returnList = sayingsMap[person] as List<string>;
                sayingsMap.Remove(person);
                return Request.CreateResponse(HttpStatusCode.OK, returnList);
            }
        }

        //DELETE api/sayings/person/id
        public HttpResponseMessage Delete(String person, int id)
        {
            if (sayingsMap.ContainsKey(person) == false)
            {
                return Request.CreateResponse<string>(HttpStatusCode.NotFound, String.Format("Person {0} does not exist", person));
            }
            else
            {
                try
                {

                    if (id <= sayingsMap.Count)
                    {
                        List<String> returnList = sayingsMap[person] as List<string>;
                        String returnSaying = returnList.ElementAt(id);
                        returnList.RemoveAt(id);
                        return Request.CreateResponse(HttpStatusCode.OK, returnSaying);
                    }
                    else
                    {
                        return Request.CreateResponse<string>(HttpStatusCode.Conflict, String.Format("Index {0} is out of bounds.", id));
                    }

                    //catch the out of bounds int
                }
                catch (Exception e)
                {
                    return Request.CreateResponse<string>(HttpStatusCode.Conflict, String.Format("Index {0} is out of bounds.", id));
                }
            }
        }
    }
}
