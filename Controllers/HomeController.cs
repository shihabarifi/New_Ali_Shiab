using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using POS.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pos.Controllers
{
    
    public class HomeController : Controller
    {
        [Authorize(Permissions.Home.View)]
        public IActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        public IActionResult Denied()
        {
            return View();
        }
    }
}
