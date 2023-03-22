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
    public partial class AnaSayfa : Form
    {
        Button btnMenuAc = new Button();
        private Personel personel;
        List<Urun> listem = new List<Urun>();
        

        public AnaSayfa()
        {
            InitializeComponent();
        }

        public AnaSayfa(Personel personel):this()
        {
            this.personel = personel;
        }

        private void btnMenü_Click(object sender, EventArgs e)
        {
            btnKayitEkle.Visible= false;
            btnMenü.Visible= false;
            pnlMenu.Width = 100;
            btnRapor1.Visible = false;
            btnRapor2.Visible = false;

            btnMenuAc.Visible = true;

        }

        private void PaneleButonEkle()
        {
            btnMenuAc.Name = "btnMenüAc";
            btnMenuAc.Visible= false;
            btnMenuAc.Text = ">";
            btnMenuAc.Width = 54;
            btnMenuAc.Height = 44;
            btnMenuAc.Click += new EventHandler(btnMenüAc_Click);
        }

        private void btnMenüAc_Click(object sender, EventArgs e)
        {
            btnMenuAc.Visible= false;
            btnKayitEkle.Visible = true;
            btnMenü.Visible = true;
            btnRapor1.Visible = true;
            btnRapor2.Visible = true;
            pnlMenu.Width = 203;
        }

        private void AnaSayfa_Load(object sender, EventArgs e)
        {
            lblPersonelAdi.Text = personel.ToString();
            PaneleButonEkle();
            pnlMenu.Controls.Add(btnMenuAc);

            if (personel.yetki.YetkiId==1)
            {
                btnTumVarliklar.Visible= true;
            }
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            PersonelGirisi personelGirisi= new PersonelGirisi();
            personelGirisi.Show();

        }

        private void btnVarliklarim_Click(object sender, EventArgs e)
        {
            

            ZimmetliUrunListesiYukle();


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
            


            foreach (Urun item in listem)
            {

                dataGridView1.Rows.Add(item.UrunId, item.BarkodNumarasi, item.Miktar,item.MiktarBirimi.BirimAdi, item.model.ModelAdi, item.model.marka.MarkaAdi, item.model.urunTipi.UrunTipiAdi,item.urunGrubu.UrunGrubuAdi, item.DepodaMi, item.depo.DepoAdi, item.UrunGarantiliMi, item.UrunAciklamasi, item.UrunGirisTarihi, item.UrunEmeklimi, item.UrunEmeklilikTarihi, item.GuncelFiyat, item.GuncelFiyatBilgisiBirimi.ParaBirimiAdi, item.Maliyet, item.MaliyetBilgisiBirimi.ParaBirimiAdi, item.Zimmetlimi);
                  



            }
        }

        private void ZimmetliUrunListesiYukle()
        {
            
            MSSQLProvider provider = new MSSQLProvider($"select Urun.UrunId as UrunKodu, ISNULL(Urun.BarkodNumarasi, '00000000-0000-0000-0000-000000000000') as BarkotNo , ISNULL(Urun.Miktar, '0') as Miktar , ISNULL(Birim.BirimId, '0') as BirimId, ISNULL(Birim.BirimAdi, '0') as BirimAdi , Model.ModelId , Model.ModelAdi as ModelAdi, Marka.MarkaId , Marka.MarkaAdi, UrunTipi.UrunTipiId, UrunTipi.UrunTipiAdi, UrunGrubu.UrunGrubuId, UrunGrubu.UrunGrubuAdi, Urun.DepodaMi,Depo.DepoId , Depo.DepoAdi, Urun.UrunGarantiliMi, Urun.UrunAciklamasi, Urun.UrunGirisTarihi, Urun.UrunEmeklimi, Urun.UrunEmeklilikTarihi, Urun.BarkodVarMi, Urun.GuncelFiyat, GuncelFiyatBirimi.ParaBirimiId, GuncelFiyatBirimi.ParaBirimiAdi, Urun.Maliyet,MaliyetBirimi.ParaBirimiId, MaliyetBirimi.ParaBirimiAdi, Urun.Zimmetlimi  from Urun  inner join Model on Urun.ModelId=Model.ModelId   inner join UrunTipi on Model.UrunTipiId=UrunTipi.UrunTipiId   inner join Marka on Model.MarkaID=Marka.MarkaId   inner join UrunGrubu on Urun.UrunGrubuId=UrunGrubu.UrunGrubuId  inner join ParaBirimi as GuncelFiyatBirimi on Urun.GuncelFiyatBilgisiBirimiId=GuncelFiyatBirimi.ParaBirimiId    inner join ParaBirimi as MaliyetBirimi on Urun.MaliyetBilgisiBirimiId=MaliyetBirimi.ParaBirimiId   inner join Depo on Urun.DepoId=Depo.DepoId   inner join ZimmetBilgisi on Urun.UrunId=ZimmetBilgisi.UrunId  left join Birim on Urun.MiktarBirimId=Birim.BirimId where ZimmetBilgisi.PersonelId='{personel.PersonelId}'");


            SqlDataReader reader = provider.ExcuteredaerOlustur();



            listem.Clear();


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
                    urun.Zimmetlimi= reader.GetBoolean(28);



                    listem.Add(urun);

                }
            }



        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0 && e.ColumnIndex <= 0) // 1. sütuna tıklanması
            {
                // Tıklanan hücrenin içeriğine erişiyoruz
                string UrunNo = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();

                
                MessageBox.Show("Urun Numarası: " + UrunNo);

                UrunBilgisi urunBilgisi=new UrunBilgisi(UrunNo, personel);
                urunBilgisi.Show();



            }


            
        }

        private void btnEkibiminVarlıkları_Click(object sender, EventArgs e)
        {
            
            EkibiminVArliklari();

            UrunleriYukle();
        }

        private void EkibiminVArliklari()
        {
            MSSQLProvider provider = new MSSQLProvider($"select Urun.UrunId as UrunKodu, ISNULL(Urun.BarkodNumarasi, '00000000-0000-0000-0000-000000000000') as BarkotNo , ISNULL(Urun.Miktar, '0') as Miktar , ISNULL(Birim.BirimId, '0') as BirimId, ISNULL(Birim.BirimAdi, '0') as BirimAdi , Model.ModelId , Model.ModelAdi as ModelAdi, Marka.MarkaId , Marka.MarkaAdi, UrunTipi.UrunTipiId, UrunTipi.UrunTipiAdi, UrunGrubu.UrunGrubuId, UrunGrubu.UrunGrubuAdi, Urun.DepodaMi,Depo.DepoId , Depo.DepoAdi, Urun.UrunGarantiliMi, Urun.UrunAciklamasi, Urun.UrunGirisTarihi, Urun.UrunEmeklimi, Urun.UrunEmeklilikTarihi, Urun.BarkodVarMi, Urun.GuncelFiyat, GuncelFiyatBirimi.ParaBirimiId, GuncelFiyatBirimi.ParaBirimiAdi, Urun.Maliyet,MaliyetBirimi.ParaBirimiId, MaliyetBirimi.ParaBirimiAdi, Urun.Zimmetlimi  from Urun  inner join Model on Urun.ModelId=Model.ModelId   inner join UrunTipi on Model.UrunTipiId=UrunTipi.UrunTipiId   inner join Marka on Model.MarkaID=Marka.MarkaId   inner join UrunGrubu on Urun.UrunGrubuId=UrunGrubu.UrunGrubuId  inner join ParaBirimi as GuncelFiyatBirimi on Urun.GuncelFiyatBilgisiBirimiId=GuncelFiyatBirimi.ParaBirimiId    inner join ParaBirimi as MaliyetBirimi on Urun.MaliyetBilgisiBirimiId=MaliyetBirimi.ParaBirimiId   inner join Depo on Urun.DepoId=Depo.DepoId   inner join ZimmetBilgisi on Urun.UrunId=ZimmetBilgisi.UrunId  left join Birim on Urun.MiktarBirimId=Birim.BirimId inner join Personel on ZimmetBilgisi.PersonelId=Personel.PersonelId inner join Ekip on Personel.EkipId=Ekip.EkipId where Ekip.EkipId='{personel.ekip.EkipId}'");


            SqlDataReader reader = provider.ExcuteredaerOlustur();




            listem.Clear();

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



                    listem.Add(urun);

                }
            }

        }

        private void btnTumVarliklar_Click(object sender, EventArgs e)
        {
            TumUrunleriYukle();
            UrunleriYukle();
        }

        private void TumUrunleriYukle()
        {
            MSSQLProvider provider = new MSSQLProvider("select Urun.UrunId as UrunKodu, ISNULL(Urun.BarkodNumarasi, '00000000-0000-0000-0000-000000000000') as BarkotNo , ISNULL(Urun.Miktar, '0') as Miktar , ISNULL(Birim.BirimId, '0') as BirimId, ISNULL(Birim.BirimAdi, '0') as BirimAdi , Model.ModelId , Model.ModelAdi as ModelAdi, Marka.MarkaId , Marka.MarkaAdi, UrunTipi.UrunTipiId, UrunTipi.UrunTipiAdi, UrunGrubu.UrunGrubuId, UrunGrubu.UrunGrubuAdi, Urun.DepodaMi,Depo.DepoId , Depo.DepoAdi, Urun.UrunGarantiliMi, Urun.UrunAciklamasi, Urun.UrunGirisTarihi, Urun.UrunEmeklimi, Urun.UrunEmeklilikTarihi, Urun.BarkodVarMi, Urun.GuncelFiyat, GuncelFiyatBirimi.ParaBirimiId, GuncelFiyatBirimi.ParaBirimiAdi, Urun.Maliyet,MaliyetBirimi.ParaBirimiId, MaliyetBirimi.ParaBirimiAdi, Urun.Zimmetlimi, ISNULL(ZimmetBilgisi.PersonelId , '0') as Zimmetli  from Urun  inner join Model on Urun.ModelId=Model.ModelId   inner join UrunTipi on Model.UrunTipiId=UrunTipi.UrunTipiId   inner join Marka on Model.MarkaID=Marka.MarkaId   inner join UrunGrubu on Urun.UrunGrubuId=UrunGrubu.UrunGrubuId  inner join ParaBirimi as GuncelFiyatBirimi on Urun.GuncelFiyatBilgisiBirimiId=GuncelFiyatBirimi.ParaBirimiId    inner join ParaBirimi as MaliyetBirimi on Urun.MaliyetBilgisiBirimiId=MaliyetBirimi.ParaBirimiId   inner join Depo on Urun.DepoId=Depo.DepoId   left join ZimmetBilgisi on Urun.UrunId=ZimmetBilgisi.UrunId  left join Birim on Urun.MiktarBirimId=Birim.BirimId");


            SqlDataReader reader = provider.ExcuteredaerOlustur();



            listem.Clear();


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
                    
                    


                    listem.Add(urun);

                }
            }
        }

        private void btnKayitEkle_Click(object sender, EventArgs e)
        {
            UrunEkle urunEkle= new UrunEkle(personel);
            urunEkle.Show();
        }

        private void btnRapor1_Click(object sender, EventArgs e)
        {
            Rapor1 rapor1 = new Rapor1(personel);
            rapor1.Show();
        }

        private void btnRapor2_Click(object sender, EventArgs e)
        {
            Rapor2 rapor2 = new Rapor2(personel);
            rapor2.Show();
        }
    }
}
