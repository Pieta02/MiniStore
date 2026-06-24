using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.IO;

namespace MiniStore
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            List<Produkt> produkty = PlikService.WczytajProdukty();
            
            bool working = true;

            while (working)
            {
                int wybor = Menu();
                switch (wybor)
                {
                    case 1:
                        MagazynService.DodawanieProduktu(produkty);
                        break;
                    case 2:
                        MagazynService.WyswietlanieProduktow(produkty);
                        break;
                    case 3:
                        MagazynService.UsuwanieProduktu(produkty);
                        break;
                    case 4:
                        MagazynService.WyszukiwanieProduktow(produkty);
                        break;
                    case 5:
                        MagazynService.EdycjaProduktu(produkty);
                        break;
                    case 6:
                        MagazynService.Statystyki(produkty);
                        break;
                    case 7:
                        PlikService.ZapiszProdukty(produkty);
                        working = false;
                        break;
                }
            }
            Console.ReadLine();
        }

        static int Menu()
        {
            Console.WriteLine("1. Dodaj produkt\n2. Wyświetl produkty\n3. Usuń produkt\n4. Wyszukaj produkt\n5. Edycja produktu\n6. Statystyki magazynu\n7. Wyjście\n");

            string wybor = Console.ReadLine();
            if (int.TryParse(wybor, out int i))
            {
                if (1 <= i && i <= 7)
                {
                    Console.Clear();
                    return i;
                }
                else
                {
                    Console.WriteLine("Proszę podać tylko liczby widoczne w menu: 1,2,3,4,5,6,7");
                    Console.ReadLine();
                    Console.Clear();
                    return Menu();
                }
            }
            else
            {
                Console.WriteLine("Proszę wpisać tylko liczby");
                Console.ReadLine();
                Console.Clear();
                return Menu();
            }
        }
    }
}
