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
    public partial class UrunBilgisi : Form
    {
        private string urunNo;
        private Personel personel;
        private Personel personel2;
        private Urun urun;

        public UrunBilgisi()
        {
            InitializeComponent();
        }
        public UrunBilgisi(string urunNo, Personel personel) : this()
        {
            this.personel = personel;
            this.urunNo = urunNo;
        }

        private void UrunBilgisi_Load(object sender, EventArgs e)
        {
            UrunBilgisiYukle();

            DegerleriDoldur();

        }

        private void DegerleriDoldur()
        {
            txtKAyitAcan.Text = personel.PersonelAdi;
            lblUrunId.Text = urun.UrunId.ToString();
            txtKayitTarihi.Text = urun.UrunGirisTarihi.ToString();
            if (urun.DepodaMi)
            {
                txtDepo.Text = "Depoda";
            }
            else
            {
                txtDepo.Text = "Depoda değil";
            }
            txtSonislemTarihi.Text = urun.UrunGirisTarihi.ToString();
            txtAksyonuYapan.Text = personel2.PersonelAdi;
            txtEkip.Text = personel2.ekip.EkipAdi;

        }

        private void UrunBilgisiYukle()
        {
            MSSQLProvider provider = new MSSQLProvider($"select Urun.UrunId, urun.UrunGirisTarihi, Urun.DepodaMi, Personel.PersonelAdi, Ekip.EkipAdi  from Urun inner join Personel on Urun.PersonelId=Personel.PersonelId inner join Ekip on Personel.EkipId=Ekip.EkipId where Urun.UrunId='{urunNo}'");


            SqlDataReader reader = provider.ExcuteredaerOlustur();




            if (reader.HasRows)
            {

                while (reader.Read())
                {

                    urun = new Urun();
                    personel2 = new Personel();
                    personel2.ekip = new Ekip();


                    urun.UrunId = reader.GetInt32(0);
                    urun.UrunGirisTarihi = reader.GetDateTime(1);
                    urun.DepodaMi = reader.GetBoolean(2);
                    personel2.PersonelAdi= reader.GetString(3);
                    personel2.ekip.EkipAdi= reader.GetString(4);

                }
            }
        }
        int sayi = 1;
        private void btnAksyon_Click(object sender, EventArgs e)
        {
            if(sayi % 2 == 0) 
            {
                panel1.Height = 28;
                sayi++;

            }
            else
            {
                panel1.Height = 172;
                sayi++;

            }
        }
    }
}
