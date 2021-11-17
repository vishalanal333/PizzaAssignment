using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaAssignment.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        [ViewData]
        public string Title { get; set; }
        public ViewResult Index()
        {
            return View();
        }
        public ViewResult AboutUs()
        {
            return View();
        }
        public ViewResult LogIn()
        {
            return View();
        }
    }
}
