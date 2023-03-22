using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Varlık_Zimmet_Depo_Yönetimi.DTO
{
    public class ZimmetBilgisi
    {
        public int ZimmetBilgisiID { get; set; }
        public Personel personel { get; set; }
        public Urun urun { get; set; }
    }
}
