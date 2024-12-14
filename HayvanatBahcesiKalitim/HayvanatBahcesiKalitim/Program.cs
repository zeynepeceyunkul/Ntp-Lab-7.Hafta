using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HayvanatBahcesiKalitim
{
    public class Hayvan
    {
        public string ad { get; set; }
        public string tur { get; set; }
        public int yas { get; set; }

        public virtual string SesCikar()
        {
            return "Bir hayvan ses çıkarıyor.";
        }

    }
    public class Memeli : Hayvan
    {
        public string tuyRengi { get; set; }

        public override string SesCikar()
        {
            return "Bir memeli ses çıkarıyor: miyav, hav hav";

        }
    }

    public class Kus : Hayvan
    {
        public int kanatGenisligi { get; set; }

        public override string SesCikar()
        {
            return "Bir kuş ses çıkarıyor: gak gak, cik cik";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bir hayvan türü seçiniz: (1: Memeli 2: Kus)");
            int secim = int.Parse(Console.ReadLine());

            Hayvan hayvan = null;

            if (secim == 1)
            {
                hayvan = new Memeli();
                Console.Write("Ad: ");
                hayvan.ad = Console.ReadLine();
                Console.Write("Tür: ");
                hayvan.tur = Console.ReadLine();
                Console.Write("Yaş: ");
                hayvan.yas = int.Parse(Console.ReadLine());
                Console.Write("Tüy Rengi: ");
                ((Memeli)hayvan).tuyRengi = Console.ReadLine();
            }

            if (secim == 2)
            {
                hayvan = new Kus();
                Console.Write("Ad: ");
                hayvan.ad = Console.ReadLine();
                Console.Write("Tür: ");
                hayvan.tur = Console.ReadLine();
                Console.Write("Yaş: ");
                hayvan.yas = int.Parse(Console.ReadLine());
                Console.Write("Kanat Genişliği: ");
                ((Kus)hayvan).kanatGenisligi = int.Parse(Console.ReadLine());
            }
            Console.ReadKey();
        }
    }
}
