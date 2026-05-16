namespace OOP_2._Dönem_Proje_Ödevi
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tabControl1 = new TabControl();
            MalzemeTab = new TabPage();
            MalzemeTemizleButon = new Button();
            dgvMalzemeler = new DataGridView();
            txtMalzemeAra = new TextBox();
            MalzemeAraButon = new Button();
            MalzemeGuncelleButon = new Button();
            MalzemeSilButon = new Button();
            MalzemeEkleButon = new Button();
            txtMalzemeFirmasi = new TextBox();
            txtMalzemeStogu = new TextBox();
            txtMalzemeFiyati = new TextBox();
            txtMalzemeBirimi = new TextBox();
            txtMalzemeCinsi = new TextBox();
            txtMalzemeAdi = new TextBox();
            txtMalzemeFirma = new Label();
            txtMalzemeStok = new Label();
            txtMalzemeFiyat = new Label();
            txtMalzemeBirim = new Label();
            txtMalzemeCins = new Label();
            txtMalzemeAd = new Label();
            TeklifTab = new TabPage();
            txtProjeAdi = new TextBox();
            dgvTeklifler = new DataGridView();
            btnRaporla = new Button();
            btnFiyatHesapla = new Button();
            btnTeklifGuncelle = new Button();
            btnTeklifSil = new Button();
            btnTeklifEkle = new Button();
            dgvTekliftekiMalzemeler = new DataGridView();
            btnTeklifeMalzemeEkle = new Button();
            label2 = new Label();
            txtKullanilanAdet = new TextBox();
            cmbMalzemeler = new ComboBox();
            label1 = new Label();
            txtFirmaAdi = new TextBox();
            txtTeklifNo = new TextBox();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            txtAra = new TextBox();
            btnAra = new Button();
            tabControl1.SuspendLayout();
            MalzemeTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMalzemeler).BeginInit();
            TeklifTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTeklifler).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvTekliftekiMalzemeler).BeginInit();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(MalzemeTab);
            tabControl1.Controls.Add(TeklifTab);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(800, 450);
            tabControl1.TabIndex = 0;
            // 
            // MalzemeTab
            // 
            MalzemeTab.Controls.Add(MalzemeTemizleButon);
            MalzemeTab.Controls.Add(dgvMalzemeler);
            MalzemeTab.Controls.Add(txtMalzemeAra);
            MalzemeTab.Controls.Add(MalzemeAraButon);
            MalzemeTab.Controls.Add(MalzemeGuncelleButon);
            MalzemeTab.Controls.Add(MalzemeSilButon);
            MalzemeTab.Controls.Add(MalzemeEkleButon);
            MalzemeTab.Controls.Add(txtMalzemeFirmasi);
            MalzemeTab.Controls.Add(txtMalzemeStogu);
            MalzemeTab.Controls.Add(txtMalzemeFiyati);
            MalzemeTab.Controls.Add(txtMalzemeBirimi);
            MalzemeTab.Controls.Add(txtMalzemeCinsi);
            MalzemeTab.Controls.Add(txtMalzemeAdi);
            MalzemeTab.Controls.Add(txtMalzemeFirma);
            MalzemeTab.Controls.Add(txtMalzemeStok);
            MalzemeTab.Controls.Add(txtMalzemeFiyat);
            MalzemeTab.Controls.Add(txtMalzemeBirim);
            MalzemeTab.Controls.Add(txtMalzemeCins);
            MalzemeTab.Controls.Add(txtMalzemeAd);
            MalzemeTab.Location = new Point(4, 29);
            MalzemeTab.Name = "MalzemeTab";
            MalzemeTab.Padding = new Padding(3);
            MalzemeTab.RightToLeft = RightToLeft.No;
            MalzemeTab.Size = new Size(792, 417);
            MalzemeTab.TabIndex = 0;
            MalzemeTab.Text = "Malzeme İşl.";
            MalzemeTab.UseVisualStyleBackColor = true;
            // 
            // MalzemeTemizleButon
            // 
            MalzemeTemizleButon.Location = new Point(319, 214);
            MalzemeTemizleButon.Name = "MalzemeTemizleButon";
            MalzemeTemizleButon.Size = new Size(87, 49);
            MalzemeTemizleButon.TabIndex = 9;
            MalzemeTemizleButon.Text = "Temizle";
            MalzemeTemizleButon.UseVisualStyleBackColor = true;
            MalzemeTemizleButon.Click += MalzemeTemizleButon_Click;
            // 
            // dgvMalzemeler
            // 
            dgvMalzemeler.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMalzemeler.Dock = DockStyle.Bottom;
            dgvMalzemeler.Location = new Point(3, 269);
            dgvMalzemeler.Name = "dgvMalzemeler";
            dgvMalzemeler.RowHeadersWidth = 51;
            dgvMalzemeler.Size = new Size(786, 145);
            dgvMalzemeler.TabIndex = 17;
            dgvMalzemeler.CellClick += dgvMalzemeler_CellClick;
            // 
            // txtMalzemeAra
            // 
            txtMalzemeAra.Location = new Point(622, 7);
            txtMalzemeAra.Name = "txtMalzemeAra";
            txtMalzemeAra.Size = new Size(125, 27);
            txtMalzemeAra.TabIndex = 10;
            // 
            // MalzemeAraButon
            // 
            MalzemeAraButon.Location = new Point(744, 6);
            MalzemeAraButon.Name = "MalzemeAraButon";
            MalzemeAraButon.Size = new Size(40, 29);
            MalzemeAraButon.TabIndex = 11;
            MalzemeAraButon.Text = "Ara";
            MalzemeAraButon.UseVisualStyleBackColor = true;
            MalzemeAraButon.Click += MalzemeAraButon_Click;
            // 
            // MalzemeGuncelleButon
            // 
            MalzemeGuncelleButon.Location = new Point(226, 214);
            MalzemeGuncelleButon.Name = "MalzemeGuncelleButon";
            MalzemeGuncelleButon.Size = new Size(87, 49);
            MalzemeGuncelleButon.TabIndex = 8;
            MalzemeGuncelleButon.Text = "Malzeme Güncelle";
            MalzemeGuncelleButon.UseVisualStyleBackColor = true;
            MalzemeGuncelleButon.Click += MalzemeGuncelleButon_Click;
            // 
            // MalzemeSilButon
            // 
            MalzemeSilButon.Location = new Point(133, 214);
            MalzemeSilButon.Name = "MalzemeSilButon";
            MalzemeSilButon.Size = new Size(87, 49);
            MalzemeSilButon.TabIndex = 7;
            MalzemeSilButon.Text = "Malzeme Sil";
            MalzemeSilButon.UseVisualStyleBackColor = true;
            MalzemeSilButon.Click += MalzemeSilButon_Click;
            // 
            // MalzemeEkleButon
            // 
            MalzemeEkleButon.Location = new Point(40, 214);
            MalzemeEkleButon.Name = "MalzemeEkleButon";
            MalzemeEkleButon.Size = new Size(87, 49);
            MalzemeEkleButon.TabIndex = 6;
            MalzemeEkleButon.Text = "Malzeme Ekle";
            MalzemeEkleButon.UseVisualStyleBackColor = true;
            MalzemeEkleButon.Click += MalzemeEkleButon_Click;
            // 
            // txtMalzemeFirmasi
            // 
            txtMalzemeFirmasi.Location = new Point(162, 168);
            txtMalzemeFirmasi.Name = "txtMalzemeFirmasi";
            txtMalzemeFirmasi.Size = new Size(125, 27);
            txtMalzemeFirmasi.TabIndex = 5;
            // 
            // txtMalzemeStogu
            // 
            txtMalzemeStogu.Location = new Point(162, 135);
            txtMalzemeStogu.Name = "txtMalzemeStogu";
            txtMalzemeStogu.Size = new Size(125, 27);
            txtMalzemeStogu.TabIndex = 4;
            // 
            // txtMalzemeFiyati
            // 
            txtMalzemeFiyati.Location = new Point(162, 102);
            txtMalzemeFiyati.Name = "txtMalzemeFiyati";
            txtMalzemeFiyati.Size = new Size(125, 27);
            txtMalzemeFiyati.TabIndex = 3;
            // 
            // txtMalzemeBirimi
            // 
            txtMalzemeBirimi.Location = new Point(162, 69);
            txtMalzemeBirimi.Name = "txtMalzemeBirimi";
            txtMalzemeBirimi.Size = new Size(125, 27);
            txtMalzemeBirimi.TabIndex = 2;
            // 
            // txtMalzemeCinsi
            // 
            txtMalzemeCinsi.Location = new Point(162, 36);
            txtMalzemeCinsi.Name = "txtMalzemeCinsi";
            txtMalzemeCinsi.Size = new Size(125, 27);
            txtMalzemeCinsi.TabIndex = 1;
            // 
            // txtMalzemeAdi
            // 
            txtMalzemeAdi.Location = new Point(162, 3);
            txtMalzemeAdi.Name = "txtMalzemeAdi";
            txtMalzemeAdi.Size = new Size(125, 27);
            txtMalzemeAdi.TabIndex = 0;
            // 
            // txtMalzemeFirma
            // 
            txtMalzemeFirma.AutoSize = true;
            txtMalzemeFirma.Location = new Point(40, 171);
            txtMalzemeFirma.Name = "txtMalzemeFirma";
            txtMalzemeFirma.Size = new Size(98, 20);
            txtMalzemeFirma.TabIndex = 5;
            txtMalzemeFirma.Text = "Kaynak firma:";
            // 
            // txtMalzemeStok
            // 
            txtMalzemeStok.AutoSize = true;
            txtMalzemeStok.Location = new Point(40, 138);
            txtMalzemeStok.Name = "txtMalzemeStok";
            txtMalzemeStok.Size = new Size(114, 20);
            txtMalzemeStok.TabIndex = 4;
            txtMalzemeStok.Text = "Malzeme stoğu:";
            // 
            // txtMalzemeFiyat
            // 
            txtMalzemeFiyat.AutoSize = true;
            txtMalzemeFiyat.Location = new Point(40, 105);
            txtMalzemeFiyat.Name = "txtMalzemeFiyat";
            txtMalzemeFiyat.Size = new Size(110, 20);
            txtMalzemeFiyat.TabIndex = 3;
            txtMalzemeFiyat.Text = "Malzeme fiyatı:";
            // 
            // txtMalzemeBirim
            // 
            txtMalzemeBirim.AutoSize = true;
            txtMalzemeBirim.Location = new Point(40, 72);
            txtMalzemeBirim.Name = "txtMalzemeBirim";
            txtMalzemeBirim.Size = new Size(116, 20);
            txtMalzemeBirim.TabIndex = 2;
            txtMalzemeBirim.Text = "Malzeme birimi:";
            // 
            // txtMalzemeCins
            // 
            txtMalzemeCins.AutoSize = true;
            txtMalzemeCins.Location = new Point(40, 39);
            txtMalzemeCins.Name = "txtMalzemeCins";
            txtMalzemeCins.Size = new Size(106, 20);
            txtMalzemeCins.TabIndex = 1;
            txtMalzemeCins.Text = "Malzeme cinsi:";
            // 
            // txtMalzemeAd
            // 
            txtMalzemeAd.AutoSize = true;
            txtMalzemeAd.Location = new Point(40, 6);
            txtMalzemeAd.Name = "txtMalzemeAd";
            txtMalzemeAd.Size = new Size(98, 20);
            txtMalzemeAd.TabIndex = 0;
            txtMalzemeAd.Text = "Malzeme adı:";
            // 
            // TeklifTab
            // 
            TeklifTab.Controls.Add(btnAra);
            TeklifTab.Controls.Add(txtAra);
            TeklifTab.Controls.Add(txtProjeAdi);
            TeklifTab.Controls.Add(dgvTeklifler);
            TeklifTab.Controls.Add(btnRaporla);
            TeklifTab.Controls.Add(btnFiyatHesapla);
            TeklifTab.Controls.Add(btnTeklifGuncelle);
            TeklifTab.Controls.Add(btnTeklifSil);
            TeklifTab.Controls.Add(btnTeklifEkle);
            TeklifTab.Controls.Add(dgvTekliftekiMalzemeler);
            TeklifTab.Controls.Add(btnTeklifeMalzemeEkle);
            TeklifTab.Controls.Add(label2);
            TeklifTab.Controls.Add(txtKullanilanAdet);
            TeklifTab.Controls.Add(cmbMalzemeler);
            TeklifTab.Controls.Add(label1);
            TeklifTab.Controls.Add(txtFirmaAdi);
            TeklifTab.Controls.Add(txtTeklifNo);
            TeklifTab.Controls.Add(label4);
            TeklifTab.Controls.Add(label5);
            TeklifTab.Controls.Add(label6);
            TeklifTab.Location = new Point(4, 29);
            TeklifTab.Name = "TeklifTab";
            TeklifTab.Padding = new Padding(3);
            TeklifTab.Size = new Size(792, 417);
            TeklifTab.TabIndex = 1;
            TeklifTab.Text = "Teklif İşl.";
            TeklifTab.UseVisualStyleBackColor = true;
            // 
            // txtProjeAdi
            // 
            txtProjeAdi.Location = new Point(117, 69);
            txtProjeAdi.Name = "txtProjeAdi";
            txtProjeAdi.Size = new Size(125, 27);
            txtProjeAdi.TabIndex = 2;
            // 
            // dgvTeklifler
            // 
            dgvTeklifler.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTeklifler.Location = new Point(317, 69);
            dgvTeklifler.Name = "dgvTeklifler";
            dgvTeklifler.RowHeadersWidth = 51;
            dgvTeklifler.Size = new Size(469, 292);
            dgvTeklifler.TabIndex = 32;
            dgvTeklifler.CellClick += dgvTeklifler_CellClick;
            // 
            // btnRaporla
            // 
            btnRaporla.Location = new Point(690, 6);
            btnRaporla.Name = "btnRaporla";
            btnRaporla.Size = new Size(94, 53);
            btnRaporla.TabIndex = 31;
            btnRaporla.Text = "Raporla";
            btnRaporla.UseVisualStyleBackColor = true;
            // 
            // btnFiyatHesapla
            // 
            btnFiyatHesapla.Location = new Point(590, 6);
            btnFiyatHesapla.Name = "btnFiyatHesapla";
            btnFiyatHesapla.Size = new Size(94, 53);
            btnFiyatHesapla.TabIndex = 30;
            btnFiyatHesapla.Text = "Fiyat Hesapla";
            btnFiyatHesapla.UseVisualStyleBackColor = true;
            // 
            // btnTeklifGuncelle
            // 
            btnTeklifGuncelle.Location = new Point(490, 6);
            btnTeklifGuncelle.Name = "btnTeklifGuncelle";
            btnTeklifGuncelle.Size = new Size(94, 53);
            btnTeklifGuncelle.TabIndex = 29;
            btnTeklifGuncelle.Text = "Teklif Güncelle";
            btnTeklifGuncelle.UseVisualStyleBackColor = true;
            // 
            // btnTeklifSil
            // 
            btnTeklifSil.Location = new Point(403, 6);
            btnTeklifSil.Name = "btnTeklifSil";
            btnTeklifSil.Size = new Size(81, 53);
            btnTeklifSil.TabIndex = 28;
            btnTeklifSil.Text = "Teklif Sil";
            btnTeklifSil.UseVisualStyleBackColor = true;
            // 
            // btnTeklifEkle
            // 
            btnTeklifEkle.Location = new Point(317, 6);
            btnTeklifEkle.Name = "btnTeklifEkle";
            btnTeklifEkle.Size = new Size(80, 53);
            btnTeklifEkle.TabIndex = 27;
            btnTeklifEkle.Text = "Teklif Ekle";
            btnTeklifEkle.UseVisualStyleBackColor = true;
            btnTeklifEkle.Click += btnTeklifEkle_Click;
            // 
            // dgvTekliftekiMalzemeler
            // 
            dgvTekliftekiMalzemeler.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTekliftekiMalzemeler.Location = new Point(41, 247);
            dgvTekliftekiMalzemeler.Name = "dgvTekliftekiMalzemeler";
            dgvTekliftekiMalzemeler.RowHeadersWidth = 51;
            dgvTekliftekiMalzemeler.Size = new Size(270, 147);
            dgvTekliftekiMalzemeler.TabIndex = 26;
            // 
            // btnTeklifeMalzemeEkle
            // 
            btnTeklifeMalzemeEkle.Location = new Point(40, 192);
            btnTeklifeMalzemeEkle.Name = "btnTeklifeMalzemeEkle";
            btnTeklifeMalzemeEkle.Size = new Size(87, 49);
            btnTeklifeMalzemeEkle.TabIndex = 5;
            btnTeklifeMalzemeEkle.Text = "Malzeme Ekle";
            btnTeklifeMalzemeEkle.UseVisualStyleBackColor = true;
            btnTeklifeMalzemeEkle.Click += btnTeklifeMalzemeEkle_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(41, 159);
            label2.Name = "label2";
            label2.Size = new Size(113, 20);
            label2.TabIndex = 24;
            label2.Text = "Kullanılan Adet:";
            // 
            // txtKullanilanAdet
            // 
            txtKullanilanAdet.Location = new Point(160, 156);
            txtKullanilanAdet.Name = "txtKullanilanAdet";
            txtKullanilanAdet.Size = new Size(125, 27);
            txtKullanilanAdet.TabIndex = 4;
            // 
            // cmbMalzemeler
            // 
            cmbMalzemeler.FormattingEnabled = true;
            cmbMalzemeler.Location = new Point(160, 122);
            cmbMalzemeler.Name = "cmbMalzemeler";
            cmbMalzemeler.Size = new Size(151, 28);
            cmbMalzemeler.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(40, 125);
            label1.Name = "label1";
            label1.Size = new Size(100, 20);
            label1.TabIndex = 21;
            label1.Text = "Malzeme Seç:";
            // 
            // txtFirmaAdi
            // 
            txtFirmaAdi.Location = new Point(117, 36);
            txtFirmaAdi.Name = "txtFirmaAdi";
            txtFirmaAdi.Size = new Size(125, 27);
            txtFirmaAdi.TabIndex = 1;
            // 
            // txtTeklifNo
            // 
            txtTeklifNo.Location = new Point(117, 3);
            txtTeklifNo.Name = "txtTeklifNo";
            txtTeklifNo.Size = new Size(125, 27);
            txtTeklifNo.TabIndex = 0;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(40, 72);
            label4.Name = "label4";
            label4.Size = new Size(73, 20);
            label4.TabIndex = 14;
            label4.Text = "Proje Adi:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(40, 39);
            label5.Name = "label5";
            label5.Size = new Size(76, 20);
            label5.TabIndex = 13;
            label5.Text = "Firma Adı:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(40, 6);
            label6.Name = "label6";
            label6.Size = new Size(71, 20);
            label6.TabIndex = 12;
            label6.Text = "Teklif No:";
            // 
            // txtAra
            // 
            txtAra.Location = new Point(620, 366);
            txtAra.Name = "txtAra";
            txtAra.Size = new Size(125, 27);
            txtAra.TabIndex = 33;
            // 
            // btnAra
            // 
            btnAra.Location = new Point(742, 366);
            btnAra.Name = "btnAra";
            btnAra.Size = new Size(42, 29);
            btnAra.TabIndex = 34;
            btnAra.Text = "Ara";
            btnAra.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tabControl1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            tabControl1.ResumeLayout(false);
            MalzemeTab.ResumeLayout(false);
            MalzemeTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMalzemeler).EndInit();
            TeklifTab.ResumeLayout(false);
            TeklifTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTeklifler).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvTekliftekiMalzemeler).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage MalzemeTab;
        private TabPage TeklifTab;
        private Label txtMalzemeCins;
        private Label txtMalzemeAd;
        private Label txtMalzemeFiyat;
        private Label txtMalzemeBirim;
        private Label txtMalzemeFirma;
        private Label txtMalzemeStok;
        private TextBox txtMalzemeCinsi;
        private TextBox txtMalzemeAdi;
        private Button MalzemeGuncelleButon;
        private Button MalzemeSilButon;
        private Button MalzemeEkleButon;
        private TextBox txtMalzemeFirmasi;
        private TextBox txtMalzemeStogu;
        private TextBox txtMalzemeFiyati;
        private TextBox txtMalzemeBirimi;
        private DataGridView dgvMalzemeler;
        private TextBox txtMalzemeAra;
        private Button MalzemeAraButon;
        private Button MalzemeTemizleButon;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox4;
        private TextBox txtFirmaAdi;
        private TextBox txtTeklifNo;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private ComboBox cmbMalzemeler;
        private Label label1;
        private DataGridView dgvTekliftekiMalzemeler;
        private Button btnTeklifeMalzemeEkle;
        private Label label2;
        private TextBox txtKullanilanAdet;
        private DataGridView dgvTeklifler;
        private Button btnRaporla;
        private Button btnFiyatHesapla;
        private Button btnTeklifGuncelle;
        private Button btnTeklifSil;
        private Button btnTeklifEkle;
        private TextBox txtProjeAdi;
        private Button btnAra;
        private TextBox txtAra;
    }
}
