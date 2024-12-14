using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankaAbstract
{
    public abstract class Hesap
    {
        public string HesapNo { get; set; }
        public decimal Bakiye { get; set; }

        public abstract void ParaYatir(decimal miktar);
        public abstract void ParaCek(decimal miktar);
    }

    public interface IBankaHesabi
    {
        DateTime HesapAcilisTarihi { get; set; }
        void HesapOzeti();
    }

    public class BirikimHesabi : Hesap, IBankaHesabi
    {
        public decimal FaizOrani { get; set; }
        public DateTime HesapAcilisTarihi { get; set; }

        public BirikimHesabi(string hesapNo, decimal faizOrani)
        {
            HesapNo = hesapNo;
            FaizOrani = faizOrani;
            Bakiye = 0;
            HesapAcilisTarihi = DateTime.Now;
        }

        public override void ParaYatir(decimal miktar)
        {
            Bakiye = Bakiye + miktar;
            decimal faiz = Bakiye * FaizOrani / 100;
            Bakiye = Bakiye + faiz;
        }

        public override void ParaCek(decimal miktar)
        {
            if (Bakiye >= miktar)
            {
                Bakiye = Bakiye - miktar;
            }
            else
            {
                Console.WriteLine("Yetersiz bakiye.");
            }
        }

        public void HesapOzeti()
        {
            Console.WriteLine("Hesap No: " + HesapNo);
            Console.WriteLine("Bakiye: " + Bakiye);
            Console.WriteLine("Faiz Oranı: " + FaizOrani + "%");
            Console.WriteLine("Hesap Açılış Tarihi: " + HesapAcilisTarihi.ToShortDateString() + "\n");
        }
    }

    public class VadesizHesap : Hesap, IBankaHesabi
    {
        public decimal IslemUcreti { get; set; }
        public DateTime HesapAcilisTarihi { get; set; }

        public VadesizHesap(string hesapNo, decimal islemUcreti)
        {
            HesapNo = hesapNo;
            IslemUcreti = islemUcreti;
            Bakiye = 0;
            HesapAcilisTarihi = DateTime.Now;
        }

        public override void ParaYatir(decimal miktar)
        {
            Bakiye = Bakiye + miktar;
        }

        public override void ParaCek(decimal miktar)
        {
            if (Bakiye >= miktar + IslemUcreti)
            {
                Bakiye = Bakiye - (miktar + IslemUcreti);
            }
            else
            {
                Console.WriteLine("Yetersiz bakiye.");
            }
        }

        public void HesapOzeti()
        {
            Console.WriteLine("Hesap No: " + HesapNo);
            Console.WriteLine("Bakiye: " + Bakiye);
            Console.WriteLine("İşlem Ücreti: " + IslemUcreti);
            Console.WriteLine("Hesap Açılış Tarihi: " + HesapAcilisTarihi.ToShortDateString() + "\n");
        }
    }

    class Program
    {
        static void Main()
        {
            Console.WriteLine("Birikim Hesabı için hesap numarasını ve faiz oranını giriniz:");
            string hesapNo1 = Console.ReadLine();
            decimal faizOrani = Convert.ToDecimal(Console.ReadLine());
            BirikimHesabi birikimHesabi = new BirikimHesabi(hesapNo1, faizOrani);

            Console.WriteLine("\nVadesiz Hesap için hesap numarasını ve işlem ücretini giriniz:");
            string hesapNo2 = Console.ReadLine();
            decimal islemUcreti = Convert.ToDecimal(Console.ReadLine());
            VadesizHesap vadesizHesap = new VadesizHesap(hesapNo2, islemUcreti);

            birikimHesabi.ParaYatir(1000);
            birikimHesabi.ParaCek(200);
            birikimHesabi.HesapOzeti();

            vadesizHesap.ParaYatir(500);
            vadesizHesap.ParaCek(100);
            vadesizHesap.HesapOzeti();

            Console.ReadLine();
        }
    }
}