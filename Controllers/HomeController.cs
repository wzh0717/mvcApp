using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using mvcApp.Models;
using System.Net.Http;

namespace mvcApp.Controllers
{
    public class HomeController : Controller
    {
      IHttpClientFactory httpClientFactory;             
        public IActionResult Index()
        {
           // var client=httpClientFactory.CreateClient();
           // var result=client.GetStringAsync("");
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
