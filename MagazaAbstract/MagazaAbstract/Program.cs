using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagazaAbstract
{

    public abstract class Urun
    {
        public string Ad { get; set; }
        public double Fiyat { get; set; }

        public abstract double HesaplaOdeme();
        public abstract void BilgiYazdir();
    }

    public class Kitap : Urun
    {
        public Kitap(string ad, double fiyat)
        {
            Ad = ad;
            Fiyat = fiyat;
        }

        public override double HesaplaOdeme()
        {
            double vergi = Fiyat * 0.10;
            return Fiyat + vergi; 
        }

        public override void BilgiYazdir()
        {
            Console.WriteLine("Kitap Adı: " + Ad + ", Fiyat: " + Fiyat + ", Ödenecek Tutar: " + HesaplaOdeme());
        }
    }

    public class Elektronik : Urun
    {
        public Elektronik(string ad, double fiyat)
        {
            Ad = ad;
            Fiyat = fiyat;
        }

        public override double HesaplaOdeme()
        {
            double vergi = Fiyat * 0.25;
            return Fiyat + vergi; 
        }

        public override void BilgiYazdir()
        {
            Console.WriteLine("Elektronik Ürün: " + Ad + ", Fiyat: " + Fiyat + ", Ödenecek Tutar: " + HesaplaOdeme());
        }
    }

    class Program
    {
        static void Main()
        {
            List<Urun> urunler = new List<Urun>();

            Console.WriteLine("Ürün Bilgilerini Girin:");

            Console.Write("Kitap Adı: ");
            string kitapAdi = Console.ReadLine();
            Console.Write("Kitap Fiyatı: ");
            double kitapFiyati = Convert.ToDouble(Console.ReadLine());
            urunler.Add(new Kitap(kitapAdi, kitapFiyati));

            Console.Write("Elektronik Ürün Adı: ");
            string elektronikAdi = Console.ReadLine();
            Console.Write("Elektronik Ürün Fiyatı: ");
            double elektronikFiyati = Convert.ToDouble(Console.ReadLine());
            urunler.Add(new Elektronik(elektronikAdi, elektronikFiyati));

            Console.WriteLine("\nÜrün Bilgileri ve Ödenecek Tutarlar:");
            foreach (var urun in urunler)
            {
                urun.BilgiYazdir();
            }
            Console.ReadKey();
        }
    }
}
