using FarmsSecond.Data;
using FarmsSecond.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FarmsSecond.Controllers
{
    public class PlantController : Controller
    {
        // GET: Plant
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult AddPlant([Bind(Include = "Name,Description,PlantedDate,IdParcel,PlantType")] Plant plant)
        {
            try
            {
                if (!string.IsNullOrEmpty(plant.Name) && !string.IsNullOrEmpty(plant.Description))
                {
                    var last = PlantData.PlantList.LastOrDefault();
                    if (last == null)
                    {
                        plant.Id = 1;
                        PlantData.PlantList.Add(plant);
                        return Json(plant, JsonRequestBehavior.AllowGet);
                    }
                    plant.Id = last.Id + 1;
                    PlantData.PlantList.Add(plant);
                    return Json(plant, JsonRequestBehavior.AllowGet);
                }
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpDelete]
        public JsonResult RemovePlant(int? plantId)
        {
            try
            {
                if (plantId != null)
                {
                    var plant = PlantData.PlantList.Where(f => f.Id == plantId).FirstOrDefault();
                    PlantData.PlantList.Remove(plant);
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
        public JsonResult getPlant(int? plantId)
        {
            try
            {
                if (plantId != null)
                {
                    var plant = PlantData.PlantList.Where(s => s.Id == plantId).FirstOrDefault();
                    if (plant != null)
                    {
                        return Json(plant, JsonRequestBehavior.AllowGet);
                    }
                }
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPut]
        public JsonResult UpdatePlant([Bind(Include = "Id,Name,Description,PlantedDate,IdParcel,PlantType")] Plant plant)
        {
            try
            {
                if (!string.IsNullOrEmpty(plant.Id.ToString()) && !string.IsNullOrEmpty(plant.Name) && !string.IsNullOrEmpty(plant.Description) && !string.IsNullOrEmpty(plant.PlantedDate.ToString()) && !string.IsNullOrEmpty(plant.IdParcel.ToString()) && !string.IsNullOrEmpty(plant.PlantType.ToString()))
                {
                    var foundPlant = PlantData.PlantList.Where(s => s.Id == plant.Id).FirstOrDefault();
                    if (foundPlant != null)
                    {
                        foundPlant.Name = plant.Name;
                        foundPlant.Description = plant.Description;
                        foundPlant.PlantedDate = plant.PlantedDate;
                        foundPlant.IdParcel = plant.IdParcel;
                        foundPlant.PlantType = plant.PlantType;
                        return Json(foundPlant, JsonRequestBehavior.AllowGet);
                    }
                }
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public JsonResult GetAllPlantsByParcelId(int? parcelId)
        {
            try
            {
                if (parcelId != null)
                {
                    return Json(PlantData.PlantList.Where(p => p.IdParcel == parcelId), JsonRequestBehavior.AllowGet);
                }
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public JsonResult GetParcelByTypeAndCount(int parcelId)
        {
            var a = from p in PlantData.PlantList
                    where p.IdParcel == parcelId
                    group p by p.PlantType
                into g
                    select g.ToList();
            List<Object> result = new List<object>();
            foreach (var b in a)
            {
                result.Add(new
                {
                    count = b.Count,
                    type = GetTypeName(b.FirstOrDefault().PlantType)
                });
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        private string GetTypeName(int plantId)
        {
            return PlantData.PlantTypeList.Where(p => p.Id == plantId).FirstOrDefault().Name;
        }
    }
}