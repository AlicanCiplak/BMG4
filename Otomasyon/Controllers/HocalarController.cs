using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Otomasyon.Models.Entity;

namespace Otomasyon.Controllers
{
    public class HocalarController : Controller
    {
        // GET: Hocalar
        ÖğrenciBilgiSistemiEntities db = new ÖğrenciBilgiSistemiEntities();
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult BölümEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult BölümEkle(Bölümler p)
        {
            db.Bölümler.Add(p);
            db.SaveChanges();
            return View();
        }

        [HttpGet]
        public ActionResult DersEkle()
        {
            List<SelectListItem> degerler1 = (from k in db.Bölümler.ToList()
                                              select new SelectListItem
                                              {
                                                  Text = k.BölümAdı,
                                                  Value = k.id.ToString()
                                              }).ToList();
            ViewBag.dgr2 = degerler1;
            return View();
        }
        [HttpPost]
        public ActionResult DersEkle(Dersler p)
        {
            var blm = db.Bölümler.Where(m => m.id == p.BölümİD).FirstOrDefault();
            p.Bölümler = blm;
            db.Dersler.Add(p);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult HocaEkle()
        {
            List<SelectListItem> degerler1 = (from k in db.Bölümler.ToList()
                                              select new SelectListItem
                                              {
                                                  Text = k.BölümAdı,
                                                  Value = k.id.ToString()
                                              }).ToList();
            ViewBag.dgr2 = degerler1;
            return View();
        }
        [HttpPost]
        public ActionResult HocaEkle(Hocalar p)
        {
            var blm = db.Bölümler.Where(m => m.id == p.BölümİD).FirstOrDefault();
            p.Bölümler = blm;
            db.Hocalar.Add(p);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult OgrenciEkle()
        {
            List<SelectListItem> degerler1 = (from k in db.Bölümler.ToList()
                                              select new SelectListItem
                                              {
                                                  Text = k.BölümAdı,
                                                  Value = k.id.ToString()
                                              }).ToList();
            ViewBag.dgr2 = degerler1;
            return View();
        }
        [HttpPost]
        public ActionResult OgrenciEkle(Öğrenci p)
        {
            var blm = db.Bölümler.Where(m => m.id == p.BölümİD).FirstOrDefault();
            p.Bölümler = blm;
            db.Öğrenci.Add(p);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
        public ActionResult OgrenciListele()
        {
            var ogr = db.Öğrenci.ToList();
            return View(ogr);
        }
        public ActionResult HocaListele()
        {
            var hoca = db.Hocalar.ToList();
            return View(hoca);
        }
        public ActionResult HocaSil(int id)
        {
            var hoca =db.Hocalar.Find(id);
            db.Hocalar.Remove(hoca);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult OgrenciSil(int id)
        {
            var hoca = db.Öğrenci.Find(id);
            db.Öğrenci.Remove(hoca);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Ekle()
        {
            List<SelectListItem> degerler = (from k in db.Hocalar.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = k.HocaAdi,
                                                 Value = k.id.ToString()
                                             }).ToList();
            List<SelectListItem> degerler1 = (from k in db.Dersler.ToList()
                                              select new SelectListItem
                                              {
                                                  Text = k.DersAdı,
                                                  Value = k.id.ToString()
                                              }).ToList();
            List<SelectListItem> degerler2 = (from k in db.Öğrenci.ToList()
                                              select new SelectListItem
                                              {
                                                  Text = k.İsimSoyisim,
                                                  Value = k.id.ToString()
                                              }).ToList();

            ViewBag.dgr = degerler;
            ViewBag.dgr1 = degerler1;
            ViewBag.dgr2 = degerler2;
            return View();
        }
        [HttpPost]
        public ActionResult Ekle(İliski p)
        {
            var hoca = db.Hocalar.Where(m => m.id == p.HocaİD).FirstOrDefault();
            var ders = db.Dersler.Where(m => m.id == p.DersİD).FirstOrDefault();
            var ogrenci = db.Öğrenci.Where(m => m.id == p.ÖgrenciİD).FirstOrDefault();

            p.Hocalar = hoca;
            p.Dersler = ders;
            p.Öğrenci = ogrenci;

            db.İliski.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index","Hocalar");
        }
    }
}