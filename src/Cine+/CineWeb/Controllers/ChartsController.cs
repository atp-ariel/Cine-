using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace CineWeb.Controllers
{
    public class ChartsController : Controller
    {
        public IActionResult Index() => View();


        [HttpPost]
        public JsonResult NewChart()
        {
            string[] labels = new[] { "January", "February", "March", "April", "May", "June" };
            int[] data = new[] { 0, 10, 5, 2, 20, 30, 45 };
            return Json((x: labels, y: data));
        }
    }
    public class DataCharts
    {
        public string[] labels;
        public int[] data;

        public DataCharts(string[] labels, int[] data)
        {
            this.labels = labels;
            this.data = data;
        }
    }
}
