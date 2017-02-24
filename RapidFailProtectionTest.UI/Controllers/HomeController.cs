using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using RapidFailProtectionTest.UI.Extensions;
using RapidFailProtectionTest.UI.Helpers;
using WebGrease.Css.Ast.Selectors;

namespace RapidFailProtectionTest.UI.Controllers
{
    public class HomeController : Controller
    {
        public async Task<ActionResult> Index()
        {
            return View();
        }

        
        [AllowAnonymous]
        public async Task<JsonResult> TriggerStackOverFlow(int numberExceptions)
        {
            RapidFireProtectionHelper.StackOverFlowException(numberExceptions);
            return Json("success", JsonRequestBehavior.AllowGet);
        }

        [AllowAnonymous]
        public async Task<JsonResult> TriggerAccessViolation(int numberExceptions)
        {
            RapidFireProtectionHelper.AccessViolationException(numberExceptions);
            return Json("success", JsonRequestBehavior.AllowGet);
        }


    }
}