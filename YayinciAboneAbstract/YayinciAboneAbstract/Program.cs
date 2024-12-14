using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YayinciAboneAbstract
{
    public interface IYayinci
    {
        void AboneEkle(IAbone abone);
        void AboneCikarma(IAbone abone);
        void AboneListele();
        void DegisiklikYap();
    }

    public interface IAbone
    {
        void BilgiAl(string mesaj);
    }

    public class Yayinci : IYayinci
    {
        private List<IAbone> aboneler = new List<IAbone>();
        private string mesaj;

        public void AboneEkle(IAbone abone)
        {
            aboneler.Add(abone);
        }

        public void AboneCikarma(IAbone abone)
        {
            aboneler.Remove(abone);
        }

        public void AboneListele()
        {
            foreach (var abone in aboneler)
            {
                Console.WriteLine("Abone Tipi: " + abone.GetType().Name);
            }
        }

        public void DegisiklikYap()
        {
            Console.WriteLine("Yayıncı bir değişiklik yaptı. Abonelere bildiriliyor...");
            mesaj = "Yeni bir güncelleme var!";
            Bildir();
        }

        private void Bildir()
        {
            foreach (var abone in aboneler)
            {
                abone.BilgiAl("Değişiklik: " + mesaj);
            }
        }
    }

    public class Abone : IAbone
    {
        private string isim;

        public Abone(string isim)
        {
            this.isim = isim;
        }

        public void BilgiAl(string mesaj)
        {
            Console.WriteLine(isim + " adlı abone mesajı aldı: " + mesaj);
        }
    }

    class Program
    {
        static void Main()
        {
            Yayinci yayinci = new Yayinci();

            Abone abone1 = new Abone("Ahmet");
            Abone abone2 = new Abone("Mehmet");
            Abone abone3 = new Abone("Ayşe");

            yayinci.AboneEkle(abone1);
            yayinci.AboneEkle(abone2);
            yayinci.AboneEkle(abone3);

            Console.WriteLine("Aboneler:");
            yayinci.AboneListele();

            yayinci.DegisiklikYap();

            yayinci.AboneCikarma(abone2);

            Console.WriteLine("\nAbone çıkarıldı, güncelleme yapılıyor...");
            yayinci.DegisiklikYap();

            Console.ReadKey();
        }
    }
}
