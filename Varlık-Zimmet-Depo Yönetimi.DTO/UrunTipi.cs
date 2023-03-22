using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Varlık_Zimmet_Depo_Yönetimi.DTO
{
    public  class UrunTipi
    {
        public int UrunTipiId { get; set; }
        public string UrunTipiAdi { get;set; }
        public override string ToString()
        {
            return UrunTipiAdi;
        }
    }
}
