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
    public class MesajGonder : Controller
    {
        private readonly ILogger<MesajGonder> _logger;
        private DbCtx Context { get; }
        private MesajlarRepo MesajlarRepo { get; }

        public MesajGonder(ILogger<MesajGonder> logger, DbCtx _context)
        {
            _logger = logger;
            this.Context = _context;
        }

        public IActionResult Create(Mesajlar mesajlar)
        {
            using (var MesajDbCtx = new MesajlarRepo())
            {
                MesajDbCtx.BSAT047_CETIN.Add(mesajlar);
                MesajDbCtx.SaveChanges();
            }
            TempData["mesaj"] = "Mesaj Gönderildi";
            return RedirectToAction("YeniMesajGonder", "AnaSayfa");

        }
        [HttpPost]
        public IActionResult MesajKaydet(string MAILTO, string MESSAGE_TITLE, string MESSAGE_VALUE)
        {

            if (MAILTO == null || MESSAGE_TITLE == null || MESSAGE_VALUE == null)
            {
                TempData["mesaj"] = "Lütfen tüm alanları doldurun";
                return RedirectToAction("YeniMesajGonder", "AnaSayfa");
            }
            else
            {
                var UserName = HttpContext.Session.GetString("session");
                List<Engel> Engeldurumu = Context.BSAT047_CETIN_2.ToList();
                var EngelVarmi = Engeldurumu.FirstOrDefault(x => x.ENGELLENEN == UserName);
                var MESSAGE_ID = string.Join("", "1234567890qwertyuiopasdfghjklzxcvbnm".OrderBy(p => Guid.NewGuid()).Take(10));
                if (EngelVarmi == null)
                {
                    var Mesajlars = new Mesajlar { };
                    Mesajlars.MESSAGE_ID = MESSAGE_ID;
                    Mesajlars.MAILFROM = UserName;
                    Mesajlars.MAILTO = MAILTO;
                    Mesajlars.MESSAGE_TITLE = MESSAGE_TITLE;
                    Mesajlars.MESAGE_VALUE = MESSAGE_VALUE;                    
                    return Create(Mesajlars);
                }
                else
                {
                    TempData["mesaj"] = "Bu kullanıcıya mesaj gönderemezsiniz";
                    return RedirectToAction("YeniMesajGonder", "AnaSayfa");
                }

            }

        }
    }
}
