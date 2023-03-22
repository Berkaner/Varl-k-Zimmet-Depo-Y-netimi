using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Varlık_Zimmet_Depo_Yönetimi.DTO;
using Varlık_Zimmet_Depo_Yönetimi.MyProvider;

namespace Varlık_Zimmet_Depo_Yönetimi.Varlık_Zimmet_Depo_YönetimiUI
{
    public partial class Rapor2 : Form
    {
        List<Urun> urunListem = new List<Urun>();
        private Personel personel;

        public Rapor2()
        {
            InitializeComponent();
        }

        public Rapor2(Personel personel):this()
        {
            this.personel = personel;
        }

        private void Rapor2_Load(object sender, EventArgs e)
        {
            cmbZimmeteYukle();
        }

        private void cmbZimmeteYukle()
        {
            cmbZimmet.Items.Add(new { Text = "Zimmetli", Tag = 1 });
            cmbZimmet.Items.Add(new { Text = "Zimmetsiz", Tag = 0 });
            cmbZimmet.DisplayMember = "Text";
        }

        private void cmbZimmet_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            ZimmetliVeyaZimmetsizUrunYukle((cmbZimmet.SelectedItem as dynamic).Tag);
            UrunleriYukle();
        }

        private void UrunleriYukle()
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();


            dataGridView1.ReadOnly = true; //satırların yazma özelliğini kapama
            dataGridView1.Columns.Add("Urun Id", "Urun Id");
            dataGridView1.Columns.Add("Barkod No", "Barkod No");
            dataGridView1.Columns.Add("Miktar", "Miktar");
            dataGridView1.Columns.Add("BirimAdi", "BirimAdi");
            dataGridView1.Columns.Add("MOdel Adı", "MOdel Adı");
            dataGridView1.Columns.Add("Marka Adı", "Marka Adı");
            dataGridView1.Columns.Add("Urun Tipi", "Urun Tipi");
            dataGridView1.Columns.Add("Urun Grubu", "Urun Grubu");
            dataGridView1.Columns.Add("Depodamı", "Depodamı");
            dataGridView1.Columns.Add("Depo Adı", "Depo Adı");
            dataGridView1.Columns.Add("Urun GArantilimi", "Urun GArantilimi");
            dataGridView1.Columns.Add("Urun Açıklaması", "Urun Açıklaması");
            dataGridView1.Columns.Add("Urunnün Giriş Tarihi", "Urunnün Giriş Tarihi");
            dataGridView1.Columns.Add("Urun Emeklimi", "Urun Emeklimi");
            dataGridView1.Columns.Add("Urunün Emeklilik Tarihi", "Urunün Emeklilik Tarihi");
            dataGridView1.Columns.Add("Urunün Güncel Fiyatı", "Urunün Güncel Fiyatı");
            dataGridView1.Columns.Add("Urunün Güncel Fiyatı Birimi", "Urunün Güncel Fiyatı Birimi");
            dataGridView1.Columns.Add("Urunün Maliyeti", "Urunün Maliyeti");
            dataGridView1.Columns.Add("Urunün Maliyet Birimi", "Urunün Maliyet Birimi");
            dataGridView1.Columns.Add("Zimmetlimi", "Zimmetlimi");
            


