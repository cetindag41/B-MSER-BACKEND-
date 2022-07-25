using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PERSONEL_PROJEM.Models
{
    public class Personel
    {

        [Key]
        public string KULLANICI_ADI { get; set; }

        public string ADI { get; set; }
        public string SOYADI { get; set; }
        public string PAROLA { get; set; }

        //public static implicit operator List<object>(Personel v)
        //{
        //    throw new NotImplementedException();
        //}


    }
}