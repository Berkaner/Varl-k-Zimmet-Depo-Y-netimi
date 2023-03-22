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
    public partial class PersonelGirisi : Form
    {
        Personel personel = new Personel();

        

        public PersonelGirisi()
        {
            InitializeComponent();
        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            string ad = txtAdi.Text;
            string sifre = txtSifre.Text;


            MSSQLProvider provider = new MSSQLProvider($"select per.PersonelId, per.PersonelAdi, yet.YetkiId as YetkiId1, yet.YetkiAdi, ek.EkipId, ek.EkipAdi, sir.SirketId, sir.SirketAdi, dep.DepoId, dep.DepoAdi, dep.DepoAdresi from Personel as per inner join Yetki as yet on per.YetkiId=yet.YetkiId inner join Ekip as ek on per.EkipId=ek.EkipId inner join Sirket as sir on ek.SirketId=sir.SirketId inner join Depo as dep on sir.DepoId=dep.DepoId  where per.PersonelAdi='{ad}' and per.KullanıcıSifresi='{sifre}'");

            SqlDataReader reader = provider.ExcuteredaerOlustur();

            personel.yetki = new Yetki();
            personel.ekip = new Ekip();
            personel.ekip.sirket = new Sirket();
            personel.ekip.sirket.depo = new Depo();

            if (reader.HasRows)
            {
                while (reader.Read())
                {

                    personel.PersonelId= reader.GetInt32(0);
                    personel.PersonelAdi = reader.GetString(1);
                    personel.yetki.YetkiId = reader.GetInt32(2);
                    personel.yetki.YetkiAdi = reader.GetString(3);
                    personel.ekip.EkipId = reader.GetInt32(4);
                    personel.ekip.EkipAdi= reader.GetString(5);
                    personel.ekip.sirket.SirketId= reader.GetInt32(6);
                    personel.ekip.sirket.SirketAdi= reader.GetString(7);
                    personel.ekip.sirket.depo.DepoId= reader.GetInt32(8);
                    personel.ekip.sirket.depo.DepoAdi= reader.GetString(9);
                    personel.ekip.sirket.depo.DepoAdresi= reader.GetString(10);
                }

                MessageBox.Show("Giriş başarılı!");


                AnaSayfa anaSayfa = new AnaSayfa(personel);
                anaSayfa.Show();
                this.Hide();


            }
            else
            {
                MessageBox.Show("Ad veya şifre yanlış!");
            }




            
        }

        private void PersonelGirisi_Load(object sender, EventArgs e)
        {

        }
    }
}
