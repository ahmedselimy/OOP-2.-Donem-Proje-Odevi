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

namespace OOP_2._Dönem_Proje_Ödevi
{
    public class Malzeme
    {
        public string MalzemeAdi { get; set; }
        public string MalzemeCinsi { get; set; }
        public string Birimi { get; set; }
        public double Fiyati { get; set; }
        public int StokAdedi { get; set; }
        public string TeminEdilenFirma { get; set; }
        public int KullanilanAdet { get; set; }
    }
}