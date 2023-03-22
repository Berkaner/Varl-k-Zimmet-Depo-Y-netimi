using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Varlık_Zimmet_Depo_Yönetimi.DTO
{
    public class Urun
    {
        public int UrunId { get; set; }
        public Model model { get; set; }
        public bool DepodaMi { get; set; }
        public Depo depo { get; set; }
        public UrunGrubu urunGrubu { get; set; }
        public bool UrunGarantiliMi { get; set; }
        public string UrunAciklamasi { get; set; }
        public DateTime UrunGirisTarihi { get; set; }
        public bool UrunEmeklimi { get; set; }
        public DateTime? UrunEmeklilikTarihi { get; set; }
        public bool BarkodVarMi { get; set; }
        public ParaBirimi GuncelFiyatBilgisiBirimi { get; set; }
        public ParaBirimi MaliyetBilgisiBirimi { get; set; }
        public decimal GuncelFiyat { get; set; }
        public decimal Maliyet { get; set; }
        public bool Zimmetlimi { get; set; }
        public Guid BarkodNumarasi { get; set; }
        public int Miktar { get; set; }
        public Birim MiktarBirimi { get; set; }
        public int PersonelId { get; set; }
    }
}
