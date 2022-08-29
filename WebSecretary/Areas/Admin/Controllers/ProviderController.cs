using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebSecretary.Areas.Admin.Controllers
{
    public class ProviderController : Controller
    {
        // GET: Admin/Provider
        public ActionResult Index()
        {
            return View("Eimai o provider");
        }
    }
}