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
    public class EngelRepo : DbContext
    {
        public EngelRepo(DbContextOptions<EngelRepo> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {

            options.UseSqlServer("Data Source=SQLSRV;Initial Catalog=QDMSV2_524;Persist Security Info=True;User ID=qdmsuser;Password=Bc3414314;persist security info=True;");
        }
        public EngelRepo()
        {
        }
        public EngelRepo(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Personel>().HasNoKey();
            modelBuilder.Entity<Engel>().HasKey(s => s.ID);
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Engel> BSAT047_CETIN_2 { get; set; }
    }
}
