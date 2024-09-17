using System;
using System.Collections.Generic;
using System.IO;


namespace Employers
{
    public class Alkalmazott
    {
        public int Azonosito;
        public string Nev;
        public int Kor;
        public int Kereset;

        public Alkalmazott(int azonosito, string nev, int kor, int kereset)
        {
            Azonosito = azonosito;
            Nev = nev;
            Kor = kor;
            Kereset = kereset;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // Az alkalmazottak listájának beolvasása
            var alkalmazottak = BeolvasAlkalmazottakat("tulajdonsagok_100sor.txt");

            // Ellenőrizd az adatok betöltését
            Console.WriteLine($"Betöltve {alkalmazottak.Count} alkalmazott");

            // Az alkalmazottak nevének kiírása
            KiirAlkalmazottakNevei(alkalmazottak);
        }

        // Adatok beolvasása a fájlból
        static List<Alkalmazott> BeolvasAlkalmazottakat(string fajlnev)
        {
            var alkalmazottak = new List<Alkalmazott>();
            try
            {
                foreach (var sor in File.ReadLines(fajlnev))
                {
                    var darabok = sor.Split(',');
                    if (darabok.Length == 4)
                    {
                        var alkalmazott = new Alkalmazott(
                            int.Parse(darabok[0]),
                            darabok[1],
                            int.Parse(darabok[2]),
                            int.Parse(darabok[3])
                        );
                        alkalmazottak.Add(alkalmazott);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hiba a fájl beolvasása során: {ex.Message}");
            }
            return alkalmazottak;
        }

        // Az alkalmazottak neveinek kiírása
        static void KiirAlkalmazottakNevei(List<Alkalmazott> alkalmazottak)
        {
            foreach (var alkalmazott in alkalmazottak)
            {
                Console.WriteLine(alkalmazott.Nev);
            }
        }

    }
 }