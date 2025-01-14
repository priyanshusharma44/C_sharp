using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace controllerPractice.Controllers
{
    public class HomeController : Controller
    {
        public string Description(int id, string name)
        {
            return "id:" + id + "name:" +name;
        
        }
    }
}