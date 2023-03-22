using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Varlık_Zimmet_Depo_Yönetimi.DTO
{
    public class Personel
    {
        public int PersonelId { get; set; }
        public string PersonelAdi { get; set; }
        public Ekip ekip { get; set; }
        public Yetki yetki { get; set; }

        public override string ToString()
        {
            return PersonelAdi;
        }

    }
}
