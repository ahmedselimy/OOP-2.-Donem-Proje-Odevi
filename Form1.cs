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
            // Tablonun veri kaynağını önce sıfırlıyoruz
            dgvMalzemeler.DataSource = null;

            // Güncel listeyi tabloya aktarıyoruz
            dgvMalzemeler.DataSource = malzemeListesi;
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
            // Metin kutularının boş olup olmadığı kontrol ediliyor
            if (string.IsNullOrWhiteSpace(txtMalzemeAdi.Text) || string.IsNullOrWhiteSpace(txtMalzemeFiyati.Text))
            {
                MessageBox.Show("Lütfen Malzeme Adı ve Fiyatı alanlarını doldurun!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Yeni bir malzeme nesnesi oluşturuluyor ve text kutularındaki veriler aktarılıyor
            Malzeme yeniMalzeme = new Malzeme();
            yeniMalzeme.MalzemeAdi = txtMalzemeAdi.Text;
            yeniMalzeme.MalzemeCinsi = txtMalzemeCinsi.Text;
            yeniMalzeme.Birimi = txtMalzemeBirimi.Text;
            yeniMalzeme.Fiyati = Convert.ToDouble(txtMalzemeFiyati.Text);
            yeniMalzeme.StokAdedi = Convert.ToInt32(txtMalzemeStogu.Text);
            yeniMalzeme.TeminEdilenFirma = txtMalzemeFirmasi.Text;

            // Oluşturulan nesne listeye ekleniyor
            malzemeListesi.Add(yeniMalzeme);

            MalzemeleriDosyayaYaz();

            // Tablonun güncellenmesi için listeleme fonksiyonu çağrılıyor
            MalzemeleriListele();

            // Yeni eklendi: Ekleme işlemi bittikten sonra metin kutularını temizliyoruz
            MetinKutulariniTemizle();

            ComboboxaMalzemeleriDoldur();

            MessageBox.Show("Malzeme başarıyla eklendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            // Güncellenecek bir satırın seçili olup olmadığı kontrol ediliyor
            if (dgvMalzemeler.CurrentRow != null)
            {
                // Kutulardaki yeni bilgilerin boş olup olmadığı kontrol ediliyor
                if (string.IsNullOrWhiteSpace(txtMalzemeAdi.Text) || string.IsNullOrWhiteSpace(txtMalzemeFiyati.Text))
                {
                    MessageBox.Show("Lütfen Malzeme Adı ve Fiyatı alanlarını boş bırakmayın!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Seçilen malzeme arka plandaki listeden bulunuyor
                Malzeme GuncellenecekMalzeme = (Malzeme)dgvMalzemeler.CurrentRow.DataBoundItem;

                // Kutulardaki yeni veriler nesnenin üzerine yazılıyor
                GuncellenecekMalzeme.MalzemeAdi = txtMalzemeAdi.Text;
                GuncellenecekMalzeme.MalzemeCinsi = txtMalzemeCinsi.Text;
                GuncellenecekMalzeme.Birimi = txtMalzemeBirimi.Text;
                GuncellenecekMalzeme.Fiyati = Convert.ToDouble(txtMalzemeFiyati.Text);
                GuncellenecekMalzeme.StokAdedi = Convert.ToInt32(txtMalzemeStogu.Text);
                GuncellenecekMalzeme.TeminEdilenFirma = txtMalzemeFirmasi.Text;

                MalzemeleriDosyayaYaz();

                // Tablonun yeni değerleri göstermesi için vitrin tazeleniyor
                MalzemeleriListele();

                ComboboxaMalzemeleriDoldur();

                MessageBox.Show("Malzeme başarıyla güncellendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Lütfen güncellemek için tablodan bir malzeme seçiniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            // 1. Önce ComboBox'tan seçim yapılıp yapılmadığı kontrol ediliyor
            if (cmbMalzemeler.SelectedIndex != -1)
            {
                // 2. Adet kutusunun boş olup olmadığı kontrol ediliyor
                if (string.IsNullOrWhiteSpace(txtKullanilanAdet.Text))
                {
                    MessageBox.Show("Lütfen kullanılacak adeti giriniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Ana listeden seçilen orijinal malzemeyi buluyoruz
                int secilenIndeks = cmbMalzemeler.SelectedIndex;
                Malzeme anaMalzeme = malzemeListesi[secilenIndeks];

                // DİKKAT: Orijinal malzemenin verileri bozulmasın diye teklife özel YENİ bir kopya oluşturuyoruz
                Malzeme teklifeEklenecek = new Malzeme();
                teklifeEklenecek.MalzemeAdi = anaMalzeme.MalzemeAdi;
                teklifeEklenecek.MalzemeCinsi = anaMalzeme.MalzemeCinsi;
                teklifeEklenecek.Birimi = anaMalzeme.Birimi;
                teklifeEklenecek.Fiyati = anaMalzeme.Fiyati;
                teklifeEklenecek.StokAdedi = anaMalzeme.StokAdedi;
                teklifeEklenecek.TeminEdilenFirma = anaMalzeme.TeminEdilenFirma;

                // Miktarı textbox'tan alıp sadece bu kopyaya işliyoruz
                teklifeEklenecek.KullanilanAdet = Convert.ToInt32(txtKullanilanAdet.Text);

                // Kopyaladığımız ve adedini belirlediğimiz bu malzemeyi geçici teklif listesine ekliyoruz
                geciciTeklifMalzemeleri.Add(teklifeEklenecek);

                // Küçük tabloyu güncelliyoruz
                GeciciMalzemeleriListele();

                // Yeni malzeme eklemeye hazır olmak için adet kutusunu temizliyoruz
                txtKullanilanAdet.Clear();
            }
            else
            {
                MessageBox.Show("Lütfen önce açılır listeden bir malzeme seçiniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnTeklifEkle_Click(object sender, EventArgs e)
        {
            // Temel bilgilerin boş olup olmadığı kontrol ediliyor
            if (string.IsNullOrWhiteSpace(txtTeklifNo.Text) || string.IsNullOrWhiteSpace(txtFirmaAdi.Text) || string.IsNullOrWhiteSpace(txtProjeAdi.Text))
            {
                MessageBox.Show("Lütfen Teklif No, Firma Adı ve Proje Adı alanlarını doldurunuz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Teklife hiç malzeme eklenip eklenmediği kontrol ediliyor (En az 1 malzeme olmalı)
            if (geciciTeklifMalzemeleri.Count == 0)
            {
                MessageBox.Show("Bir teklif oluşturabilmek için sol alttaki kısımdan en az bir malzeme eklemelisiniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Yeni bir Teklif nesnesi oluşturuluyor ve kutulardaki veriler aktarılıyor
            Teklif yeniTeklif = new Teklif();
            yeniTeklif.TeklifNo = txtTeklifNo.Text;
            yeniTeklif.FirmaAdi = txtFirmaAdi.Text;
            yeniTeklif.ProjeAdi = txtProjeAdi.Text;

            // ÖNEMLİ REFERANS KOPYALAMASI: Geçici listenin (.ToList() ile) tam bir kopyasını alıp teklife ekliyoruz.
            // Eğer bunu yapmazsak, bir sonraki teklif için geçici listeyi temizlediğimizde bu teklifin içi de boşalır.
            yeniTeklif.KullanilanMalzemeler = System.Linq.Enumerable.ToList(geciciTeklifMalzemeleri);

            // Oluşturulan paket ana teklif listesine ekleniyor
            teklifListesi.Add(yeniTeklif);

            TeklifleriDosyayaYaz();

            // Sağdaki büyük teklif tablosu güncelleniyor
            TeklifleriListele();

            // TEMİZLİK: Yeni bir teklif yazmaya hazır olmak için ekran ve geçici liste sıfırlanıyor
            geciciTeklifMalzemeleri.Clear();
            GeciciMalzemeleriListele(); // Sol alttaki küçük tabloyu boşaltır

            txtTeklifNo.Clear();
            txtFirmaAdi.Clear();
            txtProjeAdi.Clear();

            MessageBox.Show("Teklif başarıyla oluşturuldu ve sisteme kaydedildi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dgvTeklifler_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ana teklifler tablosundan geçerli bir satıra tıklandığı kontrol ediliyor
            if (dgvTeklifler.CurrentRow != null)
            {
                // Seçilen satırdaki teklif paketi arka plandan çekiliyor
                Teklif secilenTeklif = (Teklif)dgvTeklifler.CurrentRow.DataBoundItem;

                // Teklifin ana bilgileri metin kutularına geri dolduruluyor
                txtTeklifNo.Text = secilenTeklif.TeklifNo;
                txtFirmaAdi.Text = secilenTeklif.FirmaAdi;
                txtProjeAdi.Text = secilenTeklif.ProjeAdi;

                // En kritik nokta: Seçilen bu teklifin içindeki özel malzeme listesi 
                // sol alttaki küçük tabloya vitrin olarak bağlanıyor
                dgvTekliftekiMalzemeler.DataSource = null;
                dgvTekliftekiMalzemeler.DataSource = secilenTeklif.KullanilanMalzemeler;
            }
        }
    }
}