            foreach (Urun item in urunListem)
            {

                dataGridView1.Rows.Add(item.UrunId, item.BarkodNumarasi, item.Miktar, item.MiktarBirimi.BirimAdi, item.model.ModelAdi, item.model.marka.MarkaAdi, item.model.urunTipi.UrunTipiAdi, item.urunGrubu.UrunGrubuAdi, item.DepodaMi, item.depo.DepoAdi, item.UrunGarantiliMi, item.UrunAciklamasi, item.UrunGirisTarihi, item.UrunEmeklimi, item.UrunEmeklilikTarihi, item.GuncelFiyat, item.GuncelFiyatBilgisiBirimi.ParaBirimiAdi, item.Maliyet, item.MaliyetBilgisiBirimi.ParaBirimiAdi, item.Zimmetlimi);




            }
        }

        private void ZimmetliVeyaZimmetsizUrunYukle(dynamic tag)
        {
            MSSQLProvider provider = new MSSQLProvider($"select Urun.UrunId as UrunKodu, ISNULL(Urun.BarkodNumarasi, '00000000-0000-0000-0000-000000000000') as BarkotNo , ISNULL(Urun.Miktar, '0') as Miktar , ISNULL(Birim.BirimId, '0') as BirimId, ISNULL(Birim.BirimAdi, '0') as BirimAdi , Model.ModelId , Model.ModelAdi as ModelAdi, Marka.MarkaId , Marka.MarkaAdi, UrunTipi.UrunTipiId, UrunTipi.UrunTipiAdi, UrunGrubu.UrunGrubuId, UrunGrubu.UrunGrubuAdi, Urun.DepodaMi,Depo.DepoId , Depo.DepoAdi, Urun.UrunGarantiliMi, Urun.UrunAciklamasi, Urun.UrunGirisTarihi, Urun.UrunEmeklimi, Urun.UrunEmeklilikTarihi, Urun.BarkodVarMi, Urun.GuncelFiyat, GuncelFiyatBirimi.ParaBirimiId, GuncelFiyatBirimi.ParaBirimiAdi, Urun.Maliyet,MaliyetBirimi.ParaBirimiId, MaliyetBirimi.ParaBirimiAdi, Urun.Zimmetlimi, ISNULL(ZimmetBilgisi.PersonelId , '0') as Zimmetli from Urun  inner join Model on Urun.ModelId=Model.ModelId   inner join UrunTipi on Model.UrunTipiId=UrunTipi.UrunTipiId   inner join Marka on Model.MarkaID=Marka.MarkaId   inner join UrunGrubu on Urun.UrunGrubuId=UrunGrubu.UrunGrubuId  inner join ParaBirimi as GuncelFiyatBirimi on Urun.GuncelFiyatBilgisiBirimiId=GuncelFiyatBirimi.ParaBirimiId    inner join ParaBirimi as MaliyetBirimi on Urun.MaliyetBilgisiBirimiId=MaliyetBirimi.ParaBirimiId   inner join Depo on Urun.DepoId=Depo.DepoId   left join ZimmetBilgisi on Urun.UrunId=ZimmetBilgisi.UrunId  left join Birim on Urun.MiktarBirimId=Birim.BirimId where Urun.Zimmetlimi='{tag}'");


            SqlDataReader reader = provider.ExcuteredaerOlustur();

            urunListem.Clear();

            if (reader.HasRows)
            {

                while (reader.Read())
                {

                    Urun urun = new Urun();
                    urun.MiktarBirimi = new Birim();
                    urun.model = new Model();
                    urun.model.marka = new Marka();
                    urun.model.urunTipi = new UrunTipi();
                    urun.urunGrubu = new UrunGrubu();
                    urun.depo = new Depo();
                    urun.GuncelFiyatBilgisiBirimi = new ParaBirimi();
                    urun.MaliyetBilgisiBirimi = new ParaBirimi();


                    urun.UrunId = reader.GetInt32(0);
                    urun.BarkodNumarasi = reader.GetGuid(1);
                    urun.Miktar = reader.GetInt32(2);
                    urun.MiktarBirimi.BirimId = reader.GetInt32(3);
                    urun.MiktarBirimi.BirimAdi = reader.GetString(4);
                    urun.model.ModelId = reader.GetInt32(5);
                    urun.model.ModelAdi = reader.GetString(6);
                    urun.model.marka.MarkaID = reader.GetInt32(7);
                    urun.model.marka.MarkaAdi = reader.GetString(8);
                    urun.model.urunTipi.UrunTipiId = reader.GetInt32(9);
                    urun.model.urunTipi.UrunTipiAdi = reader.GetString(10);
                    urun.urunGrubu.UrunGrubuId = reader.GetInt32(11);
                    urun.urunGrubu.UrunGrubuAdi = reader.GetString(12);
                    urun.DepodaMi = reader.GetBoolean(13);
                    urun.depo.DepoId = reader.GetInt32(14);
                    urun.depo.DepoAdi = reader.GetString(15);
                    urun.UrunGarantiliMi = reader.GetBoolean(16);
                    urun.UrunAciklamasi = reader.GetString(17);
                    urun.UrunGirisTarihi = reader.GetDateTime(18);
                    urun.UrunEmeklimi = reader.GetBoolean(19);
                    urun.UrunEmeklilikTarihi = reader.GetDateTime(20);
                    urun.BarkodVarMi = reader.GetBoolean(21);
                    urun.GuncelFiyat = reader.GetDecimal(22);
                    urun.GuncelFiyatBilgisiBirimi.ParaBirimiId = reader.GetInt32(23);
                    urun.GuncelFiyatBilgisiBirimi.ParaBirimiAdi = reader.GetString(24);
                    urun.Maliyet = reader.GetDecimal(25);
                    urun.MaliyetBilgisiBirimi.ParaBirimiId = reader.GetInt32(26);
                    urun.MaliyetBilgisiBirimi.ParaBirimiAdi = reader.GetString(27);
                    urun.Zimmetlimi = reader.GetBoolean(28);



                    urunListem.Add(urun);

                }
            }



        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex <= 0) // 1. sütuna tıklanması
            {
                // Tıklanan hücrenin içeriğine erişiyoruz
                string UrunNo = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();


                MessageBox.Show("Urun Numarası: " + UrunNo);

                UrunBilgisi urunBilgisi = new UrunBilgisi(UrunNo, personel);
                urunBilgisi.Show();



            }
        }
    }
}
