using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Varlık_Zimmet_Depo_Yönetimi.DTO
{
    public class ParaBirimi
    {
        public int ParaBirimiId { get; set; }
        public string ParaBirimiAdi { get; set; }
        public override string ToString()
        {
            return ParaBirimiAdi;
        }
    }
}
