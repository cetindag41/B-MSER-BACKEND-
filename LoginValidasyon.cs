using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace PERSONEL_PROJEM.Models
{
    public partial class LoginValidasyon
    {
        [Required(ErrorMessage = "Alan boş geçilemez")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Alan boş geçilemez")]
        public string PASSWORD { get; set; }

    }
}
