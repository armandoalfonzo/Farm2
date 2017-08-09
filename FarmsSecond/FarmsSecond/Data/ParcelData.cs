using FarmsSecond.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FarmsSecond.Data
{
    public class ParcelData
    {

        public static List<Parcel> ParcelList = new List<Parcel>()
        {
            new Parcel()
            {
                Id = 1,
                Size = 15.98,
                Description = "asdasdasdasdasdasdasd",
                IdFarm = 1,
                ConditionIds = new List<int>(){3},
                Observations = new List<Observation>()
                {
                    new Observation()
                    {
                        Id=1,
                        Description = "Ut wisi enim ad minim veniam, quis nostrud exerci tation u"
                    },
                    new Observation()
                    {
                        Id=2,
                        Description = "Ut wisi enim ad minim veniam, quis nostrud exerci tation u"
                    }
                }
            },
            new Parcel()
            {
                Id = 2,
                Size = 176.98,
                Description = "qwe qwe qweqw eqwe qwe",
                IdFarm = 1,
                ConditionIds = new List<int>(){3}
            }
        };

        public static List<Condition> ConditionList = new List<Condition>()
        {
            new Condition()
            {
                Id = 1,
                Name = "Rainy"
            },
            new Condition()
            {
                Id = 2,
                Name = "Dry"
            },
            new Condition()
            {
                Id = 3,
                Name = "Very dry"
            }
        };


    }
}