using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Otomasyon.Models.Entity;

namespace Otomasyon.Controllers
{
    public class ÖgrenciController : Controller
    {
        ÖğrenciBilgiSistemiEntities db = new ÖğrenciBilgiSistemiEntities();
        // GET: Ögrenci
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Not()
        {
            var id = (int)Session["id"];
            var ogrenci = db.İliski.Where(x => x.ÖgrenciİD == id).ToList();

            return View();
        }
    }
}