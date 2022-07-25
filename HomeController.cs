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

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private DbCtx Context { get; }

        public HomeController(ILogger<HomeController> logger, DbCtx _context)
        {
            _logger = logger;
            this.Context = _context;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(string userName, string password)
        {
            
            if (userName == null && password == null) 
            {
                TempData["mesaj"] = "Lütfen kullanıcı bilgilerini girin";
                return RedirectToAction("Index", "Home");             
            } else 
            {
                List<Personel> Kullanicilar = Context.BSAT001_CETIN_2.ToList();
                var userInDb = Kullanicilar.FirstOrDefault(x => x.KULLANICI_ADI == userName && x.PAROLA == password);
                

                if (userInDb != null)
                {
                    string UserName = userName;
                    return Yonlendir(userName);
                }
                else
                {
                    TempData["mesaj"] = "Kullanıcı bilgileri hatalı";
                    return RedirectToAction("Index", "Home");
                }
            }

        }
        public IActionResult Yonlendir(string UserName)
        {
            HttpContext.Session.SetString("session",UserName);
            return RedirectToAction("Index", "AnaSayfa");
        }


    }


}
