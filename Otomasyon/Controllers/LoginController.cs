using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Otomasyon.Models.Entity;
namespace Otomasyon.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        ÖğrenciBilgiSistemiEntities db = new ÖğrenciBilgiSistemiEntities();
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Öğrenci p)
        {
            var ogrenci = db.Öğrenci.FirstOrDefault(x => x.İsimSoyisim == p.İsimSoyisim && x.Sifre == p.Sifre);
           
            if (ogrenci != null)
            {
                FormsAuthentication.SetAuthCookie(ogrenci.İsimSoyisim, false);
                Session["id"] = ogrenci.id;
                Session["OgrenciAdsoyad"] = ogrenci.İsimSoyisim.ToString();
                Session["OgrenciCinsiyet"] = ogrenci.Cinsiyet.ToString();
                Session["OgrenciTel"] = ogrenci.Telefon.ToString();
                Session["OgrenciYas"] = ogrenci.Yas.ToString();
                Session["OgrenciBolum"] = ogrenci.Bölümler.BölümAdı.ToString();
                return RedirectToAction("Index", "Ögrenci");
            }
            else
            {
                ViewBag.msj = "Kullanıcı adı veya şifre geçersiz";
                return View();
            }
        }
        [HttpGet]
        public ActionResult Index1()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index1(Hocalar p)
        {
            var aka = db.Hocalar.FirstOrDefault(x => x.HocaAdi == p.HocaAdi && x.sifre == p.sifre);
          
            if (aka != null)
            {
                FormsAuthentication.SetAuthCookie(aka.HocaAdi, false);
                Session["Hocaİd"] = aka.id;
                Session["HocaAdsoyad"] = aka.HocaAdi.ToString();
                Session["OgrenciÜnvan"] = aka.Ünvan.ToString();
                Session["OgrenciBölüm"] = aka.Bölümler.BölümAdı.ToString();
                return RedirectToAction("Index", "Akademisyen");
            }
            else
            {
                ViewBag.msj = "Kullanıcı adı veya şifre geçersiz";
                return View();
            }
            
        }
        public ActionResult AdminGiris(Admin p)
        {
            var aka = db.Admin.FirstOrDefault(x => x.adminUser ==p.adminUser  && x.Sifre == p.Sifre);

            if (aka != null)
            {
                FormsAuthentication.SetAuthCookie(aka.adminUser, false);
                Session["Admin"] = aka.id.ToString();
                Session["AdminAdsoyad"] = aka.adminUser.ToString();
                Session["AdminSifre"] = aka.Sifre.ToString();
                
                return RedirectToAction("Index", "Hocalar");
            }
            else
            {
                ViewBag.msj = "Kullanıcı adı veya şifre geçersiz";
                return View();
            }
        }
    }
}