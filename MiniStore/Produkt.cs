using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniStore
{
    internal class Produkt
    {
        private int id;
        private string nazwa;
        private decimal cena;
        private int ilosc;

        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                if (value > 0)
                {
                    id = value;
                }
                else
                {
                    Console.WriteLine("Podaj poprawnie ID!");
                }
            }
        }
        public string Nazwa
        {
            get
            {
                return nazwa;
            }
            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    nazwa = value;
                }
                else
                {
                    nazwa = "Niepoprawna nazwa produktu";
                }
            }
        }
        public decimal Cena
        {
            get
            {
                return cena;
            }
            set
            {
                if (value > 0)
                {
                    cena = value;
                }
                else
                {
                    Console.WriteLine("Podaj poprawną cenę!");
                }
            }
        }

        public int Ilosc
        {
            get
            {
                return ilosc;
            }
            set
            {
                if (value > -1)
                {
                    ilosc = value;
                }
                else
                {
                    ilosc = default;
                }
            }
        }

        public override string ToString()
        {
            return $"ID: {Id}\nNazwa: {Nazwa}\nCena: {Cena}\nIlość: {Ilosc}\n";
        }

        public Produkt(int id, string nazwa, decimal cena, int ilosc)
        {
            Id = id;
            Nazwa = nazwa;
            Cena = cena;
            Ilosc = ilosc;
        }



    }


}
