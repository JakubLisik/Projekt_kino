using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ProjektKino
{
    class Repertuar
    {
        /*string bazaFilmow = @"bazaFilmow.txt";*/
        /*public string nrFilmu;*/
        /*string[] filmy;*/
        public string[] seanse;
        public string wybranyFilm;
        public Seans[] listaSeansow;
        public string sala;
        private Seans[] wybraneSeanse;
        public string choice;
        public Seans wybranySeans;
        public User user;
        public Film[] filmy;
        public Repertuar(User u)
        {
            this.user = u;
            string[] listaFilmow = File.ReadAllLines(@"../../bazaFilmow.txt");
            filmy = new Film[listaFilmow.Length];
            int licznik = 0;
            foreach (string film in listaFilmow)
            {
                filmy[licznik] = new Film(film);
                Console.WriteLine(filmy[licznik].tytul);
                licznik++;
            }
            seanse = File.ReadAllLines(@"../../seanse.txt");
            listaSeansow = new Seans[seanse.Length];
            wybraneSeanse = new Seans[seanse.Length];
            this.pobierzSeanse();
        }
        public void pobierzSeanse()
        {
            int licznik = 0;
            foreach(string seans in seanse)
            {
                string[] dane = seans.Split();
                listaSeansow[licznik] = new Seans(dane[0], dane[1], dane[2], user);
                /*Console.WriteLine(listaSeansow[licznik].godzSeansu);*/
                /*Console.WriteLine(dane[3]);*/
                /*Console.ReadKey();*/
                licznik++;
            }
        }
        public void wypiszFilmy()
        {
            
            Console.Clear();

            foreach (Film film in filmy)
            {
                Console.WriteLine(film.id + ". " + film.tytul);
            }
            this.wybierzFilm();
        }
        public void wybierzFilm()
        {
            Console.WriteLine("Wybierz film dla którego seansy chcesz sprawdzić: ");
            wybranyFilm = Console.ReadLine();
            wyswietlSeanse();
        }
        public void wyswietlSeanse()
        {
            Console.Clear();
            int licznik = 1;
            foreach (Seans seans in listaSeansow)
            {
                if (seans.idFilmu == wybranyFilm)
                {
                    /*if (seans.idSali == "1")
                    {
                        sala = "Sala 1";
                    }
                    else
                    {
                        sala = "Sala 2";
                    }*/
                    switch (seans.idSali)
                    {
                        case "1":
                            sala = "Sala 1";
                            break;
                        case "2":
                            sala = "Sala 2";
                            break;
                    }
                    Console.WriteLine(licznik + ". " + seans.godzSeansu + " - " + sala);
                    wybraneSeanse[licznik - 1] = seans;
                    licznik++;
                }
            }
            Console.WriteLine("Wybierz seans: ");
            choice = Console.ReadLine();
            wybranySeans = wybraneSeanse[Int32.Parse(choice) - 1];

            string seansIndex = wybranySeans.idFilmu + " " + wybranySeans.idSali + " " + wybranySeans.godzSeansu;
            /*int abc = Array.IndexOf(seanse, seansIndex);
            Console.WriteLine(abc);
            Console.ReadKey();*/
            /*Console.WriteLine(seanse[10]);
            foreach (string z in seanse)
            {
                Console.WriteLine(z);
            }*/
            
            /*Console.ReadKey();*/

            wybranySeans.wyświetlSale(filmy, Array.IndexOf(seanse, seansIndex)+1);
        }
        /*public int SprawdzIdSeansu(string seansIndex)
        {
            for (int i = 0; i <= seanse.Length-1; i++)
            {
                Console.WriteLine(seanse[i] + " " + seansIndex);
                Console.WriteLine(seanse[i] == seansIndex);
                Console.ReadKey();
                if (seanse[i] == seansIndex)
                {
                    return i;
                }
            }
            return -2;
        }*/
    }


}
