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
using Microsoft.AspNetCore.Http;
using DocuSign.eSign.Model;

namespace PERSONEL_PROJEM.Controllers
{
    public class AnaSayfaController : Controller
    {
        private readonly ILogger<AnaSayfaController> _logger;
        private DbCtx Context { get; }
        public AnaSayfaController(ILogger<AnaSayfaController> logger, DbCtx _context)
        {
            _logger = logger;
            this.Context = _context;
        }

        public IActionResult Index()
        {
            var UserName = HttpContext.Session.GetString("session");
            List<Personel> Kullanicilar = Context.BSAT001_CETIN_2.ToList();
            var Liste = Kullanicilar.First(a => a.KULLANICI_ADI == UserName);
            string User = Liste.KULLANICI_ADI;
            string ADI = Liste.ADI;
            string SOYADI = Liste.SOYADI;
            ViewData["mailto"] = User;
            ViewData["ADI"] = ADI;
            ViewData["SOYADI"] = SOYADI;
            return View();
        }

        //[HttpPost]
        ////public IActionResult AnaSayfa()
        ////{

        ////    //string user_ID = Request.Form["UserName"];
        ////    ////string KullanıcıAdı = Request.QueryString["userName"];
        ////    ////var KullaniciAdi = UserName;
        ////    ////List<Personel> Kullanicilar = Context.BSAT001_CETIN_2.ToList();
        ////    //////string AD = Kullanicilar.Where(x => x.ADI == UserName);
        ////    ////var AD = Kullanicilar.Single(a => a.ADI == UserName);
        ////    ////ViewData["user_name"] = AD;
        ////    return View();
        ////}

        public IActionResult Cıkıs()
        {
            return RedirectToAction("Index", "Home");
        }
        public IActionResult YeniMesajGonder()
        {
            return View(); 
        }
        public IActionResult KullaniciEngelle()
        {
            return View();
        }
    }
}
