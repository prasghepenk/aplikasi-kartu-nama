using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports;
using CrystalDecisions.ReportSource;
using CrystalDecisions.CrystalReports.Engine;
using System.IO;
using AForge.Video;
using AForge.Video.DirectShow;
using MySql.Data.MySqlClient;

namespace Kartu_nama
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private Konektor koneksi = new Konektor();
        private DataSet ds;
        private Pembayaran bayar;
        private AmbilBarang ambil;
        private int result,img_control = 0;
        private string b_ukuran, b_harga,jabatan;
        //aforge library
        private FilterInfoCollection VideoCaptureDevices;
        private VideoCaptureDevice FinalVideoSource;
        private Poto_viewer viewer;
        private Reporting1 my_rpt;

        public string Jabatan
        {
            get { return this.jabatan; }
            set { this.jabatan = value; }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (Jabatan == "customer" || Jabatan == "Manager")
                {
                    if (FinalVideoSource.IsRunning)
                    {
                        FinalVideoSource.Stop();
                    }
                }
                Application.Exit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                if (Jabatan == "Manager")
                {
                    CustomerFoto();
                    SetDataGridViewCustomer();
                    setDataGridViewDesigner();
                    setDataGridViewLaporanLengkap();
                    setDataGridViewUsers();
                    setHarga();
                }
                else if (Jabatan == "Kasir")
                {
                    SetDataGridViewCustomer();
                    tabControl1.TabPages.Remove(tabPage1);
                    tabControl1.TabPages.Remove(tabPage3);
                    tabControl1.TabPages.Remove(tabPage4);
                    tabControl1.TabPages.Remove(tabPage5);
                    tabControl1.TabPages.Remove(tabPage6);
                }
                else if (Jabatan == "Designer")
                {
                    setDataGridViewDesigner();
                    tabControl1.TabPages.Remove(tabPage1);
                    tabControl1.TabPages.Remove(tabPage2);
                    tabControl1.TabPages.Remove(tabPage4);
                    tabControl1.TabPages.Remove(tabPage5);
                    tabControl1.TabPages.Remove(tabPage6);
                }
                else
                {
                    CustomerFoto();
                    tabControl1.TabPages.Remove(tabPage2);
                    tabControl1.TabPages.Remove(tabPage3);
                    tabControl1.TabPages.Remove(tabPage4);
                    tabControl1.TabPages.Remove(tabPage5);
                    tabControl1.TabPages.Remove(tabPage6);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region Foto
        private void CustomerFoto()
        {
            try
            {
                VideoCaptureDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);

                foreach (FilterInfo VideoCaptureDevice in VideoCaptureDevices)
                {
                    comboBox1.Items.Add(VideoCaptureDevice.Name);
                }
                comboBox1.SelectedIndex = 0;
                txt_c_nama.Clear();
                txt_c_alamat.Clear();
                txt_c_hp.Clear();
                txt_c_kantor.Clear();
                button2_Click(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }

        void FinalVideoSource_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            try
            {
                Bitmap image = (Bitmap)eventArgs.Frame.Clone();
                pictureBox1.Image = image;
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
                FinalVideoSource.Stop();
                button1.Enabled = false;
                button2.Enabled = true;
                img_control = 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                FinalVideoSource = new VideoCaptureDevice(VideoCaptureDevices[comboBox1.SelectedIndex].MonikerString);
                FinalVideoSource.NewFrame += new NewFrameEventHandler(FinalVideoSource_NewFrame);
                FinalVideoSource.Start();
                button1.Enabled = true;
                button2.Enabled = false;
                img_control = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (img_control != 0 && txt_c_nama.Text != "" && txt_c_alamat.Text != "" && txt_c_hp.Text != "" && txt_c_kantor.Text != "")
                {
                    //insert customer
                    string temp_kode = "";
                    result = koneksi.InsertCustomer(txt_c_nama.Text, txt_c_alamat.Text, txt_c_hp.Text, txt_c_kantor.Text);
                    if (result == 1)
                    {
                        ds = new DataSet();
                        ds.Clear();
                        ds = koneksi.GetLastCustomer();
                        foreach (DataRow kolom in ds.Tables[0].Rows)
                        {
                            temp_kode = kolom["kode_customer"].ToString();
                        }
                        pictureBox1.Image.Save("image_customer/" + temp_kode + ".JPG");
                        result = koneksi.UpdateDirectoryCustomer(temp_kode, "image_customer/" + temp_kode);
                        if (result == 1)
                        {
                            MessageBox.Show("Berhasil Menyimpan Data !!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            CustomerFoto();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Lengkapi Data terlebih dahulu . . .", "Warning !!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region DataGridCustomerKasir
        public void SetDataGridViewCustomer()
        {
            try
            {
                ds = new DataSet();
                ds = koneksi.GetCusotmerKasir("");
                dataGridView1.DataSource = ds.Tables[0];

                dataGridView1.Columns[0].Width = 70;
                dataGridView1.Columns[0].HeaderText = "Kode Customer";
                dataGridView1.Columns[1].Width = 230;
                dataGridView1.Columns[1].HeaderText = "Nama Customer";
                dataGridView1.Columns[2].Width = 220;
                dataGridView1.Columns[2].HeaderText = "Alamat";
                dataGridView1.Columns[3].Width = 100;
                dataGridView1.Columns[3].HeaderText = "Nomer HP";
                dataGridView1.Columns[4].Width = 220;
                dataGridView1.Columns[4].HeaderText = "Kantor";
                dataGridView1.Columns[5].Width = 180;
                dataGridView1.Columns[5].HeaderText = "Directory";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1[6, dataGridView1.CurrentRow.Index].Value.ToString() == "belum bayar")
                {
                    bayar = new Pembayaran();
                    bayar.Kode = dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString();
                    bayar.main = this;
                    bayar.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1[7, dataGridView1.CurrentRow.Index].Value.ToString() == "belum diambil")
                {
                    ambil = new AmbilBarang();
                    ambil.Kode = dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString();
                    ambil.main = this;
                    ambil.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            try
            {
                SetDataGridViewCustomer();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {
            try
            {
                ds = new DataSet();
                ds = koneksi.GetCusotmerKasir("where nama_customer like '%" + textBox12.Text + "%'");
                dataGridView1.DataSource = ds.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region DataGridCustomerSDesigner
        private void setDataGridViewDesigner()
        {
            try
            {
                ds = new DataSet();
                ds.Clear();
                ds = koneksi.GetCusotmerDesigner("");
                dataGridView2.DataSource = ds.Tables[0];

                dataGridView2.Columns[0].Width = 70;
                dataGridView2.Columns[0].HeaderText = "Kode Customer";
                dataGridView2.Columns[1].Width = 230;
                dataGridView2.Columns[1].HeaderText = "Nama Customer";
                dataGridView2.Columns[2].Width = 220;
                dataGridView2.Columns[2].HeaderText = "Alamat";
                dataGridView2.Columns[3].Width = 100;
                dataGridView2.Columns[3].HeaderText = "Nomer HP";
                dataGridView2.Columns[4].Width = 220;
                dataGridView2.Columns[4].HeaderText = "Kantor";
                dataGridView2.Columns[5].Width = 180;
                dataGridView2.Columns[5].HeaderText = "Directory";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            try
            {
                if (int.Parse(dataGridView2[6, dataGridView2.CurrentRow.Index].Value.ToString()) > 0)
                {
                    viewer = new Poto_viewer();
                    viewer.Patch = "image_customer/" + dataGridView2[0, dataGridView2.CurrentRow.Index].Value.ToString() + ".JPG";
                    viewer.txt_c_nama.Text = dataGridView2[1, dataGridView2.CurrentRow.Index].Value.ToString();
                    viewer.txt_c_alamat.Text = dataGridView2[2, dataGridView2.CurrentRow.Index].Value.ToString();
                    viewer.txt_c_hp.Text = dataGridView2[3, dataGridView2.CurrentRow.Index].Value.ToString();
                    viewer.txt_c_kantor.Text = dataGridView2[4, dataGridView2.CurrentRow.Index].Value.ToString();
                    viewer.txt_c_banyak.Text = dataGridView2[6, dataGridView2.CurrentRow.Index].Value.ToString();
                    viewer.ShowDialog();      
                }            
            }
            catch (Exception ex)
            {
                MessageBox.Show("Custome ini belum bayar", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //MessageBox.Show(ex.ToString());
            }            
        }

        private void button17_Click(object sender, EventArgs e)
        {
            try
            {
                setDataGridViewDesigner();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region DataGridCustomerlaporan
        private void setDataGridViewLaporanLengkap()
        {
            try
            {
                ds = new DataSet();
                ds.Clear();
                ds = koneksi.GetLaporanLengkap();
                dataGridView3.DataSource = ds.Tables[0];

                dataGridView3.Columns[0].Width = 50;
                dataGridView3.Columns[0].HeaderText = "Kode Customer";
                dataGridView3.Columns[1].Width = 140;
                dataGridView3.Columns[1].HeaderText = "Nama Customer";
                dataGridView3.Columns[2].Width = 150;
                dataGridView3.Columns[2].HeaderText = "Alamat";
                dataGridView3.Columns[3].Width = 100;
                dataGridView3.Columns[3].HeaderText = "HP";
                dataGridView3.Columns[4].Width = 150;
                dataGridView3.Columns[4].HeaderText = "Kantor";
                dataGridView3.Columns[5].Width = 120;
                dataGridView3.Columns[5].HeaderText = "Directory";
                dataGridView3.Columns[6].Width = 120;
                dataGridView3.Columns[6].HeaderText = "Banyak Pesanan";
                dataGridView3.Columns[7].Width = 120;
                dataGridView3.Columns[7].HeaderText = "Harga Satuan";
                dataGridView3.Columns[8].Width = 100;
                dataGridView3.Columns[8].HeaderText = "Tanggal pesan";
                dataGridView3.Columns[9].Width = 100;
                dataGridView3.Columns[9].HeaderText = "Pengambil";
                dataGridView3.Columns[10].Width = 100;
                dataGridView3.Columns[10].HeaderText = "Tanggal Ambil";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (dataGridView3.Rows.Count > 0)
            {
                if (MessageBox.Show("Anda yakin akan menghapus data ini ??", "Warning !!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    koneksi.DeleteCustomer("where kode_customer = '" + dataGridView3[0, dataGridView3.CurrentRow.Index].Value.ToString() + "'");
                    koneksi.DeletePembayaran("where kode_customer = '" + dataGridView3[0, dataGridView3.CurrentRow.Index].Value.ToString() + "'");
                    koneksi.DeletePengambilan("where kode_customer = '" + dataGridView3[0, dataGridView3.CurrentRow.Index].Value.ToString() + "'");
                    File.Delete("image_customer/" + dataGridView3[0, dataGridView3.CurrentRow.Index].Value.ToString() + ".JPG");
                    MessageBox.Show("Hapus Data Sukses !!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    setDataGridViewLaporanLengkap();
                }
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            try
            {
                setDataGridViewLaporanLengkap();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            try
            {
                customerReport1 = new CustomerReport();
                customerReport1.Load("../../CustomerReport.rpt");
                my_rpt = new Reporting1();
                my_rpt.crystalReportViewer1.ReportSource = customerReport1;
                my_rpt.crystalReportViewer1.RefreshReport();
                my_rpt.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        #endregion

        #region DataGridUsers
        private void setDataGridViewUsers()
        {
            try
            {
                ds = new DataSet();
                ds.Clear();
                ds = koneksi.GetUsers("");
                dataGridView4.DataSource = ds.Tables[0];

                dataGridView4.Columns[0].Width = 150;
                dataGridView4.Columns[0].HeaderText = "Userlogin";
                dataGridView4.Columns[1].Width = 230;
                dataGridView4.Columns[1].HeaderText = "Username";
                dataGridView4.Columns[2].Width = 220;
                dataGridView4.Columns[2].HeaderText = "Password";
                dataGridView4.Columns[3].Width = 200;
                dataGridView4.Columns[3].HeaderText = "Alamat";
                dataGridView4.Columns[4].Width = 220;
                dataGridView4.Columns[4].HeaderText = "No HP";
                dataGridView4.Columns[5].Width = 180;
                dataGridView4.Columns[5].HeaderText = "Jabatan";

                comboBox1.SelectedIndex = 0;
                comboBox1.Enabled = true;
                button4.Enabled = true;
                button5.Enabled = false;
                button6.Enabled = false;
                button7.Enabled = true;
                button8.Enabled = false;
                textBox5.Clear();
                textBox6.Clear();
                textBox7.Clear();
                textBox8.Clear();
                textBox9.Clear();
                textBox5.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox5.Text != "")
                {
                    ds = new DataSet();
                    ds = koneksi.GetUsers("where userlogin = '" + textBox5.Text + "'");
                    if (ds.Tables[0].Rows.Count == 0)
                    {
                        MessageBox.Show("Data yang anda cari tidak ada di Database!!", "Warning !!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {

                        dataGridView4.DataSource = ds.Tables[0];

                        foreach (DataRow kolom in ds.Tables[0].Rows)
                        {
                            textBox6.Text = kolom["username"].ToString();
                            textBox7.Text = kolom["password"].ToString();
                            textBox8.Text = kolom["alamat"].ToString();
                            textBox9.Text = kolom["no_hp"].ToString();
                            comboBox1.Text = kolom["jabatan"].ToString();
                        }

                        button4.Enabled = false;
                        button5.Enabled = true;
                        button6.Enabled = true;
                        button7.Enabled = false;
                        button8.Enabled = true;
                        textBox5.Enabled = false;
                    }
                }
                else
                {
                    MessageBox.Show("Tidak ada data yang anda pilih!!", "Warning !!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                setDataGridViewUsers();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox5.Text != "" && textBox6.Text != "" && textBox7.Text != "" && textBox8.Text != "" && textBox9.Text != "")
                {
                    result = koneksi.InsertUser(textBox5.Text, textBox6.Text, textBox7.Text, textBox8.Text, textBox9.Text, comboBox1.Text);
                    if (result == 1)
                    {
                        MessageBox.Show("Insert data sukses !!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        setDataGridViewUsers();
                    }
                    else
                    {
                        MessageBox.Show("Insert data gagal", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Lengkapi data dulu !!", "Warning !!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox6.Text != "" && textBox7.Text != "" && textBox8.Text != "" && textBox9.Text != "")
                {
                    result = koneksi.UpdateUser(textBox5.Text, textBox6.Text, textBox7.Text, textBox8.Text, textBox9.Text, comboBox1.Text);
                    if (result == 1)
                    {
                        MessageBox.Show("Update data sukses !!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        setDataGridViewUsers();
                    }
                    else
                    {
                        MessageBox.Show("Update data gagal", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Lengkapi data dulu !!", "Warning !!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Anda Yakin menghapus Data ini ??", "Warning !!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    result = koneksi.DeleteUser(textBox5.Text);
                    if (result == 1)
                    {
                        setDataGridViewUsers();
                    }
                    else
                    {
                        MessageBox.Show("Hapus data gagal", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13)
                {
                    button7_Click(null, null);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
#endregion

        #region manager
        private void setHarga()
        {
            try
            {
                ds = new DataSet();
                ds = koneksi.GetHarga();
                foreach (DataRow kolom in ds.Tables[0].Rows)
                {
                    textBox10.Text = kolom["ukuran"].ToString();
                    b_ukuran = kolom["ukuran"].ToString();
                    textBox11.Text = kolom["harga"].ToString();
                    b_harga = kolom["harga"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox10.Text != "" && textBox11.Text != "")
                {
                    if (textBox10.Text == b_ukuran && textBox11.Text == b_harga)
                    {
                        
                    }
                    else
                    {
                        result = koneksi.UpdateHarga(textBox10.Text, textBox11.Text);
                        if (result == 1)
                        {
                            MessageBox.Show("Sukses Update", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            setHarga();
                        }
                        else
                        {
                            MessageBox.Show("Gagal Update", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Data tidak lengkap !!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

    }
}
