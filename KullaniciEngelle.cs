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
    public class KullaniciEngelle :  Controller
    {
        private readonly ILogger<KullaniciEngelle> _logger;
        private DbCtx Context { get; }
        //private EngelRepo MesajlarRepo { get; }

        public KullaniciEngelle(ILogger<KullaniciEngelle> logger, DbCtx _context)
        {
            _logger = logger;
            this.Context = _context;
        }
        public IActionResult Create(Engel engel)
        {
            using (var EngelDbCtx = new EngelRepo())
            {
                EngelDbCtx.BSAT047_CETIN_2.Add(engel);
                EngelDbCtx.SaveChanges();
            }
            TempData["mesaj"] = "Engel Oluşturuldu";
            return RedirectToAction("KullaniciEngelle", "AnaSayfa");

        }
        [HttpPost]
        public IActionResult EngelKaydet(string ENGELLENEN)
        {

            if (ENGELLENEN == null)
            {
                TempData["mesaj"] = "Lütfen Kullanıcı girin";
                return RedirectToAction("KullaniciEngelle", "AnaSayfa");
            }
            else
            {
                var UserName = HttpContext.Session.GetString("session");
                List<Engel> Engeldurumu = Context.BSAT047_CETIN_2.ToList();
                var EngelVarmi = Engeldurumu.FirstOrDefault(x => x.ENGELLENEN == ENGELLENEN);
                var ID = string.Join("", "1234567890qwertyuiopasdfghjklzxcvbnm".OrderBy(p => Guid.NewGuid()).Take(10));
                if (EngelVarmi == null)
                {
                    var Engellist = new Engel { };
                    Engellist.ID = ID;
                    Engellist.ENGELLEYEN = UserName;
                    Engellist.ENGELLENEN = ENGELLENEN;
                    Engellist.ENGEL_DURUMU = "1";
                    return Create(Engellist);
                }
                else
                {
                    TempData["mesaj"] = "Bu kullanıcıyı daha önce engellemiştiniz";
                    return RedirectToAction("KullaniciEngelle", "AnaSayfa");
                }

            }

        }

    }
}
