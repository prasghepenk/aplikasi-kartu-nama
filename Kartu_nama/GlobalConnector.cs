using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;

namespace Kartu_nama
{
    class GlobalConnector
    {
        public GlobalConnector()
        {
            try
            {
                alamat = "server=localhost; username=root; password=; database=kartunama;";
                koneksi = new MySqlConnection(alamat);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
        }

        private MySqlConnection koneksi;
        private MySqlCommand perintah;
        private MySqlDataAdapter adapter;
        private DataSet ds = new DataSet();
        private string alamat;
        private int result;

        protected DataSet GetData(string query)
        {
            try
            {
                ds = new DataSet();
                koneksi.Open();
                perintah = new MySqlCommand(query, koneksi);
                adapter = new MySqlDataAdapter(perintah);
                perintah.ExecuteNonQuery();
                adapter.Fill(ds);
                koneksi.Close();
                return ds;
            }
            catch (Exception)
            {
                return null;
            }
        }

        protected int ManipulasiData(string query)
        {
            try
            {
                koneksi.Open();
                perintah = new MySqlCommand(query, koneksi);
                adapter = new MySqlDataAdapter();
                result = perintah.ExecuteNonQuery();
                koneksi.Close();
                return result;
            }
            catch (Exception)
            {
                return 0;
            }
        }
    }
}
