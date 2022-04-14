using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_01
{
    class Program
    {
        static void Main(string[] args)
        {
            //ToList metodu ile Bölümleri Listele
            void BolumleriListele()
            {
              
                HastaneSabahEntities hastane = new HastaneSabahEntities();
                var bolumler = hastane.Bolumler.ToList();
                Console.WriteLine($"Bölüm ID\t Bolum Adı");
                foreach (var bolum in bolumler)
                {

                    Console.WriteLine($"{bolum.ID}\t\t {bolum.BolumAd}");
                }
                Console.ReadLine();
            }

            //Where ile sorgulama, Diş bölümünü getir
            void BolumGetir()
            {
                using (HastaneSabahEntities hastane = new HastaneSabahEntities())
                {
                    //var sonuc = hastane.Bolumler.Where(x => x.BolumAd == "Diş");
                    var sonuc = hastane.Bolumler.Where(x => x.BolumAd.StartsWith("D"));
                    foreach (var item in sonuc)
                    {
                        Console.WriteLine($"Bolümün ID: {item.ID} Bölüm Ad: {item.BolumAd}");
                    }
                    Console.ReadLine();
                }
            }

            //Select ile veri çekme
            void DoktorAdListele()
            {
                using (HastaneSabahEntities hastane = new HastaneSabahEntities())
                {
                    var adlar = hastane.Doktorlar.Select(x => x.AdSoyad);
                    Console.WriteLine($"Doktor Adı");
                    foreach (var ad in adlar)
                    {
                        Console.WriteLine($"{ad}");
                    }
                    Console.ReadLine();
                }
                
            }

            //Find ile hızlı arama
            void HizliArama()
            {
                using (HastaneSabahEntities hastane = new HastaneSabahEntities())
                {
                    Doktorlar doktor = hastane.Doktorlar.Find(4);
                    //Find metodu ilgili tablodaki primary key üzerinden arama yapar
                    //Bu da onu oldukca hızlı hale getirir.
                    Console.WriteLine($"Doktor Adı: {doktor.AdSoyad} Bölümü: {doktor.Bolumler.BolumAd}");
                    Console.ReadLine();
                }
            }

            //İlk kaydı getirme, ilk Demet Evgar'ı getir.
            void IlkKayıt()
            {
                using (HastaneSabahEntities hastane = new HastaneSabahEntities())
                {
                    Doktorlar doktor = hastane.Doktorlar
                        .Where(x => x.AdSoyad == "Demet Evgar")
                        .First();
                    Console.WriteLine($"Doktor Ad: {doktor.AdSoyad} Bölüm Ad:{doktor.Bolumler.BolumAd}");
                }
                Console.ReadLine();
            }

            //İlk üç doktoru getir 
            void IlkUcDoktor()
            {
                using (HastaneSabahEntities hastane = new HastaneSabahEntities())
                {
                    var ilkUcDoktor = hastane.Doktorlar.Take(3);
                    foreach (var doktor in ilkUcDoktor)
                    {
                        Console.WriteLine($"{doktor.AdSoyad}");
                    }
                    Console.ReadLine();
                }
            }

            //Var mı?
            void VarMı()
            {
                using (HastaneSabahEntities hastane = new HastaneSabahEntities())
                {
                    bool sonuc = hastane.Doktorlar.Any(x => x.AdSoyad == "Demet Evgar");
                    if (sonuc)
                    {
                        Console.WriteLine("Aradığınız doktor var");
                    }
                    else
                    {
                        Console.WriteLine("Aradığınız doktor yok");
                    }
                }
                Console.ReadLine();
            }

            //Uygunlık var mı?
            void UyuyorMu()
            {
                using (HastaneSabahEntities hastane = new HastaneSabahEntities())
                {
                    bool sonuc = hastane.Doktorlar.All(x => x.Bolumler.BolumAd == "Dahiliye");
                    if (sonuc)
                    {
                        Console.WriteLine("Evet tümü uygun");
                    }
                    else
                    {
                        Console.WriteLine("Hayır uymayanlar var");
                    }
                }
                Console.ReadLine();
            }

            //Ascending sıralama, A'dan Z'ye, küçükten büyüğe
            void SiralaAsc()
            {
                using (HastaneSabahEntities hastane = new HastaneSabahEntities())
                {
                    var siraliDoktorlar = hastane.Doktorlar.OrderBy(x => x.AdSoyad);
                    foreach (var doktor in siraliDoktorlar)
                    {
                        Console.WriteLine($"{doktor.AdSoyad}");
                    }
                }
                Console.ReadLine();
            }

            //Descending sıralama Z'den A'ya, Büyükten küçüğe
            void SiralaDesc()
            {
                using (HastaneSabahEntities hastane= new HastaneSabahEntities())
                {
                    var tersSiraliDoktorlar = hastane.Doktorlar.OrderByDescending(x=> x.AdSoyad);
                    foreach (var doktor in tersSiraliDoktorlar)
                    {
                        Console.WriteLine(doktor.AdSoyad);
                    }
                    
                }
                Console.ReadLine();
            }

            //SonÜcDoktorugetir
            void SonUcDoktor()
            {
                using (HastaneSabahEntities hastane = new HastaneSabahEntities())
                {
                    var sonUcDoktor = hastane.Doktorlar.OrderByDescending(x => x.ID).Take(3);
                    foreach (var doktor in sonUcDoktor)
                    {
                        Console.WriteLine($"{doktor.AdSoyad}");
                    }
                }
                Console.ReadLine();
            }

            //Bölümlere göre doktor sayısı
            void BolumlereGoreDoktorSayısınıGetir()
            {
                using (HastaneSabahEntities hastane= new HastaneSabahEntities())
                {
                    var sonuc = hastane.Doktorlar
                        .GroupBy(a => a.Bolumler.BolumAd)
                        .Select(b => new
                        {
                            name = b.Key,
                            count = b.Count(),
                        });
                    Console.WriteLine($"Bölüm\tDoktor Sayisi");
                    foreach (var item in sonuc)
                    {
                        Console.WriteLine($"{item.name}\t {item.count}");
                    }
                }
                Console.ReadLine();
            }

            BolumlereGoreDoktorSayısınıGetir();
            //SonUcDoktor();
            //SiralaDesc();
            //SiralaAsc();
            //UyuyorMu();
            //VarMı();
            //IlkUcDoktor();
            //IlkKayıt();
            //HizliArama();
            //DoktorAdListele();
            //BolumGetir();
            //BolumleriListele();
        }
    }
}
