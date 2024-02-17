using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ProjektKino
{
    class Rezerwacja
    {
        public string[] rezerwacje;
        public int idSeansu;
        public string plikRezerwacje;
        public List<string> listaRezerwacji = new List<string>();
        public string zapisRezerwacji;
        public User user;
        public Rezerwacja(int s)
        {
            idSeansu = s;
        }
        public Rezerwacja(User u)
        {
            user = u;
        }
        /*public void pobierzRezerwacje(string[] zapisRezerwacji)
        {

            rezerwacje[rzady, kolumny] = 

        }*/
        public void pobierzRezerwacje()
        {
            plikRezerwacje = "../../rezerwacje.txt";
            rezerwacje = File.ReadAllLines(plikRezerwacje);
        }
        public List<string> pobierzRezerwacjeSeansu()
        {
            pobierzRezerwacje();
            foreach (string rezerwacja in rezerwacje)
            {
                if (int.Parse(rezerwacja.Split()[1]) == idSeansu)
                {
                    listaRezerwacji.Add(rezerwacja.Split()[2]);
                }
            }
            return listaRezerwacji;
            /*listaRezerwacji.ForEach(element => Console.WriteLine(element));*/
            /*Console.ReadKey();*/
        }
        public void stworzRezerwacje(User u, int s, int m)
        {
            
            zapisRezerwacji = u.userName + " " + s.ToString() + " " + m.ToString();
            File.WriteAllText(plikRezerwacje, string.Empty);
            using (StreamWriter zapis = new StreamWriter(plikRezerwacje, true))
            {
                foreach (string x in rezerwacje)
                {
                    zapis.WriteLine(x);
                }
                zapis.WriteLine(zapisRezerwacji);
            }
            Console.WriteLine("Zapisano rezerwację!");
            Console.ReadKey();
        }
        public void wyswietlRezerwacje()
        {
            pobierzRezerwacje();
            string[] seanse = pobierzSeanse();
            string[] filmy = pobierzFilmy();
            int licznik = 0;
            Console.Clear();
            Console.WriteLine("Twoje rezerwacje: ");
            foreach (string rezerwacja in rezerwacje)
            {
                if (rezerwacja.Split()[0] == user.userName)
                {
                    /*Console.WriteLine(rezerwacja);*/
                    string seansRezerwacji = seanse[int.Parse(rezerwacja.Split()[1])-1];
                    string filmRezerwacji = filmy[int.Parse(seansRezerwacji.Split()[0])-1];
                    Console.WriteLine(licznik+1 + ". " + filmRezerwacji.Split()[1] + " " + seansRezerwacji.Split()[2]);
                    licznik++;
                }
            }
            Console.WriteLine("Wybierz rezerwację jaką chcesz sprawdzić: ");
            string wybranaRezerwacja = Console.ReadLine();
            Console.ReadKey();
        }
        public string[] pobierzSeanse()
        {
            string plikSeanse = "../../seanse.txt";
            return File.ReadAllLines(plikSeanse);
        }
        public string[] pobierzFilmy()
        {
            string plikFilmy = "../../bazaFilmow.txt";
            return File.ReadAllLines(plikFilmy);
        }
        public void usunRezerwacje()
        {

        }
    }
}
