/****************************************************************************
**					SAKARYA ÜNİVERSİTESİ
**				BİLGİSAYAR VE BİLİŞİM BİLİMLERİ FAKÜLTESİ
**				    BİLGİSAYAR MÜHENDİSLİĞİ BÖLÜMÜ
**				   NESNEYE DAYALI PROGRAMLAMA DERSİ
**					2014-2015 BAHAR DÖNEMİ
**
**				ÖDEV NUMARASI..........: Proje Ödevi
**				ÖĞRENCİ ADI............: Ahmed Selim Yılmaz
**				ÖĞRENCİ NUMARASI.......: B251210005
**              DERSİN ALINDIĞI GRUP...: B Grubu
****************************************************************************/

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;

namespace OOP_2._Dönem_Proje_Ödevi
{
    public partial class Form1 : Form
    {
        // Eklenecek tüm malzemeleri hafızada tutacak listemiz
        List<Malzeme> malzemeListesi = new List<Malzeme>();

        // Sadece o an ekranda hazırlanan teklifin malzemelerini tutacak geçici liste
        List<Malzeme> geciciTeklifMalzemeleri = new List<Malzeme>();

        // Sisteme kaydedilen tüm teklifleri tutacak ana listemiz
        List<Teklif> teklifListesi = new List<Teklif>();

        // Verileri kaydedeceğimiz txt dosyasının adı
        string dosyaYolu = "malzemeler.txt";

        // Teklifleri kaydedeceğimiz ikinci txt dosyasının adı
        string teklifDosyaYolu = "teklifler.txt";

        public Form1()
        {
            InitializeComponent();
        }

        // Listeyi DataGridView'e bağlayan ve her yeni eklemede tabloyu tazeleyen metodumuz
        private void MalzemeleriListele()
        {
            // Tablonun veri kaynağı sıfırlanıyor ve ana listeye bağlanıyor
            dgvMalzemeler.DataSource = null;
            dgvMalzemeler.DataSource = malzemeListesi;

            // GİZLEME KODU: Sütun otomatik oluştuktan hemen sonra görünmez yapıyoruz
            if (dgvMalzemeler.Columns["KullanilanAdet"] != null)
            {
                dgvMalzemeler.Columns["KullanilanAdet"].Visible = false;
            }
        }

        private void TeklifleriListele()
        {
            // Ana tablonun veri kaynağı sıfırlanıyor ve güncel teklif listesine bağlanıyor
            dgvTeklifler.DataSource = null;
            dgvTeklifler.DataSource = teklifListesi;
        }

        private void GeciciMalzemeleriListele()
        {
            // Küçük tablonun veri kaynağı sıfırlanıyor ve geçici listeye bağlanıyor
            dgvTekliftekiMalzemeler.DataSource = null;
            dgvTekliftekiMalzemeler.DataSource = geciciTeklifMalzemeleri;
        }

        private void MetinKutulariniTemizle()
        {
            // Formdaki veri giriş kutularının içerisi boşaltılıyor
            txtMalzemeAdi.Clear();
            txtMalzemeCinsi.Clear();
            txtMalzemeBirimi.Clear();
            txtMalzemeFiyati.Clear();
            txtMalzemeStogu.Clear();
            txtMalzemeFirmasi.Clear();
            txtMalzemeAra.Clear();
            MalzemeleriListele();
        }

        private void MalzemeleriDosyayaYaz()
        {
            // Kaydedilecek satırları tutacağımız geçici liste
            List<string> kaydedilecekSatirlar = new List<string>();

            // Döngü ile listedeki her eleman metin satırına çevriliyor
            foreach (Malzeme eleman in malzemeListesi)
            {
                string satir = eleman.MalzemeAdi + "|" + eleman.MalzemeCinsi + "|" + eleman.Birimi + "|" + eleman.Fiyati + "|" + eleman.StokAdedi + "|" + eleman.TeminEdilenFirma;
                kaydedilecekSatirlar.Add(satir);
            }

            // Oluşturulan satırlar tek seferde dosyaya yazılıyor
            File.WriteAllLines(dosyaYolu, kaydedilecekSatirlar);
        }

