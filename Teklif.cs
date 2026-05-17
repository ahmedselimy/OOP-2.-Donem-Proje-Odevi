/****************************************************************************
**					SAKARYA ÜNİVERSİTESİ
**				BİLGİSAYAR VE BİLİŞİM BİLİMLERİ FAKÜLTESİ
**				    BİLGİSAYAR MÜHENDİSLİĞİ BÖLÜMÜ
**				   NESNEYE DAYALI PROGRAMLAMA DERSİ
**					2026-2027 BAHAR DÖNEMİ
**
**				ÖDEV NUMARASI..........: Proje Ödevi
**				ÖĞRENCİ ADI............: Ahmed Selim Yılmaz
**				ÖĞRENCİ NUMARASI.......: B251210005
**              DERSİN ALINDIĞI GRUP...: B Grubu
****************************************************************************/

namespace OOP_2._Dönem_Proje_Ödevi
{
    public class Teklif
    {
        public string? TeklifNo { get; set; }
        public string? FirmaAdi { get; set; }
        public string? ProjeAdi { get; set; }

        // Teklifin içinde birden fazla malzeme olacağı için bunu bir "Liste" olarak tanımlıyoruz.
        // Bu malzemeler malzeme dosyasındaki malzemelerden olmak zorunda.
        public List<Malzeme> KullanilanMalzemeler { get; set; }

        // Sınıf ilk oluştuğunda listenin de hata vermeden hazır olması için yapıcı metot (constructor) ekliyoruz.
        public Teklif()
        {
            KullanilanMalzemeler = [];
        }
    }
}