using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Varlık_Zimmet_Depo_Yönetimi.DTO
{
    public class Birim
    {
        public int BirimId { get; set; }
        public string BirimAdi { get; set;}
        public override string ToString()
        {
            return BirimAdi;
        }
    }
}
