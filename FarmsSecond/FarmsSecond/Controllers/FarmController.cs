using FarmsSecond.Data;
using FarmsSecond.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FarmsSecond.Controllers
{
    public class FarmController : Controller
    {
        // GET: Farm
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult AddFarm([Bind(Include = "Name,Description")] Farm farm)
        {
            try
            {
                if (!string.IsNullOrEmpty(farm.Name) && !string.IsNullOrEmpty(farm.Description))
                {
                    var lastFarm = FarmData.FarmList.Last();
                    farm.Id = lastFarm.Id + 1;
                    FarmData.FarmList.Add(farm);
                    return Json(farm, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(false, JsonRequestBehavior.AllowGet);
                }
            }

            catch (Exception e)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }


        [HttpDelete]
        public JsonResult RemoveFarm(int? farmId)
        {
            try
            {
                var farm = FarmData.FarmList.Where(f => f.Id == farmId).FirstOrDefault();
                if (farm != null)
                {
                    FarmData.FarmList.Remove(farm);
                    return Json(true, JsonRequestBehavior.AllowGet);
                }
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public JsonResult getFarm(int? farmId)
        {
            try
            {
                var farm = FarmData.FarmList.Where(s => s.Id == farmId).FirstOrDefault();
                if (farm != null)
                {
                    return Json(farm, JsonRequestBehavior.AllowGet);
                }
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult UpdateFarm([Bind(Include = "Id,Name,Description")]Farm farm)
        {
            try
            {
                var foundFarm = FarmData.FarmList.Where(s => s.Id == farm.Id).FirstOrDefault();
                if (foundFarm != null)
                {
                    foundFarm.Name = farm.Name;
                    foundFarm.Description = farm.Description;
                    return Json(foundFarm, JsonRequestBehavior.AllowGet);
                }
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public JsonResult GetAllFarms()
        {
            try
            {
                return Json(FarmData.FarmList, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }

        }

        [HttpGet]
        public JsonResult GetFarmsById(int? farmId)
        { 
            return Json(FarmData.FarmList.Where(f => f.Id == farmId).FirstOrDefault(), JsonRequestBehavior.AllowGet);
        }
    }
}