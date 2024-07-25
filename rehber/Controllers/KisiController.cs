using rehber.Models.Context;
using rehber.Models.Entities;
using rehber.Models.KisiModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace rehber.Controllers
{
    public class KisiController : Controller
    {
        MvcRehberContext db = new MvcRehberContext();
        // GET: Kisi
        public ActionResult Index()
        {

            var simdikiKullanici = Convert.ToInt32(Session["IdSS"]);

            var model = new KisiIndexViewModel
            {
                Kisiler = db.Kisiler.Where(x=> x.CurrentId==simdikiKullanici).ToList(),
                Sehirler = db.Sehirler.ToList(),
                //Kullanicilar = db.Kullanicilar.ToList(),
            };
            return View(model);
        }
        [HttpGet]
        public ActionResult Ekle()
        {
            var model = new KisiEkleViewModel
            {
                Kisi = new Kisi(),
                Sehirler = db.Sehirler.ToList(),
                Kullanicilar = db.Kullanicilar.ToList(),

            };
            return View(model);

        }
        [HttpPost]
        public ActionResult Ekle(Kisi kisi)
        {
            try
            {
                kisi.CurrentId = Convert.ToInt32(Session["IdSS"]);
                db.Kisiler.Add(kisi);
                db.SaveChanges();

                TempData["BasariliMesaj"] = "Ekleme İşlemi Başarıyla Gerçekleşti.";

            }
            catch (Exception)
            {
                TempData["HataliMesaj"] = "Hata Oluştu! Lütfen Yeniden Deneyiniz.";

            }




            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Guncelle(int id)
        {
            var kisi =db.Kisiler.Find(id);
            
            if(kisi == null)
            {
                TempData["HataliMesaj"] = "Güncellenmek istenen kayıt bulunamadı!";
                return RedirectToAction("Index");

            }
            var model = new KisiGuncelleViewModel
            {
                Kisi = kisi,
                Sehirler = db.Sehirler.ToList(),
            };

            ViewBag.Sehirler = new SelectList(db.Sehirler.ToList(), "Id", "SehirAdi");
            return View(model);
            
        }
        [HttpPost]
        public ActionResult Guncelle(Kisi kisi)
        {
            var eskiKisi = db.Kisiler.Find(kisi.Id);

            if(eskiKisi == null)
            {
                TempData["HataliMesaj"] = "Güncellenmek istenen kayıt bulunamadı!";
                return RedirectToAction("Index");

            }
            eskiKisi.Ad = kisi.Ad;
            eskiKisi.SoyAd = kisi.SoyAd;
            eskiKisi.Telefon = kisi.Telefon;
            eskiKisi.Email = kisi.Email;
            eskiKisi.Adres = kisi.Adres;
            eskiKisi.SehirId= kisi.SehirId;

            db.SaveChanges();

            TempData["BasariliMesaj"] = "Kişi Bilgeleri Başarıyla Güncellendi.";


            return RedirectToAction("Index");

        }

        [HttpGet]

        public ActionResult Detay(int id,string username)
        {

            var kisi = db.Kisiler.Find(id);
            var kullanici = db.Kullanicilar.Find(username);

            if (kisi == null)
            {
                TempData["HataliMesaj"] = "Kişi Bulunamadı!";
                return RedirectToAction("Index");

            }
            var model = new KisiDetayViewModel
            {
                Kisi = kisi,
                Kullanici = kullanici,
                Sehirler = db.Sehirler.ToList()
                
            };
            return View(model);
        }

        public ActionResult Sil(int id)
        {
            var kisi = db.Kisiler.Find(id);

            if(kisi == null)
            {
                TempData["HataliMesaj"] = "Kişi Bulunamadı!";
                return RedirectToAction("Index");
            }
            db.Kisiler.Remove(kisi);
            db.SaveChanges();

            TempData["BasariliMesaj"] = "Kişi Veritabanından Silinmiştir";


            return RedirectToAction("Index");
        }
        public ActionResult MailGonder(int id)
        {
            var kisi = db.Kisiler.Find(id);
            if (kisi == null)
            {
                TempData["HataliMesaj"] = "Kişi Bulunamadı!";
                return RedirectToAction("Index");
            }
            return View(kisi);
        }
        [HttpPost]
        public ActionResult MailGonder(string MailAdres,string Baslik,string Mesaj)
        {
            try
            {
                var gondericimail = new MailAddress("hfgdeneme@gmail.com");
                var sifre = "salata123";
                var aliciMail = new MailAddress(MailAdres);

                var smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(gondericimail.Address, sifre)

                };

                using (var msg = new MailMessage(gondericimail, aliciMail)
                {
                    IsBodyHtml = true,
                    Subject = Baslik,
                    Body = Mesaj,

                })
                {
                    smtp.Send(msg);
                }
                TempData["BasariliMesaj"] = "Mail Gönderme İşlemi Başarıyla Gerçekleşti";
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                TempData["HataliMesaj"] = "Mail Gönderme İşlemi Sırasında Hata Oluştu";
                return RedirectToAction("Index");
            }
        }

    }
}