using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ProjektKino
{
    class Seans
    {
        public string idFilmu;
        public string idSali;
        public string godzSeansu;
        public int idSeansu;
        public Sala sala;
        public Rezerwacja rezerwacja;
        public User user;
        public Seans(string f, string s, string g, User u)
        {
            idFilmu = f;
            idSali = s;
            godzSeansu = g;
            this.user = u;
            sala = new Sala(File.ReadAllLines(@"../../sale.txt")[int.Parse(idSali)-1]);
            
        }
        
        public void wyświetlSale(Film[] filmy, int s)
        {
            idSeansu = s;
            rezerwacja = new Rezerwacja(s);
            List<string> listaRezerwacji = rezerwacja.pobierzRezerwacjeSeansu();

            Console.Clear();

            Console.WriteLine("Rozkład sali dla seanu: " + filmy[int.Parse(idFilmu)-1].tytul + " " + godzSeansu);
            Console.WriteLine("");
            this.sala.wyświetlSale(listaRezerwacji);
            Console.WriteLine();
            Console.WriteLine("Wybierz miejce rezerwacji: ");
            string x = PodajRzad();
            string y = PodajKolumne();
            Console.WriteLine();
            int nrMiejsca = int.Parse(y) + ((int.Parse(x) - 1) * sala.kolumny);

            if (weryfikacjaMiejsca(listaRezerwacji, nrMiejsca))
            {
                wybierzMiejsce(filmy, x, y, nrMiejsca);
            }
            else
            {
                wyświetlSale(filmy, s);
            }
            
        }
        public string PodajRzad()
        {
            Console.WriteLine("Podaj numer rzędu: ");
            string rzad = Console.ReadLine();
            if (int.Parse(rzad) >= 1 && int.Parse(rzad) <= sala.rzady)
            {
                return rzad;
            }
            else
            {
                return PodajRzad();
            }
        }
        public string PodajKolumne()
        {
            Console.WriteLine("Podaj numer miejsca: ");
            string kolumna = Console.ReadLine();
            if (int.Parse(kolumna) >= 1 && int.Parse(kolumna) <= sala.kolumny)
            {
                return kolumna;
            }
            else
            {
                return PodajKolumne();
            }
        }
        public bool weryfikacjaMiejsca(List<string> listaRezerwacji, int nrMiejsca)
        {
            foreach (string verify in listaRezerwacji)
            {
                if (nrMiejsca == int.Parse(verify))
                {
                    Console.WriteLine("Miejsce już zajęte!");
                    Console.ReadKey();
                    return false;
                }
            }
            return true;
        }
        public void wybierzMiejsce(Film[] filmy, string x, string y, int nrMiejsca)
        {
            
            Console.WriteLine("Czy na pewno chcesz dokonać rezerwacji na seans " + filmy[int.Parse(idFilmu) - 1].tytul + " " + godzSeansu + ", na miejsce " + y + " w rzędzie " + x + "? (y/n)");
            string potwierdzenie = Console.ReadLine();
            switch (potwierdzenie)
            {
                case "y":
/*                    Console.WriteLine("Zapisano miejsce: " + x + y);
*/
                    rezerwacja.stworzRezerwacje(user, idSeansu, nrMiejsca);
                    break;
                case "n":
                    Console.WriteLine("Anulowano rezerwację. Powrót do Menu.");
                    Console.ReadKey();
                    break;
                default:
                    Console.WriteLine("Podano zły argument! (y/n)");
                    wybierzMiejsce(filmy, x, y, nrMiejsca);
                    break;
            }
        }
    }
}
