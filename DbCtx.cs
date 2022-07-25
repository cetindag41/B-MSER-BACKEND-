using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using System.ComponentModel.DataAnnotations;
using PERSONEL_PROJEM.Models;
namespace EF_CORE.Models
{
    public class DbCtx: DbContext
    {

        public DbCtx(DbContextOptions<DbCtx> options) : base(options)
        {
        }

        public DbCtx()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Personel>().HasNoKey();
            modelBuilder.Entity<Mesajlar>().HasNoKey();
            modelBuilder.Entity<Engel>().HasNoKey();
        }


        public DbSet<Personel> BSAT001_CETIN_2 { get; set; }
        public DbSet<Mesajlar> BSAT047_CETIN { get; set; }
        public DbSet<Engel> BSAT047_CETIN_2 { get; set; }
    }

}
