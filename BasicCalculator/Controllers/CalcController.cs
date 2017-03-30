using BasicCalculator.Maths;
using NCalc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BasicCalculator.Controllers
{
    public class CalcController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(string query)
        {
            if (String.IsNullOrEmpty(query))
            {
                ModelState.AddModelError("error", "query cannot be empty");
                return View();
            }

            // nCalc way to get the result but I felt this is cheating
            Expression e = new Expression(query);
            float result = 0;
            try
            {
                var eval = e.Evaluate();
                if (eval != null)
                {
                    result = Convert.ToSingle(eval);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("error", ex.Message);
            }
            return View(result);
        }
    }
}