using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApplication1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using EF_CORE.Models;
using PERSONEL_PROJEM.Models;
using Microsoft.EntityFrameworkCore.SqlServer;



namespace PERSONEL_PROJEM.Controllers
{
    public class PersonelCreate : Controller
    {
        private readonly ILogger<PersonelCreate> _logger;
        private DbCtx Context { get; }
        private KullaniciRepo KullaniciRepo { get; }

        public PersonelCreate(ILogger<PersonelCreate> logger, DbCtx _context)
        {
            _logger = logger;
            this.Context = _context;
        }

        public IActionResult PersonelEkle()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Personel personel)
        {
            using (var PersonelDbCtx = new KullaniciRepo())
            {
                PersonelDbCtx.BSAT001_CETIN_2.Add(personel);
                PersonelDbCtx.SaveChanges();
                //return personel;
            }
            //KullaniciRepo.Create(personel);
            //KullaniciRepo.SaveChanges();
            TempData["mesaj"] = "Kayıt başarılı";
            return RedirectToAction("PersonelEkle", "PersonelCreate");

            //return View();

        }

        [HttpPost]
        public IActionResult PersonelKaydet(string KULLANICI_ADI, string AD, string SOYADI, string PAROLA)
        {
            //string user_ID = Request.Form["KULLANICI_ADI"];
            //string user_PASS = Request.Form["password"];


            if (KULLANICI_ADI == null || AD == null || SOYADI == null || PAROLA == null)
            {
                TempData["mesaj"] = "Lütfen tüm alanları doldurun"; 
                return RedirectToAction("PersonelEkle", "PersonelCreate");
            }
            else
            {
                
                List<Personel> Kullanicilar = Context.BSAT001_CETIN_2.ToList();
                var userInDb = Kullanicilar.SingleOrDefault(x => x.KULLANICI_ADI == KULLANICI_ADI);

                if (userInDb == null)
                {
                    var personel = new Personel {};
                    personel.KULLANICI_ADI = KULLANICI_ADI;
                    personel.ADI = AD;
                    personel.SOYADI = SOYADI;
                    personel.PAROLA = PAROLA;

                    //////KullaniciRepo.Attach(personel);
                    ////KullaniciRepo.Create(personel);
                    ////KullaniciRepo.SaveChanges();
                    //TempData["mesaj"] = "Kayıt başarılı";
                    //return RedirectToAction("PersonelEkle", "PersonelCreate");
                    return Create(personel);
                }
                else
                {
                    TempData["mesaj"] = "Kullanıcı adı mevcut, lütfen farklı bir kullanıcı adı kullanının";
                    return RedirectToAction("PersonelEkle", "PersonelCreate");
                }

            }

        }
    }
}
