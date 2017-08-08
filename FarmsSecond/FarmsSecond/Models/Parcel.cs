using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FarmsSecond.Models
{
    public class Parcel
    {
        public int Id { get; set; }
        public double Size { get; set; }
        public string Description { get; set; }
        public int IdFarm { get; set; }
        public List<Observation> Observations { get; set; }
        public List<int> PlantIds { get; set; }
        public List<int> ConditionIds { get; set; }
    }
}