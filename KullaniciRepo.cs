using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using System.ComponentModel.DataAnnotations;
using PERSONEL_PROJEM.Models;
using System.Data;
using EF_CORE.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApplication1.Models;
using Microsoft.Extensions.Configuration;


namespace PERSONEL_PROJEM.Models
{
    public class KullaniciRepo : DbContext
    {
        ////private static List<Personel> allPersonel = new List<Personel>();
        ////public static IEnumerable<Personel> AllPersonel
        ////{
        ////    get { return allPersonel; }
        ////}
        //private DbCtx _context;
        //public KullaniciRepo(DbCtx dbCtx)
        //{
        //    this._context = dbCtx;
        //}
        //public DbSet<Personel> BSAT001_CETIN_2 { get; set; }
        ////public DbCtx Context { get => _context; set => _context = value; }

        //    public Personel Create(Personel personel)
        //    {
        //        using (var PersonelDbCtx = new DbCtx())
        //        {
        //            PersonelDbCtx.BSAT001_CETIN_2.Add(personel);
        //            PersonelDbCtx.SaveChanges();
        //            return personel;
        //        }
        //            ////allPersonel.Add(personel);
        //            //DbCtx.BSAT001_CETIN_2.Add(personel);
        //    }
        public KullaniciRepo(DbContextOptions<KullaniciRepo> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {

            options.UseSqlServer("Data Source=SQLSRV;Initial Catalog=QDMSV2_524;Persist Security Info=True;User ID=qdmsuser;Password=Bc3414314;persist security info=True;");
        }
        public KullaniciRepo()
        {
        }
        public KullaniciRepo(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Personel>().HasNoKey();
            modelBuilder.Entity<Personel>().HasKey(s => s.KULLANICI_ADI);
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Personel> BSAT001_CETIN_2 { get; set; }
    }
}
