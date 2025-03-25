using System;
using System.Linq;

namespace AdamAsmaca
{
    internal class Program
    {
        static void Main()
        {
            string[] kelimeler = { "elma", "armut", "muz", "çilek", "kiraz" };
            Random rastgele = new Random();
            string secilenKelime = kelimeler[rastgele.Next(kelimeler.Length)];
            char[] tahminEdilen = new string('_', secilenKelime.Length).ToCharArray();
            int hak = 6;
            bool kazandi = false;

            Console.WriteLine("Adam Asmaca Oyununa Hoş Geldiniz!");

            while (hak > 0 && !kazandi)
            {
                Console.WriteLine("\nTahmin edilen kelime: " + new string(tahminEdilen));
                Console.WriteLine($"Kalan hak: {hak}");
                Console.Write("Bir harf tahmin edin: ");
                string giris = Console.ReadLine().ToLower();

                if (string.IsNullOrEmpty(giris) || giris.Length > 1)
                {
                    Console.WriteLine("Lütfen sadece bir harf girin.");
                    continue;
                }

                char tahmin = giris[0];

                if (secilenKelime.Contains(tahmin))
                {
                    for (int i = 0; i < secilenKelime.Length; i++)
                    {
                        if (secilenKelime[i] == tahmin)
                        {
                            tahminEdilen[i] = tahmin;
                        }
                    }
                }
                else
                {
                    hak--;
                    Console.WriteLine("Yanlış tahmin!");
                }

                if (!tahminEdilen.Contains('_'))
                {
                    kazandi = true;
                }
            }

            if (kazandi)
            {
                Console.WriteLine($"\nTebrikler! Kelimeyi doğru bildiniz: {secilenKelime}");
            }
            else
            {
                Console.WriteLine($"\nOyunu kaybettiniz! Doğru kelime: {secilenKelime}");
            }

            Console.WriteLine("\nOyunu kapatmak için bir tuşa basın...");
            Console.ReadKey();
        }
    }
}
