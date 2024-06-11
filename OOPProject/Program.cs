
using EvLib;
namespace Projec2
{
    internal class Program
    {
        #region Değişkenler
        static string menu_msg = "Lütfen işlem yapmak istediğiniz numarayı ya da ilgili kelimeleri giriniz " +
            "\n1:Satılık Ev\n2:Kiralık Ev\nCevabınız: ";
        static string secim_msg = "Hangi türde işlem yapmak istiyorsunuz?" +
            "\n1:Tüm Evleri Görüntüle\n2:Yeni Ev Girişi\nCevabınız: ";
        static string secim2_msg = "İşlemlere devam etmek istiyor musunu?\n1:Evet\n2:Hayır";
        static Boolean kontrol = true;
        static List<KiralikEv> kiralikEvList = new List<KiralikEv>();
        static List<SatilikEv> satilikEvList = new List<SatilikEv>();

        #endregion
        static void Main(string[] args)
        {
            do
            {
                Menu();
            } while (kontrol == true);
            KiralikEvKayit();
            SatilikEvKayit();
            Console.WriteLine("Hoşçakalın!..");
            Console.ReadLine();
        }
        static void Menu()
        {
            Console.Write(menu_msg);
            string secim = Console.ReadLine();
            if (secim == "1" || secim == "satılık ev")
            {
                Console.Write(secim_msg);
                string secim2 = Console.ReadLine();
                if (secim2 == "1" || secim2 == "tüm evleri görüntüle")
                {
                    Console.WriteLine("----------------------------------------------------------------------");
                    SatilikEvBilgileriYazdir();
                    Console.WriteLine("----------------------------------------------------------------------");
                }
                else if (secim2 == "2" || secim2 == "yeni ev girişi")
                {
                    SatilikEvGirisi();
                }
            }
            else if (secim == "2" || secim == "kiralık ev")
            {
                Console.Write(secim_msg);
                string secim2 = Console.ReadLine();
                if (secim2 == "1" || secim2 == "tüm evleri görüntüle")
                {
                    Console.WriteLine("----------------------------------------------------------------------");
                    KiralikEvBilgileriYazdir();
                    Console.WriteLine("----------------------------------------------------------------------");
                }
                else if (secim2 == "2" || secim2 == "yeni ev girişi")
                {
                    KiralikEvGirisi();
                }
            }

            Console.WriteLine(secim2_msg);
            string secim3 = Console.ReadLine().ToLower();
            if (secim3 == "hayir" || secim3 == "2")
            {
                kontrol = false;
            }

        }

        public static void SatilikEvGirisi()
        {
            SatilikEv satilikEv = new SatilikEv();
            satilikEv.oda_sayisi = InputAl<byte>("Evin Oda Sayısı:");
            satilikEv.kat_sayisi = InputAl<byte>("Evin Kat Sayısı:");
            satilikEv.semt = InputAl<string>("Evin Semti:");
            satilikEv.satis_fiyati = InputAl<double>("Satış Fiyatı:");

            satilikEvList.Add(satilikEv);
            
            foreach (var item in satilikEvList)
            {
                Console.WriteLine(item);
            }
        }
        public static void KiralikEvGirisi()
        {
            KiralikEv kiralikEv = new KiralikEv();
            kiralikEv.oda_sayisi = InputAl<byte>("Evin Oda Sayısı:");
            kiralikEv.kat_sayisi = InputAl<byte>("Evin Kat Sayısı:");
            kiralikEv.semt = InputAl<string>("Evin Semti:");
            kiralikEv.depozito = InputAl<double>("Depozito Ücreti:");
            kiralikEv.kira_fiyati = InputAl<double>("Kira Fiyatı:");

            kiralikEvList.Add(kiralikEv);
            //foreach (var item in kiralikEvList)
            //{
            //    Console.WriteLine(item);
            //}
        }
        public static void SatilikEvKayit()
        {
            string logsFolderPath = @"C:\Users\muham\source\repos\Log";
            string filePath = Path.Combine(logsFolderPath, "SatilikEv.txt");

            foreach (var satilikEv in satilikEvList)
            {
                File.AppendAllText(filePath, satilikEv.ToString() + Environment.NewLine);
            }
        }

        public static void KiralikEvKayit()
        {
            string logsFolderPath = @"C:\Users\muham\source\repos\Log";
            string filePath = Path.Combine(logsFolderPath, "KiralikEv.txt");

            foreach (var kiralikEv in kiralikEvList)
            {
                File.AppendAllText(filePath, kiralikEv.ToString() + Environment.NewLine);
            }
        }
        static void SatilikEvBilgileriYazdir()
        {
            string satilikEvDosyaYolu = @"C:\Users\muham\source\repos\Log\SatilikEv.txt";
            string satilikEvIcerik = File.ReadAllText(satilikEvDosyaYolu);
            Console.WriteLine("Satılık Evlerin Bilgileri:");
            Console.WriteLine("*******************");
            Console.WriteLine(satilikEvIcerik);
        }
        static void KiralikEvBilgileriYazdir()
        {
            string kiralikEvDosyaYolu = @"C:\Users\muham\source\repos\Log\KiralikEv.txt";
            string kiralikEvIcerik = File.ReadAllText(kiralikEvDosyaYolu);
            Console.WriteLine("Kiralık Evlerin Bilgileri:");
            Console.WriteLine("*******************");
            Console.WriteLine(kiralikEvIcerik);
        }
        static T InputAl<T>(string mesaj)
        {
            Console.WriteLine(mesaj);
            string input = Console.ReadLine();
            try
            {
                if (typeof(T) == typeof(string))
                {
                    return (T)(object)input;
                }
                else
                {
                    return (T)Convert.ChangeType(input, typeof(T));
                }
            }
            catch
            {
                Console.WriteLine("Geçersiz giriş. Tekrar deneyin.");
                return InputAl<T>(mesaj);
            }
        }
    }
}