using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Varlık_Zimmet_Depo_Yönetimi.DTO;
using Varlık_Zimmet_Depo_Yönetimi.MyProvider;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Varlık_Zimmet_Depo_Yönetimi.Varlık_Zimmet_Depo_YönetimiUI
{
    public partial class UrunEkle : Form
    {
        private Personel personel;

        public UrunEkle()
        {
            InitializeComponent();
        }

        public UrunEkle(Personel personel) : this()
        {
            this.personel = personel;
        }

        private void UrunEkle_Load(object sender, EventArgs e)
        {
            UrunGrubuYukle();
            UruntipiYukle();
            EvetHayirYukle();
            ParaBirimiYukle();
            MiktarBirimiYukle();

        }

        private void MiktarBirimiYukle()
        {
            MSSQLProvider provider = new MSSQLProvider("select * from Birim");

            SqlDataReader reader = provider.ExcuteredaerOlustur();

            if (reader.HasRows)
            {

                while (reader.Read())
                {
                    Birim birim = new Birim();
                    birim.BirimId = reader.GetInt32(0);
                    birim.BirimAdi = reader.GetString(1);

                    cmbBirim.Items.Add(birim);


                }
            }
        }

        private void ParaBirimiYukle()
        {
            MSSQLProvider provider = new MSSQLProvider("select * from ParaBirimi");

            SqlDataReader reader = provider.ExcuteredaerOlustur();

            if (reader.HasRows)
            {

                while (reader.Read())
                {
                    ParaBirimi paraBirimi = new ParaBirimi();
                    paraBirimi.ParaBirimiId = reader.GetInt32(0);
                    paraBirimi.ParaBirimiAdi = reader.GetString(1);

                    

                    cmbMaliyetinParaBirimi.Items.Add(paraBirimi);
                    cmbFiyatParaBirimi.Items.Add(paraBirimi);

                }
            }
        }

        private void EvetHayirYukle()
        {
            
            cmdGaranti.Items.Add(new { Text = "Evet", Tag = 1 });
            cmdGaranti.Items.Add(new { Text = "Hayır", Tag = 0 });
            cmdGaranti.DisplayMember = "Text";
            

        }

        private void UruntipiYukle()
        {
            MSSQLProvider provider = new MSSQLProvider("select * from UrunTipi");

            SqlDataReader reader = provider.ExcuteredaerOlustur();

            if (reader.HasRows)
            {

                while (reader.Read())
                {
                    UrunTipi urunTipi = new UrunTipi();
                    urunTipi.UrunTipiId= reader.GetInt32(0);
                    urunTipi.UrunTipiAdi= reader.GetString(1);

                    

                    cmbUrunTipi.Items.Add(urunTipi);

                }
            }



        }

        private void UrunGrubuYukle()
        {
            MSSQLProvider provider = new MSSQLProvider("select * from UrunGrubu");

            SqlDataReader reader = provider.ExcuteredaerOlustur();

            if (reader.HasRows)
            {

                while (reader.Read())
                {

                    UrunGrubu urunGrubu = new UrunGrubu();

                    urunGrubu.UrunGrubuId= reader.GetInt32(0);
                    urunGrubu.UrunGrubuAdi= reader.GetString(1);

                    

                    cmbUrunGrubu.Items.Add(urunGrubu);
                    

                }
            }

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

            if (checkBox1.Checked)
            {
                txtBarkod.Visible=true;
                flowLayoutPanel2.Visible=false;



            }
            else
            {
                txtBarkod.Visible = false;
                flowLayoutPanel2.Visible = true;
            }

        }

        private void cmbUrunTipi_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbMarka.Items.Clear();
            MarkaYukle(cmbUrunTipi.SelectedItem as UrunTipi);


        }

        private void MarkaYukle(UrunTipi urunTipi)
        {

            MSSQLProvider provider = new MSSQLProvider($"select Marka.MarkaId, Marka.MarkaAdi  from UrunTipi  inner join Model on UrunTipi.UrunTipiId=Model.UrunTipiId inner join Marka on Model.MarkaID=Marka.MarkaId where UrunTipi.UrunTipiId='{urunTipi.UrunTipiId}' group by Marka.MarkaId, Marka.MarkaAdi");

            SqlDataReader reader = provider.ExcuteredaerOlustur();

            if (reader.HasRows)
            {

                while (reader.Read())
                {
                    Marka marka = new Marka();
                    marka.MarkaID = reader.GetInt32(0);
                    marka.MarkaAdi= reader.GetString(1);
                    
                    cmbMarka.Items.Add(marka);

                }
            }



        }

        private void cmbMarka_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbModel.Items.Clear();
            ModelYukle(cmbMarka.SelectedItem as Marka, cmbUrunTipi.SelectedItem as UrunTipi);
        }

        private void ModelYukle(Marka marka, UrunTipi urunTipi)
        {
            MSSQLProvider provider = new MSSQLProvider($"select Model.ModelId, Model.ModelAdi  from UrunTipi  inner join Model on UrunTipi.UrunTipiId=Model.UrunTipiId inner join Marka on Model.MarkaID=Marka.MarkaId where Marka.MarkaId='{marka.MarkaID}' and UrunTipi.UrunTipiId='{urunTipi.UrunTipiId}' group by Model.ModelId, Model.ModelAdi");

            SqlDataReader reader = provider.ExcuteredaerOlustur();

            if (reader.HasRows)
            {

                while (reader.Read())
                {
                    Model model = new Model();
                    model.ModelId = reader.GetInt32(0);
                    model.ModelAdi = reader.GetString(1);

                    cmbModel.Items.Add(model);

                }
            }
        }
        
        private void btnKayitEkle_Click(object sender, EventArgs e)
        {
            
            int etkilenenSatirSayisi = 0;
            
            

            MSSQLProvider provider = new MSSQLProvider($"insert into Urun (ModelId, DepodaMi, DepoId, UrunGrubuId, UrunGarantiliMi, UrunAciklamasi, UrunGirisTarihi, UrunEmeklimi, UrunEmeklilikTarihi, BarkodVarMi, GuncelFiyatBilgisiBirimiId, MaliyetBilgisiBirimiId, GuncelFiyat, Maliyet, Zimmetlimi, BarkodNumarasi, Miktar, MiktarBirimId, PersonelId) values (@ModelID, 1, 1, @UrunGrubuID, @UrunGarantilimi, @Aciklama, @UrununGirisTarihi, 0, 01-01-2030, @BarkodVarmi, @GuncelFiyatBirimi, @MaliyetBirimi, @GuncelFiyat, @Maliyet, 0, @BarkodNo, @Miktar, @MiktarBirimiID, @PersonelId)");




            provider.ParametreEkle2("@ModelID", (cmbModel.SelectedItem as Model).ModelId);
            provider.ParametreEkle2("@UrunGrubuID", (cmbUrunGrubu.SelectedItem as UrunGrubu).UrunGrubuId);
            provider.ParametreEkle2("@UrunGarantilimi", (cmdGaranti.SelectedItem as dynamic).Tag);
            provider.ParametreEkle2("@Aciklama", txtAciklama.Text);
            provider.ParametreEkle2("@UrununGirisTarihi", dtpUrunGirisTarihi.Value);
            provider.ParametreEkle2("@BarkodVarmi", checkBox1.Checked);
            provider.ParametreEkle2("@GuncelFiyatBirimi", (cmbFiyatParaBirimi.SelectedItem as ParaBirimi).ParaBirimiId);
            provider.ParametreEkle2("@MaliyetBirimi", (cmbMaliyetinParaBirimi.SelectedItem as ParaBirimi).ParaBirimiId);
            provider.ParametreEkle2("@GuncelFiyat", nudUrununGuncelFiyati.Value);
            provider.ParametreEkle2("@Maliyet", nudUrunMaliyeti.Value);
            provider.ParametreEkle2("@PersonelId", personel.PersonelId);


            if (checkBox1.Checked)
            {
                provider.ParametreEkle2("@BarkodNo", txtBarkod.Text);
            }
            else
            {
                provider.ParametreEkle2("@BarkodNo", "00000000-0000-0000-0000-000000000000");

                
            }
            provider.ParametreEkle2("@Miktar", txtMiktar.Text);

            if (checkBox1.Checked)
            {
                provider.ParametreEkle2("@MiktarBirimiID", 4);
            }
            else
            {
                provider.ParametreEkle2("@MiktarBirimiID", (cmbBirim.SelectedItem as Birim).BirimId);
            }

            

            etkilenenSatirSayisi = provider.ExcutNon();


            MessageBox.Show("Ürünün kaydı alınmıştır.");

            Temizle();
        }

        private void Temizle()
        {
            txtBarkod.Text = string.Empty;
        }
    }
}
