using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Varlık_Zimmet_Depo_Yönetimi.DTO
{
    public class Sirket
    {
        public int SirketId { get; set; }
        public string SirketAdi { get; set; }
        public Depo depo { get; set; }
    }
}
