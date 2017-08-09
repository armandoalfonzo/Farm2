using FarmsSecond.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FarmsSecond.Controllers
{
    public class ConditionController : Controller
    {
        // GET: Condition
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetAllConditions()
        {
            try
            {
                return Json(ParcelData.ConditionList, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }
    }
}