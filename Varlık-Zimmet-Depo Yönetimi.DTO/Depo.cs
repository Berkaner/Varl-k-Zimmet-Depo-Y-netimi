using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Varlık_Zimmet_Depo_Yönetimi.DTO
{
    public class Depo
    {
        public int DepoId { get; set; }
        public string DepoAdi { get; set; }
        public string DepoAdresi { get; set;}
        public override string ToString()
        {
            return DepoAdi;
        }
    }
}
