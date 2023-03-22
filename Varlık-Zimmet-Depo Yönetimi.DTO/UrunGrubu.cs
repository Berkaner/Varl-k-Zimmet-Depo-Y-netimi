using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Varlık_Zimmet_Depo_Yönetimi.DTO
{
    public class UrunGrubu
    {
        public int UrunGrubuId { get; set; }
        public string UrunGrubuAdi { get; set; }
        public override string ToString()
        {
            return UrunGrubuAdi;
        }
    }
}
