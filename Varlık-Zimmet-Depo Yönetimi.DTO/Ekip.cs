using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Varlık_Zimmet_Depo_Yönetimi.DTO
{
    public class Ekip
    {
        public int EkipId { get; set; }
        public string EkipAdi { get; set; }
        public Sirket sirket { get; set; }
    }
}
