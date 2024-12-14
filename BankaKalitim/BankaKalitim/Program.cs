using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankaKalitim
{
    class Hesap
    {
        public string HesapNumarasi { get; set; }
        public string HesapSahibi { get; set; }
        public decimal Bakiye { get; set; }

        public virtual void ParaYatir(decimal miktar)
        {
            Bakiye += miktar;
            Console.WriteLine($"{miktar} TL yatırıldı. Güncel bakiye: {Bakiye} TL.");
        }

        public virtual void ParaCek(decimal miktar)
        {
            if (miktar > Bakiye)
            {
                Console.WriteLine("Yetersiz bakiye.");
            }
            else
            {
                Bakiye -= miktar;
                Console.WriteLine($"{miktar} TL çekildi. Güncel bakiye: {Bakiye} TL.");
            }
        }

        public virtual void BilgiYazdir()
        {
            Console.WriteLine($"Hesap Numarası: {HesapNumarasi}\nHesap Sahibi: {HesapSahibi}\nBakiye: {Bakiye} TL");
        }
    }

    // Vadesiz Hesap sınıfı
    class VadesizHesap : Hesap
    {
        public decimal EkHesapLimiti { get; set; }

        public override void ParaCek(decimal miktar)
        {
            if (miktar > Bakiye + EkHesapLimiti)
            {
                Console.WriteLine("Yetersiz bakiye ve ek hesap limiti.");
            }
            else
            {
                Bakiye -= miktar;
                Console.WriteLine($"{miktar} TL çekildi. Güncel bakiye: {Bakiye} TL.");
            }
        }

        public override void BilgiYazdir()
        {
            base.BilgiYazdir();
            Console.WriteLine($"Ek Hesap Limiti: {EkHesapLimiti} TL");
        }
    }

    // Vadeli Hesap sınıfı
    class VadeliHesap : Hesap
    {
        public int VadeSuresi { get; set; } // Vade süresi gün cinsinden
        public decimal FaizOrani { get; set; }

        public override void ParaCek(decimal miktar)
        {
            if (VadeSuresi > 0)
            {
                Console.WriteLine("Vade dolmadan para çekemezsiniz.");
            }
            else
            {
                base.ParaCek(miktar);
            }
        }

        public override void BilgiYazdir()
        {
            base.BilgiYazdir();
            Console.WriteLine($"Vade Süresi: {VadeSuresi} gün\nFaiz Oranı: %{FaizOrani}");
        }
    }

    // Program sınıfı
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hesap türünü seçiniz: 1 - Vadesiz Hesap, 2 - Vadeli Hesap");
            int secim = int.Parse(Console.ReadLine());

            if (secim == 1)
            {
                VadesizHesap vadesizHesap = new VadesizHesap();

                Console.Write("Hesap Numarası: ");
                vadesizHesap.HesapNumarasi = Console.ReadLine();
                Console.Write("Hesap Sahibi: ");
                vadesizHesap.HesapSahibi = Console.ReadLine();
                Console.Write("Bakiye: ");
                vadesizHesap.Bakiye = decimal.Parse(Console.ReadLine());
                Console.Write("Ek Hesap Limiti: ");
                vadesizHesap.EkHesapLimiti = decimal.Parse(Console.ReadLine());

                vadesizHesap.BilgiYazdir();
                vadesizHesap.ParaYatir(200);
                vadesizHesap.ParaCek(1500);
            }
            else if (secim == 2)
            {
                VadeliHesap vadeliHesap = new VadeliHesap();

                Console.Write("Hesap Numarası: ");
                vadeliHesap.HesapNumarasi = Console.ReadLine();
                Console.Write("Hesap Sahibi: ");
                vadeliHesap.HesapSahibi = Console.ReadLine();
                Console.Write("Bakiye: ");
                vadeliHesap.Bakiye = decimal.Parse(Console.ReadLine());
                Console.Write("Vade Süresi (gün): ");
                vadeliHesap.VadeSuresi = int.Parse(Console.ReadLine());
                Console.Write("Faiz Oranı: ");
                vadeliHesap.FaizOrani = decimal.Parse(Console.ReadLine());

                vadeliHesap.BilgiYazdir();
                vadeliHesap.ParaYatir(500);
                vadeliHesap.ParaCek(2000);
            }
            else
            {
                Console.WriteLine("Geçersiz seçim.");
            }
            Console.ReadKey();
        }
    }

}
