using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalisanKalitim
{
    public class Calisan
    {
        public string ad { get; set; }
        public string soyad { get; set; }
        public int maas { get; set; }
        public string pozisyon { get; set; }

       
        public virtual void BilgileriYazdir()
        {
            Console.WriteLine("Ad: {0}, Soyad: {1}, Maasş: {2}, Pozisyon: {3}",ad,soyad,maas,pozisyon);
        }
    }

    public class Yazilimci : Calisan
    {
        public string yazilimDili { get; set; }

        public override void BilgileriYazdir()
        {
            base.BilgileriYazdir();
            Console.WriteLine("Yazılım Dili Bilgisi: " + yazilimDili);
        }

    }

    public class Muhasebeci : Calisan
    {
        public string muhasebeYazilim { get; set; }

        public override void BilgileriYazdir()
        {
            base.BilgileriYazdir();
            Console.WriteLine("Muhasebe Yazılım Bilgisi: " + muhasebeYazilim);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Çalışan türünü seçiniz. (1 : Yazilimci, 2: Muhasebeci)");
            int secim = int.Parse(Console.ReadLine());

            Calisan calisan = null;

            if (secim == 1)
            {
                calisan = new Yazilimci();
                Console.Write("Ad: ");
                calisan.ad = Console.ReadLine();
                Console.Write("Soyad: ");
                calisan.soyad = Console.ReadLine();
                Console.Write("Maaş: ");
                calisan.maas = int.Parse(Console.ReadLine());
                Console.Write("Pozisyon: ");
                calisan.pozisyon = Console.ReadLine();
                Console.Write("Yazılım Dili Bilgisi: ");
                ((Yazilimci)calisan).yazilimDili = Console.ReadLine();

            }

            if (secim == 2)
            {
                calisan = new Muhasebeci();
                Console.Write("Ad: ");
                calisan.ad = Console.ReadLine();
                Console.Write("Soyad: ");
                calisan.soyad = Console.ReadLine();
                Console.Write("Maaş: ");
                calisan.maas = int.Parse(Console.ReadLine());
                Console.Write("Pozisyon: ");
                calisan.pozisyon = Console.ReadLine();
                Console.Write("Muhasebe Yazılım Bilgisi: ");
                ((Muhasebeci)calisan).muhasebeYazilim = Console.ReadLine();
            }
            Console.ReadKey();
        }
    }
}
