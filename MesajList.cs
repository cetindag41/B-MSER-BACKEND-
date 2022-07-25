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
    public class MesajList : Controller
    {
        private readonly ILogger<MesajList> _logger;
        private DbCtx Context { get; }
        public MesajList(ILogger<MesajList> logger, DbCtx _context)
        {
            _logger = logger;
            this.Context = _context;
        }

        public IActionResult MesajListele()
        {
            var UserName = HttpContext.Session.GetString("session");
            List<Mesajlar> MESAJLAR = Context.BSAT047_CETIN.ToList();
            var Liste = MESAJLAR.First(a => a.MAILTO == UserName);
            string User = Liste.MAILTO;
            ViewData["mailto"] = User;
            return View(MESAJLAR);
        }
    }
}
