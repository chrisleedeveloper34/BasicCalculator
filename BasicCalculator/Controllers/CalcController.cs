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
            // parse query to get numbers and operators, spaces added in javascript
            string[] expression = query.Split(' ');
            if (expression.Length != 3)
            {
                ModelState.AddModelError("error", "error in query");
                return View();
            }
            float fNum;
            float sNum;
            if (!float.TryParse(expression[0], out fNum) || !float.TryParse(expression[2], out sNum))
            {
                ModelState.AddModelError("error", "invalid expression");
                return View();
            }
            char[] oper = expression[1].ToCharArray();
            float result = Calculate.DoWork(fNum, sNum, oper[0]);

            // nCalc way to get the result but I felt this is cheating
            //Expression e = new Expression(query);
            //float result = 0;
            //var eval = e.Evaluate();
            //if (eval != null)
            //{
            //    result = Convert.ToSingle(eval);
            //}

            return View(result);
        }
    }
}