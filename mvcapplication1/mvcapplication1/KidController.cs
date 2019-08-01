using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication1
{
    public class KidController : Controller
    {
        //
        // GET: /Kid/

        public ActionResult Index()
        {
            var kid = new
            {
                Name = "Abby",
                Age = 12,
                Scores = new int[] { 90, 98, 100 }
            };

            return Json(kid, JsonRequestBehavior.AllowGet);
            
        }

    }
}
