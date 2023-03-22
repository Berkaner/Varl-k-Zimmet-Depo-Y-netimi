namespace Varlık_Zimmet_Depo_Yönetimi.Varlık_Zimmet_Depo_YönetimiUI
{
    partial class AnaSayfa
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
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.btnRapor2 = new System.Windows.Forms.Button();
            this.btnRapor1 = new System.Windows.Forms.Button();
            this.btnKayitEkle = new System.Windows.Forms.Button();
            this.btnMenü = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblPersonelAdi = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.pnlUrun = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnVarliklarim = new System.Windows.Forms.Button();
            this.btnEkibiminVarlıkları = new System.Windows.Forms.Button();
            this.btnTumVarliklar = new System.Windows.Forms.Button();
            this.pnlMenu.SuspendLayout();
            this.pnlUrun.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlMenu
            // 
            this.pnlMenu.Controls.Add(this.btnRapor2);
            this.pnlMenu.Controls.Add(this.btnRapor1);
            this.pnlMenu.Controls.Add(this.btnKayitEkle);
            this.pnlMenu.Controls.Add(this.btnMenü);
            this.pnlMenu.Location = new System.Drawing.Point(0, 64);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(203, 388);
            this.pnlMenu.TabIndex = 0;
            // 
            // btnRapor2
            // 
            this.btnRapor2.Location = new System.Drawing.Point(3, 310);
            this.btnRapor2.Name = "btnRapor2";
            this.btnRapor2.Size = new System.Drawing.Size(194, 42);
            this.btnRapor2.TabIndex = 3;
            this.btnRapor2.Text = "Rapor 2";
            this.btnRapor2.UseVisualStyleBackColor = true;
            this.btnRapor2.Click += new System.EventHandler(this.btnRapor2_Click);
            // 
            // btnRapor1
            // 
            this.btnRapor1.Location = new System.Drawing.Point(3, 262);
            this.btnRapor1.Name = "btnRapor1";
            this.btnRapor1.Size = new System.Drawing.Size(194, 42);
            this.btnRapor1.TabIndex = 2;
            this.btnRapor1.Text = "Rapor 1";
            this.btnRapor1.UseVisualStyleBackColor = true;
            this.btnRapor1.Click += new System.EventHandler(this.btnRapor1_Click);
            // 
            // btnKayitEkle
            // 
            this.btnKayitEkle.Location = new System.Drawing.Point(12, 12);
            this.btnKayitEkle.Name = "btnKayitEkle";
            this.btnKayitEkle.Size = new System.Drawing.Size(125, 44);
            this.btnKayitEkle.TabIndex = 2;
            this.btnKayitEkle.Text = "Yeni Kayıt Ekle";
            this.btnKayitEkle.UseVisualStyleBackColor = true;
            this.btnKayitEkle.Click += new System.EventHandler(this.btnKayitEkle_Click);
            // 
            // btnMenü
            // 
            this.btnMenü.Location = new System.Drawing.Point(143, 12);
            this.btnMenü.Name = "btnMenü";
            this.btnMenü.Size = new System.Drawing.Size(54, 44);
            this.btnMenü.TabIndex = 1;
            this.btnMenü.Text = "<";
            this.btnMenü.UseVisualStyleBackColor = true;
            this.btnMenü.Click += new System.EventHandler(this.btnMenü_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(59, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "ULTİA";
            // 
            // lblPersonelAdi
            // 
            this.lblPersonelAdi.AutoSize = true;
            this.lblPersonelAdi.Location = new System.Drawing.Point(891, 25);
            this.lblPersonelAdi.Name = "lblPersonelAdi";
            this.lblPersonelAdi.Size = new System.Drawing.Size(79, 16);
            this.lblPersonelAdi.TabIndex = 2;
            this.lblPersonelAdi.Text = "personeladi";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(988, 22);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Çıkış";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pnlUrun
            // 
            this.pnlUrun.Controls.Add(this.dataGridView1);
            this.pnlUrun.Location = new System.Drawing.Point(230, 147);
            this.pnlUrun.Name = "pnlUrun";
            this.pnlUrun.Size = new System.Drawing.Size(836, 305);
            this.pnlUrun.TabIndex = 8;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(0, 50);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(833, 252);
            this.dataGridView1.TabIndex = 3;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick_1);
            // 
            // btnVarliklarim
            // 
            this.btnVarliklarim.Location = new System.Drawing.Point(251, 76);
            this.btnVarliklarim.Name = "btnVarliklarim";
            this.btnVarliklarim.Size = new System.Drawing.Size(118, 44);
            this.btnVarliklarim.TabIndex = 9;
            this.btnVarliklarim.Text = "Varlıklarım";
            this.btnVarliklarim.UseVisualStyleBackColor = true;
            this.btnVarliklarim.Click += new System.EventHandler(this.btnVarliklarim_Click);
            // 
            // btnEkibiminVarlıkları
            // 
            this.btnEkibiminVarlıkları.Location = new System.Drawing.Point(415, 76);
            this.btnEkibiminVarlıkları.Name = "btnEkibiminVarlıkları";
            this.btnEkibiminVarlıkları.Size = new System.Drawing.Size(137, 44);
            this.btnEkibiminVarlıkları.TabIndex = 10;
            this.btnEkibiminVarlıkları.Text = "Ekibimin Varlıkları";
            this.btnEkibiminVarlıkları.UseVisualStyleBackColor = true;
            this.btnEkibiminVarlıkları.Click += new System.EventHandler(this.btnEkibiminVarlıkları_Click);
            // 
            // btnTumVarliklar
            // 
            this.btnTumVarliklar.Location = new System.Drawing.Point(610, 76);
            this.btnTumVarliklar.Name = "btnTumVarliklar";
            this.btnTumVarliklar.Size = new System.Drawing.Size(172, 44);
            this.btnTumVarliklar.TabIndex = 11;
            this.btnTumVarliklar.Text = "Tüm Varlıklar";
            this.btnTumVarliklar.UseVisualStyleBackColor = true;
            this.btnTumVarliklar.Visible = false;
            this.btnTumVarliklar.Click += new System.EventHandler(this.btnTumVarliklar_Click);
            // 
            // AnaSayfa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1078, 450);
            this.Controls.Add(this.btnTumVarliklar);
            this.Controls.Add(this.btnEkibiminVarlıkları);
            this.Controls.Add(this.btnVarliklarim);
            this.Controls.Add(this.pnlUrun);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblPersonelAdi);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pnlMenu);
            this.Name = "AnaSayfa";
            this.Text = "AnaSayfa";
            this.Load += new System.EventHandler(this.AnaSayfa_Load);
            this.pnlMenu.ResumeLayout(false);
            this.pnlUrun.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlMenu;
        private System.Windows.Forms.Button btnMenü;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnKayitEkle;
        private System.Windows.Forms.Button btnRapor2;
        private System.Windows.Forms.Button btnRapor1;
        private System.Windows.Forms.Label lblPersonelAdi;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel pnlUrun;
        private System.Windows.Forms.Button btnVarliklarim;
        private System.Windows.Forms.Button btnEkibiminVarlıkları;
        private System.Windows.Forms.Button btnTumVarliklar;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}