using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Varlık_Zimmet_Depo_Yönetimi.MyProvider
{
    public class MSSQLProvider
    {
        SqlConnection conn = null;
        SqlCommand cmd = null;

        public MSSQLProvider(string YapilamakIstenenQuery, string Adres = "server=.;Database=Varlık-Zimmet-Depo YönetimiDB;Integrated Security=True")
        {
            conn = new SqlConnection(Adres);
            cmd = new SqlCommand();
            cmd.CommandText = YapilamakIstenenQuery;

            cmd.Connection = conn;
        }



        void Close()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }

        }
        void Open()
        {
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }

        }


        public int ExcutNon()
        {
            int result = 0;

            try
            {

                Open();
                result = cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

                result = 0;
            }
            finally
            {
                Close();
            }

            return result;



        }

        public object ExecutScalar()
        {
            object result = null;

            try
            {
                Open();
                result = cmd.ExecuteScalar();
            }
            catch (Exception)
            {


            }
            finally
            {
                Close();
            }

            return result;
        }
        
        public SqlDataReader ExcuteredaerOlustur()
        {
            SqlDataReader rdr = null;
            try
            {
                Open();
                rdr = cmd.ExecuteReader();
            }
            catch (Exception)
            {


            }
            finally
            {
                
            }

            return rdr;

        }

        public void ParametreEkle2(string parametreAdi, object obje)
        {

            cmd.Parameters.AddWithValue(parametreAdi, obje);

        }

    }
}
