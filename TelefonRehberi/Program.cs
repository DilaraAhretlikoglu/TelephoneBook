namespace TelefonRehberi;

class Program
{
    static void Main(string[] args)
    {
        Rehber telefonRehberi = new Rehber();
        while (true)
        {
            Console.WriteLine("Lütfen yapmak istediğiniz işlemi seçiniz :)");
        Console.WriteLine("*******************************************");
        Console.WriteLine("(1) Yeni Numara Kaydetmek");
        Console.WriteLine("(2) Varolan Numarayı Silmek");
        Console.WriteLine("(3) Varolan Numarayı Güncelleme");
        Console.WriteLine("(4) Rehberi Listelemek");
        Console.WriteLine("(5) Rehberde Arama Yapmak");

        // Kullanıcıdan seçim al
        int secim = Convert.ToInt32(Console.ReadLine());

        switch (secim)
        {
            case 1:
                Console.Write("Lütfen isim giriniz: ");
                string ad = Console.ReadLine();

                Console.Write("Lütfen soyisim giriniz: ");
                string soyad = Console.ReadLine();

                Console.Write("Lütfen telefon numarası giriniz: ");
                string telefonNumarasi = Console.ReadLine();

                telefonRehberi.KisiEkle(ad, soyad, telefonNumarasi);
                break;

            case 2:
                Console.Write("Lütfen numarasını silmek istediğiniz kişinin adını ya da soyadını giriniz: ");
                string aramaKriteri = Console.ReadLine();

                telefonRehberi.KisiSil(aramaKriteri);
                break;

            case 3:
                Console.Write("Lütfen numarasını güncellemek istediğiniz kişinin adını ya da soyadını giriniz: ");
                aramaKriteri = Console.ReadLine();

                telefonRehberi.KisiGuncelle(aramaKriteri);
                break;

            case 4:
                telefonRehberi.RehberiAZSirala(); // A-Z sırasıyla listeleme yapmak için
                // telefonRehberi.RehberiZASirala(); // Z-A sırasıyla listeleme yapmak için
                break;

            case 5:
                Console.WriteLine("Arama yapmak istediğiniz tipi seçiniz:");
                Console.WriteLine("**********************************************");
                Console.WriteLine("İsim veya soyisime göre arama yapmak için: (1)");
                Console.WriteLine("Telefon numarasına göre arama yapmak için: (2)");

                int aramaSecimi = Convert.ToInt32(Console.ReadLine());

                if (aramaSecimi == 1)
                {
                    Console.Write("Arama yapmak istediğiniz ismi ya da soyismi giriniz: ");
                    aramaKriteri = Console.ReadLine();
                    List<Kisi> aramaSonuclari = telefonRehberi.IsimSoyisimeGoreAra(aramaKriteri);
                    // Sonuçları gösterme işlemi
                }
                else if (aramaSecimi == 2)
                {
                    Console.Write("Arama yapmak istediğiniz telefon numarasını giriniz: ");
                    aramaKriteri = Console.ReadLine();
                    List<Kisi> aramaSonuclari = telefonRehberi.TelefonNumarasinaGoreAra(aramaKriteri);
                    // Sonuçları gösterme işlemi
                }
                else
                {
                    Console.WriteLine("Geçersiz seçim.");
                }
                break;

            default:
                Console.WriteLine("Geçersiz seçim.");
                break;
        }
       
        }

        
    }
}

