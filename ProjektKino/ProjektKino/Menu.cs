using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektKino
{
    class Menu
    {

        public string login;
        public string haslo;
        private string action;
        public Menu()
        {

        }

        public void LogPage()
        {
            Console.Clear();
            Console.WriteLine("Aplikacja Kino");

            Console.Write("Login:");
            login = Console.ReadLine();
            Console.Write("Hasło:");
            haslo = Console.ReadLine();
        }
        public void mainMenu(User u)
        {
            Console.Clear();
            Console.WriteLine("Witaj " + u.userName + "!");
            Console.WriteLine("Wybierz akcję którą chcesz wykonać: ");
            Console.WriteLine("1. Sprawdź wyświetlane filmy");
            Console.WriteLine("2. Zarządzaj rezerwacjami");
            Console.WriteLine("3. Wyloguj się");
            this.mainMenuAction(u);
        }
        public void mainMenuAction(User u)
        {
            action = Console.ReadLine();
            switch (action)
            {
                case "1":
                    Repertuar repertuar = new Repertuar(u);
                    /*Console.ReadKey();*/
                    repertuar.wypiszFilmy();
                    this.mainMenu(u);
                    break;
                case "2":
                    Rezerwacja rezerwacja = new Rezerwacja(u);
                    rezerwacja.wyswietlRezerwacje();
                    break;
                case "3":
                    u.isLoged = false;
                    Console.WriteLine("pomyślnie wylogowano! Kliknij dowolny klawisz aby wrócić do logowania");
                    Console.ReadKey();
                    this.LogPage();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Podano nie właściwą akcję!");
                    Console.ReadKey();
                    this.mainMenu(u);
                    break;
            }
        }
    }
}
