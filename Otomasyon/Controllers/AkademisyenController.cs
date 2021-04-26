using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Otomasyon.Models.Entity;

namespace Otomasyon.Controllers
{
    public class AkademisyenController : Controller
    {
        // GET: Akademisyen
        ÖğrenciBilgiSistemiEntities db = new ÖğrenciBilgiSistemiEntities();
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult Listele()
        {
            var id =(int)Session["Hocaİd"];
            var liste = db.İliski.Where(x => x.HocaİD == id).ToList();
            return View(liste);
        }
        public ActionResult NotVer(int id,İliski p)
        {
            var ogr = db.İliski.Find(id);
            ogr.Vize = p.Vize;
            ogr.Final = p.Final;
            db.SaveChanges();
            return View();
        }

    
    }
}