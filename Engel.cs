using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PERSONEL_PROJEM.Models
{
    public class Engel
    {
        [Key]
        public string ID { get; set; }
        public string ENGELLEYEN { get; set; }
        public string ENGELLENEN { get; set; }
        public string ENGEL_DURUMU { get; set; }
    }
}
