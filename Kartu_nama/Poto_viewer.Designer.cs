namespace Kartu_nama
{
    partial class Poto_viewer
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button3 = new System.Windows.Forms.Button();
            this.txt_c_nama = new System.Windows.Forms.TextBox();
            this.txt_c_kantor = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Kantor = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_c_hp = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txt_c_banyak = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_c_alamat = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(23, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(421, 281);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // button3
            // 
            this.button3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button3.Location = new System.Drawing.Point(65, 176);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(87, 29);
            this.button3.TabIndex = 0;
            this.button3.Text = "Print";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // txt_c_nama
            // 
            this.txt_c_nama.Location = new System.Drawing.Point(65, 36);
            this.txt_c_nama.Name = "txt_c_nama";
            this.txt_c_nama.ReadOnly = true;
            this.txt_c_nama.Size = new System.Drawing.Size(192, 20);
            this.txt_c_nama.TabIndex = 4;
            // 
            // txt_c_kantor
            // 
            this.txt_c_kantor.Location = new System.Drawing.Point(65, 113);
            this.txt_c_kantor.Name = "txt_c_kantor";
            this.txt_c_kantor.ReadOnly = true;
            this.txt_c_kantor.Size = new System.Drawing.Size(294, 20);
            this.txt_c_kantor.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Nama";
            // 
            // Kantor
            // 
            this.Kantor.AutoSize = true;
            this.Kantor.Location = new System.Drawing.Point(13, 116);
            this.Kantor.Name = "Kantor";
            this.Kantor.Size = new System.Drawing.Size(38, 13);
            this.Kantor.TabIndex = 9;
            this.Kantor.Text = "Kantor";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Alamat";
            // 
            // txt_c_hp
            // 
            this.txt_c_hp.Location = new System.Drawing.Point(65, 87);
            this.txt_c_hp.Name = "txt_c_hp";
            this.txt_c_hp.ReadOnly = true;
            this.txt_c_hp.Size = new System.Drawing.Size(239, 20);
            this.txt_c_hp.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "No HP";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.txt_c_banyak);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.txt_c_nama);
            this.groupBox1.Controls.Add(this.txt_c_kantor);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.Kantor);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txt_c_hp);
            this.groupBox1.Controls.Add(this.txt_c_alamat);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBox1.Location = new System.Drawing.Point(473, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(401, 281);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Data Customer";
            // 
            // txt_c_banyak
            // 
            this.txt_c_banyak.Location = new System.Drawing.Point(65, 139);
            this.txt_c_banyak.Name = "txt_c_banyak";
            this.txt_c_banyak.ReadOnly = true;
            this.txt_c_banyak.Size = new System.Drawing.Size(61, 20);
            this.txt_c_banyak.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 142);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Banyak";
            // 
            // txt_c_alamat
            // 
            this.txt_c_alamat.Location = new System.Drawing.Point(65, 62);
            this.txt_c_alamat.Name = "txt_c_alamat";
            this.txt_c_alamat.ReadOnly = true;
            this.txt_c_alamat.Size = new System.Drawing.Size(294, 20);
            this.txt_c_alamat.TabIndex = 6;
            // 
            // Poto_viewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(917, 320);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pictureBox1);
            this.MaximizeBox = false;
            this.Name = "Poto_viewer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Poto_viewer";
            this.Load += new System.EventHandler(this.Poto_viewer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label Kantor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.TextBox txt_c_nama;
        public System.Windows.Forms.TextBox txt_c_kantor;
        public System.Windows.Forms.TextBox txt_c_hp;
        public System.Windows.Forms.TextBox txt_c_alamat;
        public System.Windows.Forms.TextBox txt_c_banyak;
        private System.Windows.Forms.Label label3;
    }
}