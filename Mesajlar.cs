using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PERSONEL_PROJEM.Models
{
    public class Mesajlar
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required]
        public string MESSAGE_ID { get; set; }
        public string MESSAGE_TITLE { get; set; }
        public string MESAGE_VALUE { get; set; }
        public string MAILFROM { get; set; }
        public string MAILTO { get; set; }
    }
}
