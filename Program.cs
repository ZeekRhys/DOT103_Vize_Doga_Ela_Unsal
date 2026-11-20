using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("================================");
        Console.WriteLine("          MUREX PIT      ");
        Console.WriteLine("================================");
        Console.WriteLine("murex çukuruna yaklaşıyorsun...");

        int oyuncuCan = 100;
        int oyuncuEnerji = 35;
        int inciSayisi = 4;

        int dusmanCan = 60;
        int dusmanHasari = 12;

        bool oyunDevamEdiyor = true;
        
        bool bicakKusandiMi = false;

        bool oyuncuSavunmadaMi = false;

        DurumGoster(oyuncuCan, oyuncuEnerji, inciSayisi, dusmanCan);

        int turSayisi = 0;
        string bicakSecimi;

        Random rastgele = new Random();

        string[] dusmanSaldirilari = { "venüs dikeni", "spiral kırılma", "taç yankı" };

        do
        {
            Console.WriteLine("Bir kısa bıçağın var.");
            Console.WriteLine("1 - Bıçağı Kuşan");
            Console.WriteLine("2 - Bıçağı Kuşanma");
            Console.WriteLine("Seçimin: ");

            bicakSecimi = Console.ReadLine();

        } while (bicakSecimi != "1" && bicakSecimi != "2");

        if (bicakSecimi == "1")
        { 
            bicakKusandiMi = true;
            Console.WriteLine("Bıçağı kuşandın.");
        }
        else
        {
            Console.WriteLine("Bıçağı kuşanmadın.");
        }

        while (oyunDevamEdiyor == true && turSayisi < 40)
        {
       
                Console.WriteLine(" ");
                Console.WriteLine("===== TUR " + (turSayisi + 1) + " =====");

                Console.WriteLine("1 - saldır");
                Console.WriteLine("2 - savun");
                Console.WriteLine("3 - inci kullan");

                Console.Write("Ne yapmak istiyorsun? ");
                string secim = Console.ReadLine() ?? "";

                if (secim != "1" && secim != "2" && secim != "3")
                {
                    Console.WriteLine("Geçersiz seçim!");
                    continue;
                }

                turSayisi++;

            if (secim == "1")
            {
                int hasar = OyuncuSaldir(rastgele, bicakKusandiMi);

                dusmanCan = dusmanCan - hasar;

                if (dusmanCan < 0)
                {
                    dusmanCan = 0;
                }

                Console.WriteLine("Düşmana saldırdın!");
                Console.WriteLine($"Verdiğin hasar: {hasar}");
                Console.WriteLine($"Düşmanın kalan canı: {dusmanCan}");

                if (dusmanCan <= 0)
                {
                    dusmanCan = 0;
                    Console.WriteLine("Düşman yenildi!");
                    oyunDevamEdiyor = false;
                }
            


        }
            else if (secim == "2")
            {
                oyuncuSavunmadaMi = true;

                Console.WriteLine("Savunmayı seçtin!");
            }
            else if (secim == "3")
            {
                if (inciSayisi > 0)
                {
                    if (oyuncuCan < 100)
                    {
                        oyuncuCan = oyuncuCan + 25;

                        if (oyuncuCan > 100)
                        {
                            oyuncuCan = 100;
                        }

                        inciSayisi--;

                        Console.WriteLine("Bir inci kullandın!");
                        Console.WriteLine($"Canın: {oyuncuCan}");
                        Console.WriteLine($"Kalan inciler: {inciSayisi}");
                    }
                    else
                    {
                        Console.WriteLine("Canın zaten dolu!");
                        turSayisi--;
                        continue;
                    }
                }
                else
                {
                    Console.WriteLine("Kullanacak incin kalmadı!");
                    turSayisi--;
                    continue;
                }
            
        }
   

            if (secim == "1" || secim == "2")
            {
                if (dusmanCan > 0)
                {
                    int alinanHasar = DusmanSaldir(rastgele, dusmanSaldirilari, oyuncuSavunmadaMi, dusmanHasari);

                    oyuncuCan = oyuncuCan - alinanHasar;

                    Console.WriteLine($"Kalan canın: {oyuncuCan}");

                    if (oyuncuCan <= 0)
                    {
                        oyuncuCan = 0;
                        oyunDevamEdiyor = false;
                        break;
                    }
                }
            }

            oyuncuSavunmadaMi = false;

        }

        if (oyuncuCan <= 0)
        {
            Console.WriteLine("===== OYUN BİTTİ =====");
            Console.WriteLine("Murex Pit'te yenildin...");
        }
        else if (dusmanCan <= 0)
        {
            Console.WriteLine("===== ZAFER =====");
            Console.WriteLine("Murex Pit'in muhafızını yendin!");
        }
        else if (turSayisi >= 40)
        {
            Console.WriteLine("===== TUR SINIRI =====");
            Console.WriteLine("Çukurda daha fazla ilerleyemedin...");
        }

    }

    static void DurumGoster(int oyuncuCan, int oyuncuEnerji, int inciSayisi, int dusmanCan)
    {
        Console.WriteLine("OYUNCU STATÜSÜ");
        Console.WriteLine("HP: " + oyuncuCan);
        Console.WriteLine("ENERJİ: " + oyuncuEnerji);
        Console.WriteLine("İNCİLER: " + inciSayisi);

        Console.WriteLine("__________________________________");

        Console.WriteLine("DÜŞMAN STATÜSÜ");
        Console.WriteLine("HP " + dusmanCan);
    }

    static int DusmanSaldir(Random rastgele, string[] dusmanSaldirilari, bool oyuncuSavunmadaMi, int dusmanHasari)
    {
        int saldiriIndeksi = rastgele.Next(0, dusmanSaldirilari.Length);
        Console.WriteLine("Murex, " + dusmanSaldirilari[saldiriIndeksi] + " saldırısını kullanıyor!");

        int alinanHasar;

        if (oyuncuSavunmadaMi == true)
        {
            alinanHasar = 4;
        }
        else
        {
            alinanHasar = dusmanHasari;
        }

        Console.WriteLine("Düşman karşı hamle yaptı!");
        Console.WriteLine($"Aldığın hasar: {alinanHasar}");

        return alinanHasar;
    }

    static int OyuncuSaldir(Random rastgele, bool bicakKusandiMi)
    {
        int hasar;

        if (bicakKusandiMi == true)
        {
            hasar = rastgele.Next(15, 23);
        }
        else
        {
            hasar = rastgele.Next(8, 13);
        }

        int kritik = rastgele.Next(1, 101);

        if (kritik <= 15)
        {
            hasar = hasar * 2;
            Console.WriteLine("KRİTİK VURUŞ!");
        }

        return hasar;
    }

}