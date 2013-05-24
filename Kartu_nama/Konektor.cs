using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;

namespace Kartu_nama
{
    class Konektor : GlobalConnector
    {
        private string query;

        public DataSet GetUsers(string where)
        {
            query = "select * from userapp " + where;
            return GetData(query);
        }

        public DataSet GetCusotmer(string where)
        {
            query = "select * from customer " + where;
            return GetData(query);
        }

        public DataSet GetCusotmerKasir(string where)
        {
            query = "select customer.*,ifnull(pembayaran.banyak_pesanan,'belum bayar') as banyak_pesanan,ifnull(pengambilan.pengambil,'belum diambil')as pengambil"+
                " from customer left join pembayaran on customer.kode_customer=pembayaran.kode_customer left join pengambilan on customer.kode_customer=pengambilan.kode_customer " + where;
            return GetData(query);
        }

        public DataSet GetCusotmerDesigner(string where)
        {
            query = "select customer.*,ifnull(pembayaran.banyak_pesanan,'Belom Bayar') as banyak_pesanan" +
                " from customer left join pembayaran on customer.kode_customer=pembayaran.kode_customer " + where;
            return GetData(query);
        }

        public DataSet GetLaporanLengkap()
        {
            query = "select customer.*, ifnull(pembayaran.banyak_pesanan,'belom bayar')as banyak_pesanan,ifnull(pembayaran.harga_satuan,'-')as harga_satuan,"+
                " ifnull(pembayaran.tanggal,'-')as tanggal,ifnull(pengambilan.pengambil,'belom diambil')as pengambil,ifnull(pengambilan.tanggal,'-')as tanggal"+
                " from customer left join pembayaran on customer.kode_customer=pembayaran.kode_customer left join pengambilan on "+
                "customer.kode_customer=pengambilan.kode_customer";
            return GetData(query);
        }

        public DataSet GetHarga()
        {
            query = "select * from barang";
            return GetData(query);
        }

        public int InsertPembayaran(string kode_customer,string banyak,string harga)
        {
            query = "insert into pembayaran values ('" + kode_customer + "','" + banyak + "','" + harga + "','" + DateTime.Now.ToString("yyyy-MM-dd") + "')";
            return ManipulasiData(query);
        }

        public int InsertPengambilanBarang(string kode_customer,string pengambil)
        {
            query = "insert into pengambilan values ('" + kode_customer + "','" + pengambil + "','" + DateTime.Now.ToString("yyyy-MM-dd") + "')";
            return ManipulasiData(query);
        }

        public int InsertUser(string userlogin, string username,string pass,string alamat,string hp,string jabatan)
        {
            query = "insert into userapp values ('"+userlogin+"','"+pass+"','"+username+"','"+alamat+"','"+hp+"','"+jabatan+"')";
            return ManipulasiData(query);
        }

        public int UpdateUser(string userlogin, string username, string pass, string alamat, string hp, string jabatan)
        {
            query = "update userapp set username = '"+username+"',password= '"+pass+"',alamat='"+alamat+"',no_hp='"+hp+"',jabatan='"+jabatan+"' where userlogin = '"+userlogin+"'";
            return ManipulasiData(query);
        }

        public int DeleteUser(string userlogin)
        {
            query = "delete from userapp where userlogin = '"+userlogin+"'";
            return ManipulasiData(query);
        }

        public int UpdateHarga(string ukuran, string harga)
        {
            query = "update barang set ukuran = '"+ukuran+"',harga = '"+harga+"' where no = '1'";
            return ManipulasiData(query);
        }

        public int DeleteCustomer(string where)
        {
            query = "delete from customer "+where;
            return ManipulasiData(query);
        }

        public int DeletePembayaran(string where)
        {
            query = "delete from pembayaran " + where;
            return ManipulasiData(query);
        }

        public int DeletePengambilan(string where)
        {
            query = "delete from pengambilan " + where;
            return ManipulasiData(query);
        }

        public int InsertCustomer(string nama_customer,string alamat,string hp,string kantor)
        {
            query = "insert into customer (nama_customer,alamat,no_hp,kantor) values ('"+nama_customer+"','"+alamat+"','"+hp+"','"+kantor+"')";
            return ManipulasiData(query);
        }

        public int UpdateDirectoryCustomer(string kode_customer,string dir)
        {
            query = "update customer set directory_foto = '"+dir+"' where kode_customer = '"+kode_customer+"'";
            return ManipulasiData(query);
        }

        public DataSet GetLastCustomer()
        {
            query = "select kode_customer from customer order by kode_customer desc limit 1";
            return GetData(query);
        }
    }
}
