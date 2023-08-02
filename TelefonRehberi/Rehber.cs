public class Rehber
{
    private List<Kisi> kisiler;
    public Rehber()
    {
        kisiler = new List<Kisi>
        {
            new Kisi { Ad = "Ayse", Soyad = "Yılmaz", TelefonNumarasi = "1234567890" },
            new Kisi { Ad = "Burak", Soyad = "Kara", TelefonNumarasi = "9876543210" },
            new Kisi { Ad = "Cenk", Soyad = "Gun", TelefonNumarasi = "9876543210" },
            new Kisi { Ad = "Deniz", Soyad = "Tuncer", TelefonNumarasi = "9876543210" },
            new Kisi { Ad = "Elif", Soyad = "Ertuğ", TelefonNumarasi = "9876543210" },

        };
    }
    public void KisiEkle(string ad, string soyad, string telefonNumarasi)
    {
        Kisi yeniKisi = new Kisi
        {
            Ad = ad,
            Soyad = soyad,
            TelefonNumarasi = telefonNumarasi
        };
        kisiler.Add(yeniKisi);
        Console.WriteLine("Kişi başarıyla rehbere eklendi.");
    }

    public void KisiSil(string aramaKriteri)
    {
        List<Kisi> bulunanKisiler = kisiler
        .Where(k => k.Ad.Contains(aramaKriteri, StringComparison.OrdinalIgnoreCase) || k.Soyad.Contains(aramaKriteri, StringComparison.OrdinalIgnoreCase))
        .ToList();

        if (bulunanKisiler.Count == 0)
        {
            Console.WriteLine("Aradığınız kritere uygun veri rehberde bulunamadı. Lütfen bir seçim yapınız.");
            Console.WriteLine("* Silmeyi sonlandırmak için : (1)");
            Console.WriteLine("* Yeniden denemek için      : (2)");

            int secim = Convert.ToInt32(Console.ReadLine());
            if (secim == 1)
            {
                Console.WriteLine("Silme işlemi iptal edildi.");
            }
            else if (secim == 2)
            {
                KisiSil(aramaKriteri);
            }
            else
            {
                Console.WriteLine("Geçersiz seçim.");
            }
        }
        else
        {
            Kisi silinecekKisi = bulunanKisiler.First();
            Console.WriteLine($"{silinecekKisi.Ad} {silinecekKisi.Soyad} isimli kişi rehberden silinmek üzere, onaylıyor musunuz? (y/n)");

            string cevap = Console.ReadLine();
            if (cevap.Equals("y", StringComparison.OrdinalIgnoreCase))
            {
                kisiler.Remove(silinecekKisi);
                Console.WriteLine("Kişi başarıyla rehberden silindi.");
            }
            else
            {
                Console.WriteLine("Silme işlemi iptal edildi.");
            }
        }
    }
    public void KisiGuncelle(string aramaKriteri)
    {
        List<Kisi> bulunanKisiler = kisiler
            .Where(k => k.Ad.Contains(aramaKriteri, StringComparison.OrdinalIgnoreCase) || k.Soyad.Contains(aramaKriteri, StringComparison.OrdinalIgnoreCase))
            .ToList();

        if (bulunanKisiler.Count == 0)
        {
            Console.WriteLine("Aradığınız kritere uygun veri rehberde bulunamadı. Lütfen bir seçim yapınız.");
            Console.WriteLine("* Güncellemeyi sonlandırmak için : (1)");
            Console.WriteLine("* Yeniden denemek için           : (2)");

            int secim = Convert.ToInt32(Console.ReadLine());
            if (secim == 1)
            {
                Console.WriteLine("Güncelleme işlemi iptal edildi.");
            }
            else if (secim == 2)
            {
                KisiGuncelle(aramaKriteri);
            }
            else
            {
                Console.WriteLine("Geçersiz seçim.");
            }
        }
        else
        {
            Kisi guncellenecekKisi = bulunanKisiler.First();
            Console.WriteLine($"{guncellenecekKisi.Ad} {guncellenecekKisi.Soyad} isimli kişinin yeni bilgilerini giriniz:");

            Console.Write("Yeni isim giriniz: ");
            guncellenecekKisi.Ad = Console.ReadLine();

            Console.Write("Yeni soyisim giriniz: ");
            guncellenecekKisi.Soyad = Console.ReadLine();

            Console.Write("Yeni telefon numarası giriniz: ");
            guncellenecekKisi.TelefonNumarasi = Console.ReadLine();

            Console.WriteLine("Kişi başarıyla güncellendi.");
        }
    }
    public List<Kisi> IsimSoyisimeGoreAra(string aramaKriteri)
    {
        List<Kisi> bulunanKisiler = kisiler
            .Where(k => k.Ad.Contains(aramaKriteri, StringComparison.OrdinalIgnoreCase) || k.Soyad.Contains(aramaKriteri, StringComparison.OrdinalIgnoreCase))
            .ToList();

        if (bulunanKisiler.Count == 0)
        {
            Console.WriteLine("Aradığınız kritere uygun veri rehberde bulunamadı.");
        }
        else
        {
            Console.WriteLine("Arama Sonuçlarınız:");
            Console.WriteLine("**********************************************");
            foreach (var kisi in bulunanKisiler)
            {
                Console.WriteLine($"isim: {kisi.Ad} Soyisim: {kisi.Soyad} Telefon Numarası: {kisi.TelefonNumarasi}");
            }
        }

        return bulunanKisiler;
    }
    public List<Kisi> TelefonNumarasinaGoreAra(string aramaKriteri)
    {
        List<Kisi> bulunanKisiler = kisiler
            .Where(k => k.TelefonNumarasi.Contains(aramaKriteri, StringComparison.OrdinalIgnoreCase))
            .ToList();

        if (bulunanKisiler.Count == 0)
        {
            Console.WriteLine("Aradığınız telefon numarasına uygun veri rehberde bulunamadı.");
        }
        else
        {
            Console.WriteLine("Arama Sonuçlarınız:");
            Console.WriteLine("**********************************************");
            foreach (var kisi in bulunanKisiler)
            {
                Console.WriteLine($"isim: {kisi.Ad} Soyisim: {kisi.Soyad} Telefon Numarası: {kisi.TelefonNumarasi}");
            }
        }

        return bulunanKisiler;
    }
    public void RehberiAZSirala()
    {
        List<Kisi> siraliKisiler = kisiler.OrderBy(k => k.Ad).ThenBy(k => k.Soyad).ToList();

        if (siraliKisiler.Count == 0)
        {
            Console.WriteLine("Rehberde kayıtlı kişi bulunmamaktadır.");
        }
        else
        {
            Console.WriteLine("Telefon Rehberi");
            Console.WriteLine("**********************************************");
            foreach (var kisi in siraliKisiler)
            {
                Console.WriteLine($"isim: {kisi.Ad} Soyisim: {kisi.Soyad} Telefon Numarası: {kisi.TelefonNumarasi}");
            }
        }
    }
    public void RehberiListele()
    {
        if (kisiler.Count == 0)
        {
            Console.WriteLine("Rehberde kayıtlı kişi bulunmamaktadır.");
        }
        else
        {
            Console.WriteLine("Telefon Rehberi");
            Console.WriteLine("**********************************************");
            foreach (var kisi in kisiler)
            {
                Console.WriteLine($"isim: {kisi.Ad} Soyisim: {kisi.Soyad} Telefon Numarası: {kisi.TelefonNumarasi}");
            }
        }
    }
}