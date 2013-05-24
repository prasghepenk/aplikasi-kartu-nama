using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Kartu_nama
{
    public partial class Pembayaran : Form
    {
        public Pembayaran()
        {
            InitializeComponent();
            txt_total.Text = "0";
        }

        private Konektor koneksi = new Konektor();
        private DataSet ds = new DataSet();
        private Terbilang terbilang = new Terbilang();
        private string kode;
        private int result;
        public MainForm main;

        public string Kode
        {
            get { return this.kode; }
            set { this.kode = value; }
        }

        private void Pembayaran_Load(object sender, EventArgs e)
        {
            try
            {
                ds.Clear();
                ds = koneksi.GetCusotmerKasir("where customer.kode_customer = '" + Kode + "'");
                foreach (DataRow kolom in ds.Tables[0].Rows)
                {
                    txt_nama.Text = kolom["nama_customer"].ToString();
                    txt_alamat.Text = kolom["alamat"].ToString();
                    txt_hp.Text = kolom["no_hp"].ToString();
                    txt_kantor.Text = kolom["kantor"].ToString();
                }

                ds.Clear();
                ds = koneksi.GetHarga();
                foreach (DataRow kolom in ds.Tables[0].Rows)
                {
                    txt_harga_satuan.Text = kolom["harga"].ToString();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txt_banyak_TextChanged(object sender, EventArgs e)
        {
            Exception X = new Exception();

            TextBox T = (TextBox)sender;

            try
            {
                if (T.Text != "-")
                {
                    int x = int.Parse(T.Text);
                    txt_total.Text = (x * int.Parse(txt_harga_satuan.Text)).ToString();
                }
            }
            catch (Exception)
            {
                try
                {
                    int CursorIndex = T.SelectionStart - 1;
                    T.Text = T.Text.Remove(CursorIndex, 1);

                    //Align Cursor to same index
                    T.SelectionStart = CursorIndex;
                    T.SelectionLength = 0;
                }
                catch (Exception) { }
            }
        }

        private void txt_bayar_TextChanged(object sender, EventArgs e)
        {
            Exception X = new Exception();

            TextBox T = (TextBox)sender;

            try
            {
                if (T.Text != "-")
                {
                    int x = int.Parse(T.Text);
                    txt_terbilang.Text = terbilang.WordAmountId(float.Parse(txt_bayar.Text));
                }
            }
            catch (Exception)
            {
                try
                {
                    int CursorIndex = T.SelectionStart - 1;
                    T.Text = T.Text.Remove(CursorIndex, 1);

                    //Align Cursor to same index
                    T.SelectionStart = CursorIndex;
                    T.SelectionLength = 0;
                }
                catch (Exception) { }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_banyak.Text != "" && txt_bayar.Text != "")
                {
                    if (txt_banyak.Text != "0")
                    {
                        if (int.Parse(txt_bayar.Text) >= int.Parse(txt_total.Text))
                        {
                            result = koneksi.InsertPembayaran(kode, txt_banyak.Text, txt_harga_satuan.Text);
                            if (result == 1)
                            {
                                MessageBox.Show("Insert data suksess !!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                main.SetDataGridViewCustomer();
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("Insert data Gagal !!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Mosok Pembayarane lebih kecil dari\n Total Harga ?? !!", "Warning !!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txt_bayar.Focus();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Jumlah pesanan tidak boleh 0 !!", "Warning !!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txt_banyak.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Lengkapi Datanya dulu !!", "Warning !!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txt_banyak.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txt_bayar_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13)
                {
                    button1_Click(null, null);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
    }
}
