namespace Kartu_nama
{
    partial class Pembayaran
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txt_nama = new System.Windows.Forms.TextBox();
            this.txt_kantor = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_hp = new System.Windows.Forms.TextBox();
            this.txt_alamat = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_harga_satuan = new System.Windows.Forms.TextBox();
            this.txt_bayar = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_total = new System.Windows.Forms.TextBox();
            this.txt_banyak = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.txt_terbilang = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txt_nama
            // 
            this.txt_nama.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txt_nama.Enabled = false;
            this.txt_nama.Location = new System.Drawing.Point(126, 40);
            this.txt_nama.Name = "txt_nama";
            this.txt_nama.Size = new System.Drawing.Size(239, 20);
            this.txt_nama.TabIndex = 12;
            // 
            // txt_kantor
            // 
            this.txt_kantor.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txt_kantor.Enabled = false;
            this.txt_kantor.Location = new System.Drawing.Point(126, 117);
            this.txt_kantor.Name = "txt_kantor";
            this.txt_kantor.Size = new System.Drawing.Size(294, 20);
            this.txt_kantor.TabIndex = 18;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(80, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Nama";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label3.Location = new System.Drawing.Point(76, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Kantor";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(76, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Alamat";
            // 
            // txt_hp
            // 
            this.txt_hp.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txt_hp.Enabled = false;
            this.txt_hp.Location = new System.Drawing.Point(126, 91);
            this.txt_hp.Name = "txt_hp";
            this.txt_hp.Size = new System.Drawing.Size(239, 20);
            this.txt_hp.TabIndex = 16;
            // 
            // txt_alamat
            // 
            this.txt_alamat.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txt_alamat.Enabled = false;
            this.txt_alamat.Location = new System.Drawing.Point(126, 66);
            this.txt_alamat.Name = "txt_alamat";
            this.txt_alamat.Size = new System.Drawing.Size(294, 20);
            this.txt_alamat.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label4.Location = new System.Drawing.Point(76, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "No HP";
            // 
            // txt_harga_satuan
            // 
            this.txt_harga_satuan.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txt_harga_satuan.Enabled = false;
            this.txt_harga_satuan.Location = new System.Drawing.Point(126, 142);
            this.txt_harga_satuan.Name = "txt_harga_satuan";
            this.txt_harga_satuan.Size = new System.Drawing.Size(138, 20);
            this.txt_harga_satuan.TabIndex = 20;
            // 
            // txt_bayar
            // 
            this.txt_bayar.Location = new System.Drawing.Point(126, 219);
            this.txt_bayar.Name = "txt_bayar";
            this.txt_bayar.Size = new System.Drawing.Size(138, 20);
            this.txt_bayar.TabIndex = 26;
            this.txt_bayar.TextChanged += new System.EventHandler(this.txt_bayar_TextChanged);
            this.txt_bayar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_bayar_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label5.Location = new System.Drawing.Point(19, 149);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "Harga Satuan (Rp)";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label6.Location = new System.Drawing.Point(58, 222);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 13);
            this.label6.TabIndex = 25;
            this.label6.Text = "Bayar (Rp)";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label7.Location = new System.Drawing.Point(72, 171);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 13);
            this.label7.TabIndex = 21;
            this.label7.Text = "Banyak";
            // 
            // txt_total
            // 
            this.txt_total.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txt_total.Enabled = false;
            this.txt_total.Location = new System.Drawing.Point(126, 193);
            this.txt_total.Name = "txt_total";
            this.txt_total.Size = new System.Drawing.Size(138, 20);
            this.txt_total.TabIndex = 24;
            // 
            // txt_banyak
            // 
            this.txt_banyak.Location = new System.Drawing.Point(126, 168);
            this.txt_banyak.Name = "txt_banyak";
            this.txt_banyak.Size = new System.Drawing.Size(74, 20);
            this.txt_banyak.TabIndex = 22;
            this.txt_banyak.TextChanged += new System.EventHandler(this.txt_banyak_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label8.Location = new System.Drawing.Point(29, 196);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(86, 13);
            this.label8.TabIndex = 23;
            this.label8.Text = "Total Harga (Rp)";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(126, 271);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(80, 32);
            this.button1.TabIndex = 27;
            this.button1.Text = "Simpan";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txt_terbilang
            // 
            this.txt_terbilang.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txt_terbilang.Enabled = false;
            this.txt_terbilang.Location = new System.Drawing.Point(126, 245);
            this.txt_terbilang.Name = "txt_terbilang";
            this.txt_terbilang.Size = new System.Drawing.Size(279, 20);
            this.txt_terbilang.TabIndex = 29;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label9.Location = new System.Drawing.Point(58, 248);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(51, 13);
            this.label9.TabIndex = 28;
            this.label9.Text = "Terbilang";
            // 
            // Pembayaran
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(453, 336);
            this.Controls.Add(this.txt_terbilang);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txt_harga_satuan);
            this.Controls.Add(this.txt_bayar);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txt_total);
            this.Controls.Add(this.txt_banyak);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txt_nama);
            this.Controls.Add(this.txt_kantor);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_hp);
            this.Controls.Add(this.txt_alamat);
            this.Controls.Add(this.label4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Pembayaran";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pembayaran";
            this.Load += new System.EventHandler(this.Pembayaran_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_nama;
        private System.Windows.Forms.TextBox txt_kantor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_hp;
        private System.Windows.Forms.TextBox txt_alamat;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_harga_satuan;
        private System.Windows.Forms.TextBox txt_bayar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_total;
        private System.Windows.Forms.TextBox txt_banyak;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txt_terbilang;
        private System.Windows.Forms.Label label9;
    }
}