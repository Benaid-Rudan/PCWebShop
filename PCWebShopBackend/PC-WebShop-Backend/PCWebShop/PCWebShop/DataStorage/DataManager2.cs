using PCWebShop.Models;
using System.Collections.Generic;
using System;

namespace PCWebShop.DataStorage
{
    public class DataManager2
    {
        public static List<ChartModel2> GetData()
        {
            var r = new Random();
            return new List<ChartModel2>()
        {
            new ChartModel2 { Data = new List<int> { r.Next(1, 40) }, Label = "Data1", BackgroundColor = "#5491DA" },
            new ChartModel2 { Data = new List<int> { r.Next(1, 40) }, Label = "Data2", BackgroundColor = "#E74C3C" },
            new ChartModel2 { Data = new List<int> { r.Next(1, 40) }, Label = "Data3", BackgroundColor = "#82E0AA" },
            new ChartModel2 { Data = new List<int> { r.Next(1, 40) }, Label = "Data4", BackgroundColor = "#E5E7E9" }
        };
        }
    }
}
