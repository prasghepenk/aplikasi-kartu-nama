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
    public partial class AmbilBarang : Form
    {
        public AmbilBarang()
        {
            InitializeComponent();
        }

        private Konektor koneksi = new Konektor();
        public MainForm main;
        private string kode;
        private int result;

        public string Kode
        {
            get { return this.kode; }
            set { this.kode = value; }
        }

        private void AmbilBarang_Load(object sender, EventArgs e)
        {
            try
            {
                this.textBox1.Text = Kode;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox2.Text != "")
                {
                    result = koneksi.InsertPengambilanBarang(Kode, textBox2.Text);
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
                    MessageBox.Show("Lengkapi Datanya dulu !!", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
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
