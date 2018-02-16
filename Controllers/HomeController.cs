using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Vue2Spa.Filters;

namespace Vue2Spa.Controllers
{
    [IEFilter]
    [TypeFilter(typeof(SimpleResourceFilter))]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
