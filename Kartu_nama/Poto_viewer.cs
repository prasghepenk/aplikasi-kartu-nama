using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using CrystalDecisions.CrystalReports.Engine;

namespace Kartu_nama
{
    public partial class Poto_viewer : Form
    {
        public Poto_viewer()
        {
            InitializeComponent();
        }

        private string pacth;
        public string Patch
        {
            get { return this.pacth; }
            set { this.pacth = value; }
        }

        PrintOrderViewer order_viewer = new PrintOrderViewer();

        private void Poto_viewer_Load(object sender, EventArgs e)
        {
            try
            {
                FileStream f_s = new FileStream(pacth, FileMode.Open);
                pictureBox1.Image = Image.FromStream(f_s);
                f_s.Close();
                button3.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private byte[] ConvertImageBinary(String img)
        {
            FileStream fs;
            BinaryReader br;
            if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + ""+img))
            {
                fs = new FileStream(AppDomain.CurrentDomain.BaseDirectory + ""+img, FileMode.Open);
            }
            else
            {
                fs = new FileStream(AppDomain.CurrentDomain.BaseDirectory + "NoPhoto.jpg", FileMode.Open);
            } 
            br = new BinaryReader(fs);
            byte[] imgbyte = new byte[fs.Length + 1];              
            imgbyte = br.ReadBytes(Convert.ToInt32((fs.Length)));
            br.Close();
            fs.Close();
            return imgbyte;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                DataRow drow;
                dt.Columns.Add("image", System.Type.GetType("System.Byte[]"));
                dt.Columns.Add("nama_customer", System.Type.GetType("System.String"));
                dt.Columns.Add("alamat", System.Type.GetType("System.String"));
                dt.Columns.Add("no_hp", System.Type.GetType("System.String"));
                dt.Columns.Add("kantor", System.Type.GetType("System.String"));

                for (short i = 0; i < int.Parse(txt_c_banyak.Text) / 2; i++)
                {
                    drow = dt.NewRow();
                    drow["image"] = ConvertImageBinary(Patch);
                    drow["nama_customer"] = txt_c_nama.Text;
                    drow["alamat"] = txt_c_alamat.Text;
                    drow["no_hp"] = txt_c_hp.Text;
                    drow["kantor"] = txt_c_kantor.Text;
                    dt.Rows.Add(drow);
                }
                ReportDocument rd = new ReportDocument();
                rd.Load("../../PrintOrder.rpt");
                rd.Database.Tables[0].SetDataSource(dt);
                order_viewer.crystalReportViewer1.ReportSource = rd;
                order_viewer.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
