using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Varlık_Zimmet_Depo_Yönetimi.DTO
{
    public class Model
    {
        public int ModelId { get; set; }
        public string ModelAdi { get; set; }
        public Marka marka { get; set; }
        public UrunTipi urunTipi { get; set; }
        public override string ToString()
        {
            return ModelAdi;
        }
    }
}
