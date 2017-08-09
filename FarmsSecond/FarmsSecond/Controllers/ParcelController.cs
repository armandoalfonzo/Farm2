using FarmsSecond.Data;
using FarmsSecond.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FarmsSecond.Controllers
{
    public class ParcelController : Controller
    {
        // GET: Parcel
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Edit()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetAllParcelByFarmId(int? farmId)
        {
            try
            {
                if (farmId != null)
                {
                    return Json(ParcelData.ParcelList.Where(p => p.IdFarm == farmId), JsonRequestBehavior.AllowGet);
                }
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult AddParcel([Bind(Include = "Size,Description,IdFarm,Observations,ConditionIds")] Parcel parcel)
        {
            try
            {
                if (!string.IsNullOrEmpty(parcel.Size.ToString()) && !string.IsNullOrEmpty(parcel.Description) && parcel.Observations.Count > 0)
                {
                    var last = ParcelData.ParcelList.LastOrDefault();
                    if (last == null)
                    {
                        parcel.Id = 1;
                        ParcelData.ParcelList.Add(parcel);
                        return Json(parcel, JsonRequestBehavior.AllowGet);
                    }
                    parcel.Id = last.Id + 1;
                    ParcelData.ParcelList.Add(parcel);
                    return Json(parcel, JsonRequestBehavior.AllowGet);
                }
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public JsonResult GetParcel(int? parcelId)
        {
            try
            {
                if (parcelId != null)
                {
                    var parcel = ParcelData.ParcelList.Where(s => s.Id == parcelId).FirstOrDefault();
                    return Json(parcel, JsonRequestBehavior.AllowGet);
                }
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPut]
        public JsonResult UpdateParcel([Bind(Include = "Id,Size,Description,IdFarm,Observations,ConditionIds")] Parcel parcel)
        {
            try
            {
                if (!string.IsNullOrEmpty(parcel.Size.ToString()) && !string.IsNullOrEmpty(parcel.Description) && parcel.Observations.Count > 0)
                {
                    var foundParcel = ParcelData.ParcelList.Where(s => s.Id == parcel.Id).FirstOrDefault();
                    if (foundParcel != null)
                    {
                        foundParcel.Size = parcel.Size;
                        foundParcel.Description = parcel.Description;
                        foundParcel.Observations = parcel.Observations;
                        foundParcel.ConditionIds = parcel.ConditionIds;
                        return Json(foundParcel, JsonRequestBehavior.AllowGet);
                    }
                }
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpDelete]
        public JsonResult RemoveParcel(int? parcelId)
        {
            try
            {
                if (parcelId != null)
                {
                    var plantList = PlantData.PlantList.Where(f => f.IdParcel == parcelId).ToList();
                    var parcel = ParcelData.ParcelList.Where(f => f.Id == parcelId).FirstOrDefault();
                    foreach (var plant in plantList)
                    {
                        PlantData.PlantList.Remove(plant);
                    }
                    ParcelData.ParcelList.Remove(parcel);
                    return Json(true, JsonRequestBehavior.AllowGet);
                }
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

    }
}