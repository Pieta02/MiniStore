using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniStore
{
    internal class MagazynService
    {
        public static Produkt TworzenieProduktu(int id)
        {
            Console.Write("Podaj nazwę produktu: ");
            string nazwa = Console.ReadLine();

            decimal cena = 0;
            bool warCena = true;
            while (warCena)
            {
                Console.Write("Podaj cenę produktu: ");
                string cenaText = Console.ReadLine();

                if (!decimal.TryParse(cenaText, out cena))
                {
                    Console.Clear();
                    Console.WriteLine("Proszę podać poprawną cenę");
                    Console.ReadLine();
                    Console.Clear();
                }
                else
                {
                    warCena = false;
                }
            }

            int ilosc = 0;
            bool warIlosc = true;
            while (warIlosc)
            {
                Console.Write("Podaj ilość produktu: ");
                string iloscText = Console.ReadLine();

                if (!int.TryParse(iloscText, out ilosc))
                {
                    Console.Clear();
                    Console.WriteLine("Proszę podać poprawną ilość");
                    Console.ReadLine();
                    Console.Clear();
                }
                else
                {
                    warIlosc = false;
                }
            }

            Console.Clear();

            Produkt produkt = new Produkt(id, nazwa, cena, ilosc);

            Console.WriteLine("Produkt dodany!");
            Console.ReadLine();
            Console.Clear();

            return produkt;
        }

        public static void DodawanieProduktu(List<Produkt> produkty)
        {
            Console.Write("Ile produktów chcesz dodać?: ");
            string ilosc_prod_tekst = Console.ReadLine();

            int id = produkty.Count + 1;

            if (!String.IsNullOrEmpty(ilosc_prod_tekst) && int.TryParse(ilosc_prod_tekst, out int ilosc_prod))
            {
                for (int i = 0; i < ilosc_prod; i++)
                {
                    produkty.Add(TworzenieProduktu(id++));
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Proszę wpisywać tylko liczby całkowite dodatnie");
                Console.ReadLine();
                Console.Clear();
                DodawanieProduktu(produkty);
            }
        }

        public static void UsuwanieProduktu(List<Produkt> produkty)
        {
            Console.WriteLine("Wpisz ID produktu, który chcesz usunąć\nWyświetl produkty wpisując - \"lista\"\nCofnij - \"0\"");
            string wybor = Console.ReadLine();

            if (wybor.Equals("lista"))
            {
                Console.Clear();
                WyswietlanieProduktow(produkty);
                Console.WriteLine("\nAby kontynuować naciśniej jakikolwiek klawisz");
                Console.ReadLine();
                Console.Clear();
                UsuwanieProduktu(produkty);
            }
            else if (wybor.Equals("0"))
            {
                Console.Clear();
                return;
            }
            else
            {
                int.TryParse(wybor, out int i);
                foreach (var produkt in produkty)
                {
                    if (produkt.Id.Equals(i))
                    {
                        produkty.Remove(produkt);
                        Console.Clear();
                        Console.WriteLine($"Usunięto produkt o ID:{produkt.Id}!");
                        Console.ReadLine();
                        Console.Clear();
                        return;
                    }
                }
                Console.Clear();
                Console.WriteLine("Nie znalezion produktu");
                Console.ReadLine();
                Console.Clear();
                UsuwanieProduktu(produkty);
            }
        }

        public static void WyswietlanieProduktow(List<Produkt> produkty)
        {
            foreach (var item in produkty)
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();
            Console.Clear();
        }


        public static void WyszukiwanieProduktow(List<Produkt> produkty)
        {
            Console.Write("Podaj ID produktu: ");
            int.TryParse(Console.ReadLine(), out int szukProd);
            Console.Clear();

            for (int i = 0; i < produkty.Count; i++)
            {
                if (szukProd == produkty[i].Id)
                {
                    Console.Clear();
                    Console.WriteLine($"Produkt znaleziono!\n{produkty[i]}");
                    Console.ReadLine();
                    Console.Clear();
                    return;
                }
            }

            Console.WriteLine("Nie znaleziono produktu");
            Console.ReadLine();
            Console.Clear();
        }

        public static Produkt ZnajdzProdukt(List<Produkt> produkty)
        {
            Console.Write("Jaki produkt szukasz?: ");
            int.TryParse(Console.ReadLine(), out int szukProd);
            Console.Clear();

            for (int i = 0; i < produkty.Count; i++)
            {
                if (szukProd == produkty[i].Id)
                {
                    return produkty[i];
                }
            }

            return null;
        }

        public static void Statystyki(List<Produkt> produkty)
        {
            Console.Clear();
            if (produkty.Count != 0)
            {
                Console.WriteLine("Dane:\n");
                int sumaProd = 0;
                int sumaIlosc = 0;
                decimal wartoscMagazynu = 0;
                decimal najdrozszyProdCena = produkty[0].Cena;
                string najdrozszyProd = produkty[0].Nazwa;
                decimal najtanszyProdCena = produkty[0].Cena;
                string najtanszyProd = produkty[0].Nazwa;
                int najwiekszaIlosc = produkty[0].Ilosc;
                decimal sredniaCena = 0;
                string najwiekszaIloscNazwa = produkty[0].Nazwa;
                foreach (var produkt in produkty)
                {
                    sumaProd++;
                    sumaIlosc += produkt.Ilosc;
                    wartoscMagazynu += produkt.Cena * produkt.Ilosc;
                    if (produkt.Cena > najdrozszyProdCena)
                    {
                        najdrozszyProdCena = produkt.Cena;
                        najdrozszyProd = produkt.Nazwa;
                    }
                    if (produkt.Cena < najtanszyProdCena)
                    {
                        najtanszyProdCena = produkt.Cena;
                        najtanszyProd = produkt.Nazwa;
                    }
                    if (produkt.Ilosc > najwiekszaIlosc)
                    {
                        najwiekszaIlosc = produkt.Ilosc;
                        najwiekszaIloscNazwa = produkt.Nazwa;
                    }

                }
                sredniaCena = Math.Round(wartoscMagazynu / sumaIlosc, 2);

                Console.WriteLine(
                    $"Liczba różnych produktów: {sumaProd}\n" +
                    $"Łączna ilość sztuk: {sumaIlosc}\n" +
                    $"Łączna wartość magazynu: {wartoscMagazynu} zł\n" +
                    $"Najdroższy produkt: {najdrozszyProd} w cenie {najdrozszyProdCena} zł\n" +
                    $"Najtańszy produkt: {najtanszyProd} w cenie {najtanszyProdCena} zł\n" +
                    $"Produkt z największą ilością sztuk: {najwiekszaIloscNazwa}\n" +
                    $"Średnia cena produktu: {sredniaCena} zł\n");
                Console.ReadLine();
                Console.Clear();
            }
            else
            {
                Console.WriteLine("Magazyn jest pusty");
                Console.ReadLine();
                Console.Clear();
            }
        }
        public static void EdycjaProduktu(List<Produkt> produkty)
        {
            Produkt produkt = ZnajdzProdukt(produkty);
            bool cond = true;
            while (cond)
            {
                if (produkt != null)
                {
                    Console.WriteLine("Co chcesz zmienić?\n1.ID\n2.Nazwa\n3.Cena\n4.Ilość\n5.Wyjście");
                    string wyborTekst = Console.ReadLine();
                    if (int.TryParse(wyborTekst, out int wybor))
                    {
                        if (0 < wybor && wybor < 6)
                        {
                            switch (wybor)
                            {
                                case 1:
                                    bool war1 = true;
                                    while (war1)
                                    {
                                        Console.Clear();
                                        Console.Write("Podaj nowe ID: ");
                                        if (int.TryParse(Console.ReadLine(), out int noweId))
                                        {
                                            int stareId = produkt.Id;
                                            produkt.Id = noweId;
                                            Console.WriteLine($"Zmieniono cenę produktu z {stareId} na {noweId}");
                                            Console.ReadLine();
                                            Console.Clear();
                                            war1 = false;
                                        }
                                        else
                                        {
                                            Console.WriteLine("Proszę wprowadź tylko całkowite");
                                            Console.ReadLine();
                                            Console.Clear();
                                        }
                                    }
                                    break;

                                case 2:
                                    Console.Clear();
                                    Console.Write("Podaj nową nazwę: ");
                                    string nowaNazwa = Console.ReadLine();
                                    string staraNazwa = produkt.Nazwa;
                                    produkt.Nazwa = nowaNazwa;
                                    Console.WriteLine($"Zmieniono nazwę produktu z {staraNazwa} na {nowaNazwa}");
                                    Console.ReadLine();
                                    Console.Clear();
                                    break;

                                case 3:
                                    bool war2 = true;
                                    while (war2)
                                    {
                                        Console.Clear();
                                        Console.Write("Podaj nową cenę: ");
                                        if (decimal.TryParse(Console.ReadLine(), out decimal nowaCena))
                                        {
                                            decimal staraCena = produkt.Cena;
                                            produkt.Cena = nowaCena;
                                            Console.WriteLine($"Zmieniono cenę produktu z {staraCena} na {nowaCena}");
                                            Console.ReadLine();
                                            Console.Clear();
                                            war2 = false;
                                        }
                                        else
                                        {
                                            Console.WriteLine("Proszę wprowadź tylko liczby");
                                            Console.ReadLine();
                                            Console.Clear();
                                        }
                                    }
                                    break;

                                case 4:
                                    bool war3 = true;
                                    while (war3)
                                    {
                                        Console.Clear();
                                        Console.Write("Podaj nową ilość produktu: ");
                                        if (int.TryParse(Console.ReadLine(), out int nowaIlosc))
                                        {
                                            int staraIlosc = produkt.Ilosc;
                                            produkt.Ilosc = nowaIlosc;
                                            Console.WriteLine($"Zmieniono ilość produktu z {staraIlosc} na {nowaIlosc}");
                                            Console.ReadLine();
                                            Console.Clear();
                                            war3 = false;
                                        }
                                        else
                                        {
                                            Console.WriteLine("Proszę wprowadź tylko liczby");
                                            Console.ReadLine();
                                            Console.Clear();
                                        }
                                    }
                                    break;

                                case 5:
                                    Console.Clear();
                                    cond = false;
                                    break;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Proszę podać tylko numer z zakresu: 1, 2, 3, 4, 5");
                            Console.ReadLine();
                            Console.Clear();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Proszę wprowadzać tylko liczby");
                        Console.ReadLine();
                        Console.Clear();
                    }
                }
                else
                {
                    Console.WriteLine("Nie znaleziono produktu");
                    Console.ReadLine();
                    Console.Clear();
                    cond = false;
                }
            }
        }
    }
}