        private void DosyadanMalzemeleriOku()
        {
            // Dosyanın var olup olmadığı kontrol ediliyor
            if (File.Exists(dosyaYolu))
            {
                // Dosyadaki tüm satırlar okunuyor
                string[] okunanSatirlar = File.ReadAllLines(dosyaYolu);

                // Her bir satır tekrar nesneye dönüştürülüyor
                foreach (string satir in okunanSatirlar)
                {
                    string[] parcalar = satir.Split('|');

                    // Satırda eksik bilgi olup olmadığı kontrol ediliyor
                    if (parcalar.Length == 6)
                    {
                        Malzeme okunan = new Malzeme();
                        okunan.MalzemeAdi = parcalar[0];
                        okunan.MalzemeCinsi = parcalar[1];
                        okunan.Birimi = parcalar[2];
                        okunan.Fiyati = Convert.ToDouble(parcalar[3]);
                        okunan.StokAdedi = Convert.ToInt32(parcalar[4]);
                        okunan.TeminEdilenFirma = parcalar[5];

                        malzemeListesi.Add(okunan);
                    }


                }
            }
        }

        private void TeklifleriDosyayaYaz()
        {
            List<string> kaydedilecekSatirlar = new List<string>();

            foreach (Teklif teklif in teklifListesi)
            {
                string anaBilgiler = $"{teklif.TeklifNo}|{teklif.FirmaAdi}|{teklif.ProjeAdi}";

                string malzemeBilgileri = "";
                foreach (Malzeme m in teklif.KullanilanMalzemeler)
                {
                    malzemeBilgileri += $"{m.MalzemeAdi}={m.MalzemeCinsi}={m.Birimi}={m.Fiyati}={m.TeminEdilenFirma}={m.StokAdedi}={m.KullanilanAdet}~";
                }

                if (malzemeBilgileri.Length > 0)
                {
                    malzemeBilgileri = malzemeBilgileri.TrimEnd('~');
                }

                kaydedilecekSatirlar.Add(anaBilgiler + "|" + malzemeBilgileri);
            }

            File.WriteAllLines(teklifDosyaYolu, kaydedilecekSatirlar);
        }

        private void DosyadanTeklifleriOku()
        {
            if (File.Exists(teklifDosyaYolu))
            {
                string[] satirlar = File.ReadAllLines(teklifDosyaYolu);

                foreach (string satir in satirlar)
                {
                    string[] parcalar = satir.Split('|');

                    if (parcalar.Length >= 4)
                    {
                        Teklif okunanTeklif = new Teklif();
                        okunanTeklif.TeklifNo = parcalar[0];
                        okunanTeklif.FirmaAdi = parcalar[1];
                        okunanTeklif.ProjeAdi = parcalar[2];

                        string[] malzemeler = parcalar[3].Split('~');
                        foreach (string m in malzemeler)
                        {
                            string[] mDetay = m.Split('=');

                            if (mDetay.Length == 7)
                            {
                                Malzeme okunanMalzeme = new Malzeme();
                                okunanMalzeme.MalzemeAdi = mDetay[0];
                                okunanMalzeme.MalzemeCinsi = mDetay[1];
                                okunanMalzeme.Birimi = mDetay[2];
                                okunanMalzeme.Fiyati = Convert.ToDouble(mDetay[3]);
                                okunanMalzeme.TeminEdilenFirma = mDetay[4];
                                okunanMalzeme.StokAdedi = Convert.ToInt32(mDetay[5]);
                                okunanMalzeme.KullanilanAdet = Convert.ToInt32(mDetay[6]);

                                okunanTeklif.KullanilanMalzemeler.Add(okunanMalzeme);
                            }
                        }

                        teklifListesi.Add(okunanTeklif);
                    }
                }
            }
        }

