using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ProjektKino
{
    class User
    {
        private string login;
        private string haslo;
        /*public int userId;*/
        public string userName;
        public bool isLoged;
        private string[] bazaKont;
        public User()
        {
            login = "";
            haslo = "";
            pobierzListeKont();
        }
        public User(string l,string h)
        {
            login = l;
            haslo = h;
            /*isLoged = login == "Jan" && haslo == "Nowak";*/
            pobierzListeKont();
        }
        public void pobierzListeKont()
        {
            string plik = "../../konta.txt";
            bazaKont = File.ReadAllLines(plik);
        }

        public void LogOn()
        {
            string user = login + " " + haslo;
            if (bazaKont.Contains(user))
            {
                userName = login;
                isLoged = true;
            }
            else
            {
                isLoged = false;
                Console.WriteLine("Błędne dane logowania. Kliknij dowolny przycisk aby wrócić do logowania");
                /*Console.ReadKey();*/
/*                menu.LogPage();*/
            }
        }
        /*public void Dump()
        {
            Console.WriteLine("Jesteś zalogowany na użytkowniku: " + " " + userName);
        }*/
    }
}