        private void ComboboxaMalzemeleriDoldur()
        {
            // Önce ComboBox'ın içini temizliyoruz
            cmbMalzemeler.Items.Clear();

            // Malzeme listemizdeki her bir elemanı ComboBox'a ekliyoruz
            foreach (Malzeme eleman in malzemeListesi)
            {
                // Ekranda malzemenin adının ve cinsinin görünmesini sağlıyoruz
                cmbMalzemeler.Items.Add(eleman.MalzemeAdi + " - " + eleman.MalzemeCinsi);
            }
        }
        private void MalzemeEkleButon_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMalzemeAdi.Text) || string.IsNullOrWhiteSpace(txtMalzemeFiyati.Text))
            {
                MessageBox.Show("Lütfen Malzeme Adı ve Fiyatı alanlarını doldurun!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Hata çıkarma potansiyeli olan sayısal çeviri işlemleri try-catch bloğuna alınıyor
            try
            {
                Malzeme yeniMalzeme = new Malzeme();
                yeniMalzeme.MalzemeAdi = txtMalzemeAdi.Text;
                yeniMalzeme.MalzemeCinsi = txtMalzemeCinsi.Text;
                yeniMalzeme.Birimi = txtMalzemeBirimi.Text;

                // Eğer kullanıcı buraya harf girerse, program çökmek yerine anında 'catch' bloğuna atlayacak
                yeniMalzeme.Fiyati = Convert.ToDouble(txtMalzemeFiyati.Text);
                yeniMalzeme.StokAdedi = Convert.ToInt32(txtMalzemeStogu.Text);

                yeniMalzeme.TeminEdilenFirma = txtMalzemeFirmasi.Text;

                malzemeListesi.Add(yeniMalzeme);
                MalzemeleriListele();
                MetinKutulariniTemizle();
                ComboboxaMalzemeleriDoldur();

                MessageBox.Show("Malzeme başarıyla eklendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                // try içindeki kodlarda bir çevirme hatası olursa program buraya düşer
                MessageBox.Show("Lütfen Fiyat ve Stok Adedi alanlarına sadece sayısal değerler (Örn: 10,5 veya 100) giriniz!", "Sayısal Veri Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MalzemeSilButon_Click(object sender, EventArgs e)
        {
            // Tablodan silmek için bir satırın seçilip seçilmediği kontrol ediliyor
            if (dgvMalzemeler.CurrentRow != null)
            {
                // Seçili satırdaki veri arka planda bir Malzeme nesnesine dönüştürülüp değişkene atanıyor
                Malzeme SecilenMalzeme = (Malzeme)dgvMalzemeler.CurrentRow.DataBoundItem;

                // Seçilen malzeme arka plandaki ana depomuzdan (listeden) siliniyor
                malzemeListesi.Remove(SecilenMalzeme);

                MalzemeleriDosyayaYaz();

                // Vitrindeki görünümün tazelenmesi için listeleme fonksiyonu tekrar çağrılıyor
                MalzemeleriListele();

                ComboboxaMalzemeleriDoldur();

                MessageBox.Show("Malzeme başarıyla silindi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // Eğer kullanıcı tablodan hiçbir şey seçmeden butona basarsa uyar
                MessageBox.Show("Lütfen silmek için tablodan bir malzeme seçiniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dgvMalzemeler_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Tabloda boş bir yere değil, gerçekten dolu bir satıra tıklandığı kontrol ediliyor
            if (dgvMalzemeler.CurrentRow != null)
            {
                // Seçili satırdaki veri arka planda bir Malzeme nesnesine dönüştürülüyor
                Malzeme SecilenMalzeme = (Malzeme)dgvMalzemeler.CurrentRow.DataBoundItem;

                // Nesnenin özellikleri metin kutularına aktarılıyor
                txtMalzemeAdi.Text = SecilenMalzeme.MalzemeAdi;
                txtMalzemeCinsi.Text = SecilenMalzeme.MalzemeCinsi;
                txtMalzemeBirimi.Text = SecilenMalzeme.Birimi;
                txtMalzemeFiyati.Text = SecilenMalzeme.Fiyati.ToString();
                txtMalzemeStogu.Text = SecilenMalzeme.StokAdedi.ToString();
                txtMalzemeFirmasi.Text = SecilenMalzeme.TeminEdilenFirma;
            }
        }

        private void MalzemeGuncelleButon_Click(object sender, EventArgs e)
        {
            if (dgvMalzemeler.CurrentRow != null)
            {
                if (string.IsNullOrWhiteSpace(txtMalzemeAdi.Text) || string.IsNullOrWhiteSpace(txtMalzemeFiyati.Text))
                {
                    MessageBox.Show("Lütfen Malzeme Adı ve Fiyatı alanlarını boş bırakmayın!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Kullanıcının harf girme ihtimaline karşı try-catch
                try
                {
                    Malzeme guncellenecekMalzeme = (Malzeme)dgvMalzemeler.CurrentRow.DataBoundItem;

                    guncellenecekMalzeme.MalzemeAdi = txtMalzemeAdi.Text;
                    guncellenecekMalzeme.MalzemeCinsi = txtMalzemeCinsi.Text;
                    guncellenecekMalzeme.Birimi = txtMalzemeBirimi.Text;

                    // Riskli çevirme işlemleri
                    guncellenecekMalzeme.Fiyati = Convert.ToDouble(txtMalzemeFiyati.Text);
                    guncellenecekMalzeme.StokAdedi = Convert.ToInt32(txtMalzemeStogu.Text);

                    guncellenecekMalzeme.TeminEdilenFirma = txtMalzemeFirmasi.Text;

                    // Malzeme listesindeki değişiklikleri dosyaya yansıtıyoruz
                    MalzemeleriDosyayaYaz();
                    MalzemeleriListele();
                    MetinKutulariniTemizle();
                    ComboboxaMalzemeleriDoldur(); // 2. sekmedeki menü de güncellensin diye

                    MessageBox.Show("Malzeme başarıyla güncellendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception)
                {
                    MessageBox.Show("Lütfen Fiyat ve Stok Adedi alanlarına sadece sayısal değerler giriniz!", "Sayısal Veri Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Lütfen güncellemek için listeden bir malzeme seçiniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void MalzemeTemizleButon_Click(object sender, EventArgs e)
        {
            // Temizle butonuna basıldığında metin kutularını sıfırlayan fonksiyon çağrılıyor
            MetinKutulariniTemizle();
        }

        private void MalzemeAraButon_Click(object sender, EventArgs e)
        {
            // Arama kutusuna girilen metin alınıyor ve küçük harfe çevriliyor
            string arananKelime = txtMalzemeAra.Text.ToLower();

            // Arama kutusunun boş olup olmadığı kontrol ediliyor
            if (string.IsNullOrWhiteSpace(arananKelime))
            {
                // Eğer kutu boşsa veya sadece boşluk varsa tüm listeyi tekrar ekrana getir
                MalzemeleriListele();
            }
            else
            {
                // Sadece aranan şarta uyanları tutmak için geçici bir liste oluşturuyoruz
                List<Malzeme> filtrelenmisListe = new List<Malzeme>();

                // Döngü ile listedeki her bir malzeme tek tek kontrol ediliyor
                foreach (Malzeme eleman in malzemeListesi)
                {
                    // Eğer malzemenin adı veya cinsi, aranan kelimeyi içeriyorsa geçici listeye ekle
                    if (eleman.MalzemeAdi.ToLower().Contains(arananKelime) || eleman.MalzemeCinsi.ToLower().Contains(arananKelime))
                    {
                        filtrelenmisListe.Add(eleman);
                    }
                }

                // Tablonun veri kaynağı sıfırlanıp, sadece filtrelenmiş listeye bağlanıyor
                dgvMalzemeler.DataSource = null;
                dgvMalzemeler.DataSource = filtrelenmisListe;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DosyadanMalzemeleriOku();
            MalzemeleriListele();
            ComboboxaMalzemeleriDoldur();
            DosyadanTeklifleriOku();
            TeklifleriListele();
        }

        private void btnTeklifeMalzemeEkle_Click(object sender, EventArgs e)
        {
            if (cmbMalzemeler.SelectedIndex != -1)
            {
                if (string.IsNullOrWhiteSpace(txtKullanilanAdet.Text))
                {
                    MessageBox.Show("Lütfen kullanılacak adeti giriniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                try
                {
                    int secilenIndeks = cmbMalzemeler.SelectedIndex;
                    Malzeme anaMalzeme = malzemeListesi[secilenIndeks];

                    Malzeme teklifeEklenecek = new Malzeme();
                    teklifeEklenecek.MalzemeAdi = anaMalzeme.MalzemeAdi;
                    teklifeEklenecek.MalzemeCinsi = anaMalzeme.MalzemeCinsi;
                    teklifeEklenecek.Birimi = anaMalzeme.Birimi;
                    teklifeEklenecek.Fiyati = anaMalzeme.Fiyati;
                    teklifeEklenecek.TeminEdilenFirma = anaMalzeme.TeminEdilenFirma;
                    teklifeEklenecek.StokAdedi = anaMalzeme.StokAdedi;

                    // Kullanıcının girdiği adet değeri sayıya çevrilmeyi deneniyor
                    teklifeEklenecek.KullanilanAdet = Convert.ToInt32(txtKullanilanAdet.Text);

                    geciciTeklifMalzemeleri.Add(teklifeEklenecek);
                    GeciciMalzemeleriListele();
                    txtKullanilanAdet.Clear();
                }
                catch (Exception)
                {
                    // Eğer çevrilemezse hata mesajı veriliyor
                    MessageBox.Show("Lütfen 'Kullanılacak Adet' kısmına sadece tam sayı (Örn: 5) giriniz!", "Format Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Lütfen önce açılır listeden bir malzeme seçiniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnTeklifEkle_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTeklifNo.Text) || string.IsNullOrWhiteSpace(txtFirmaAdi.Text) || string.IsNullOrWhiteSpace(txtProjeAdi.Text))
            {
                MessageBox.Show("Lütfen Teklif No, Firma Adı ve Proje Adı alanlarını doldurunuz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (geciciTeklifMalzemeleri.Count == 0)
            {
                MessageBox.Show("Bir teklif oluşturabilmek için en az bir malzeme eklemelisiniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Dosyanın okuma/yazma sırasında kilitlenmesi ihtimaline karşı try-catch
            try
            {
                Teklif yeniTeklif = new Teklif();
                yeniTeklif.TeklifNo = txtTeklifNo.Text;
                yeniTeklif.FirmaAdi = txtFirmaAdi.Text;
                yeniTeklif.ProjeAdi = txtProjeAdi.Text;
                yeniTeklif.KullanilanMalzemeler = System.Linq.Enumerable.ToList(geciciTeklifMalzemeleri);

                teklifListesi.Add(yeniTeklif);

                // Hata çıkarma ihtimali olan dosya kayıt işlemi
                TeklifleriDosyayaYaz();
                TeklifleriListele();

                geciciTeklifMalzemeleri.Clear();
                GeciciMalzemeleriListele();

                txtTeklifNo.Clear();
                txtFirmaAdi.Clear();
                txtProjeAdi.Clear();

                MessageBox.Show("Teklif başarıyla oluşturuldu ve sisteme kaydedildi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                // Dosya kaynaklı bir sorun olursa ex.Message ile bilgisayarın verdiği asıl hatayı da gösteriyoruz
                MessageBox.Show("Teklif kaydedilirken sistemsel bir hata oluştu. Txt dosyası açık kalmış olabilir.\nHata Detayı: " + ex.Message, "Kayıt Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvTeklifler_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvTeklifler.CurrentRow != null)
            {
                Teklif secilenTeklif = (Teklif)dgvTeklifler.CurrentRow.DataBoundItem;

                txtTeklifNo.Text = secilenTeklif.TeklifNo;
                txtFirmaAdi.Text = secilenTeklif.FirmaAdi;
                txtProjeAdi.Text = secilenTeklif.ProjeAdi;

                // GÜNCELLEME: Seçilen teklifin malzemelerini geçici listemize kopyalıyoruz
                // Böylece üzerine yeni malzeme eklemeye veya silmeye devam edebiliriz
                geciciTeklifMalzemeleri = System.Linq.Enumerable.ToList(secilenTeklif.KullanilanMalzemeler);

                // Küçük tabloyu bu güncellenmiş geçici listeye bağlıyoruz
                GeciciMalzemeleriListele();
            }
        }

        private void btnTeklifSil_Click(object sender, EventArgs e)
        {
            // Tablodan silmek için bir teklifin seçilip seçilmediği kontrol ediliyor
            if (dgvTeklifler.CurrentRow != null)
            {
                // Yanlışlıkla silmelere karşı kullanıcıdan onay isteniyor
                DialogResult cevap = MessageBox.Show("Seçili teklifi silmek istediğinize emin misiniz?", "Silme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                // Eğer kullanıcı 'Evet' derse silme işlemi başlıyor
                if (cevap == DialogResult.Yes)
                {
                    // Seçilen satırdaki teklif nesnesi alınıyor
                    Teklif secilenTeklif = (Teklif)dgvTeklifler.CurrentRow.DataBoundItem;

                    // Teklif, ana listeden siliniyor
                    teklifListesi.Remove(secilenTeklif);

                    // Güncel liste dosyaya yazılarak silme işlemi kalıcı hale getiriliyor
                    TeklifleriDosyayaYaz();

                    // Ana tablo güncelleniyor
                    TeklifleriListele();

                    // TEMİZLİK: Ekrandaki kutular ve küçük tablo (eski veriler görünmesin diye) temizleniyor
                    txtTeklifNo.Clear();
                    txtFirmaAdi.Clear();
                    txtProjeAdi.Clear();

                    // Küçük tablonun bağlantısı koparılarak içi boşaltılıyor
                    dgvTekliftekiMalzemeler.DataSource = null;

                    // Geçici liste de sıfırlanıyor
                    geciciTeklifMalzemeleri.Clear();

                    MessageBox.Show("Teklif başarıyla silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Lütfen silmek için sağdaki tablodan bir teklif seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnTeklifGuncelle_Click(object sender, EventArgs e)
        {
            if (dgvTeklifler.CurrentRow != null)
            {
                if (string.IsNullOrWhiteSpace(txtTeklifNo.Text) || string.IsNullOrWhiteSpace(txtFirmaAdi.Text) || string.IsNullOrWhiteSpace(txtProjeAdi.Text))
                {
                    MessageBox.Show("Lütfen Teklif No, Firma Adı ve Proje Adı alanlarını boş bırakmayın!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                try
                {
                    Teklif guncellenecekTeklif = (Teklif)dgvTeklifler.CurrentRow.DataBoundItem;

                    guncellenecekTeklif.TeklifNo = txtTeklifNo.Text;
                    guncellenecekTeklif.FirmaAdi = txtFirmaAdi.Text;
                    guncellenecekTeklif.ProjeAdi = txtProjeAdi.Text;
                    guncellenecekTeklif.KullanilanMalzemeler = System.Linq.Enumerable.ToList(geciciTeklifMalzemeleri);

                    // Hata çıkarma ihtimali olan dosya kayıt işlemi
                    TeklifleriDosyayaYaz();
                    TeklifleriListele();

                    txtTeklifNo.Clear();
                    txtFirmaAdi.Clear();
                    txtProjeAdi.Clear();
                    dgvTekliftekiMalzemeler.DataSource = null;
                    geciciTeklifMalzemeleri.Clear();

                    MessageBox.Show("Teklif bilgileri başarıyla güncellendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Teklif güncellenirken dosyaya yazılamadı!\nHata Detayı: " + ex.Message, "Kayıt Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Lütfen güncellemek için sağdaki tablodan bir teklif seçiniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnTekliftenMalzemeSil_Click(object sender, EventArgs e)
        {
            // Sol alttaki küçük tablodan silmek için bir malzemenin seçili olup olmadığı kontrol ediliyor
            if (dgvTekliftekiMalzemeler.CurrentRow != null)
            {
                // Seçili satırdaki malzeme nesnesi arka plandan çekiliyor
                Malzeme secilenMalzeme = (Malzeme)dgvTekliftekiMalzemeler.CurrentRow.DataBoundItem;

                // Seçilen malzeme o anki teklifin geçici listesinden çıkartılıyor
                geciciTeklifMalzemeleri.Remove(secilenMalzeme);

                // Değişikliğin ekranda görünmesi için küçük tablo vitrini tazeleniyor
                GeciciMalzemeleriListele();

                MessageBox.Show("Malzeme teklif listesinden kaldırıldı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Lütfen tekliften kaldırmak için küçük tablodan bir malzeme seçiniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnFiyatHesapla_Click(object sender, EventArgs e)
        {
            // Ekranda (geçici listede) hesaplanacak malzeme olup olmadığı kontrol ediliyor
            if (geciciTeklifMalzemeleri.Count > 0)
            {
                // Toplam tutarı tutacağımız değişken sıfırdan başlatılıyor
                double toplamFiyat = 0;

                // Geçici listedeki her bir malzeme için döngü çalıştırılıyor
                foreach (Malzeme m in geciciTeklifMalzemeleri)
                {
                    // Malzemenin birim fiyatı ile kullanılan adedi çarpılıp genel toplama ekleniyor
                    toplamFiyat += (m.Fiyati * m.KullanilanAdet);
                }

                // Bulunan sonuç ekranda kullanıcıya gösteriliyor
                // "C2" (Currency) formatı, sayının sonuna otomatik olarak ₺ (veya sistemin para birimi) simgesini ekler ve küsuratı düzenler
                MessageBox.Show("Bu teklifin toplam tutarı: " + toplamFiyat.ToString("C2"), "Hesaplama Sonucu", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Hesaplanacak bir malzeme bulunamadı. Lütfen önce teklife malzeme ekleyin veya sağdaki tablodan bir teklif seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnRaporla_Click(object sender, EventArgs e)
        {
            // Sistemdeki toplam malzeme ve teklif sayıları alınıyor
            int toplamMalzemeCesidi = malzemeListesi.Count;
            int toplamTeklifSayisi = teklifListesi.Count;

            // Tüm tekliflerin toplam maliyetini tutacak değişken
            double genelToplamHacim = 0;

            // Sistemdeki tüm teklifler tek tek taranıyor
            foreach (Teklif teklif in teklifListesi)
            {
                // Her bir teklifin içindeki malzemeler taranıyor
                foreach (Malzeme m in teklif.KullanilanMalzemeler)
                {
                    // Malzemenin fiyatı ve adedi çarpılarak genel toplama ekleniyor
                    genelToplamHacim += (m.Fiyati * m.KullanilanAdet);
                }
            }

            // Gösterilecek rapor metni özel bir formatta birleştiriliyor
            // \n ifadesi metni bir alt satıra geçirmek için kullanılır
            string raporMetni = "========== SİSTEM GENEL RAPORU ==========\n\n";
            raporMetni += "Sistemdeki Kayıtlı Malzeme Çeşidi : " + toplamMalzemeCesidi + " adet\n";
            raporMetni += "Oluşturulan Toplam Teklif Sayısı  : " + toplamTeklifSayisi + " adet\n";
            raporMetni += "Tüm Tekliflerin Toplam Hacmi      : " + genelToplamHacim.ToString("C2") + "\n\n";
            raporMetni += "=========================================";

            // Hazırlanan rapor ekranda gösteriliyor
            MessageBox.Show(raporMetni, "Rapor Ekranı", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnTeklifAra_Click(object sender, EventArgs e)
        {
            // Arama kutusuna girilen metin alınıyor ve küçük harfe çevriliyor
            string arananKelime = txtTeklifAra.Text.ToLower();

            // Arama kutusunun boş olup olmadığı kontrol ediliyor
            if (string.IsNullOrWhiteSpace(arananKelime))
            {
                // Eğer kutu boşsa tüm teklifleri tekrar ekrana getir
                TeklifleriListele();
            }
            else
            {
                // Sadece aranan şarta uyan teklifleri tutmak için geçici bir liste oluşturuyoruz
                List<Teklif> filtrelenmisTeklifler = new List<Teklif>();

                // Döngü ile sistemdeki her bir teklif tek tek kontrol ediliyor
                foreach (Teklif t in teklifListesi)
                {
                    // Eğer teklifin numarası, firma adı veya proje adı aranan kelimeyi içeriyorsa geçici listeye ekle
                    if (t.TeklifNo.ToLower().Contains(arananKelime) ||
                        t.FirmaAdi.ToLower().Contains(arananKelime) ||
                        t.ProjeAdi.ToLower().Contains(arananKelime))
                    {
                        filtrelenmisTeklifler.Add(t);
                    }
                }

                // Ana tablonun veri kaynağı sıfırlanıp, sadece filtrelenmiş listeye bağlanıyor
                dgvTeklifler.DataSource = null;
                dgvTeklifler.DataSource = filtrelenmisTeklifler;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult cevap = MessageBox.Show("Programdan çıkmak istediğinize emin misiniz?", "Çıkış Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (cevap == DialogResult.No)
            {
                e.Cancel = true; // Kullanıcı 'Hayır' derse kapanmayı iptal et
            }
        }
    }
}