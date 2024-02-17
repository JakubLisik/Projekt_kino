using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektKino
{
    class Program
    {
        
        static void Main(string[] args)
        {
            while (true)
            {
                Menu menu = new Menu();
                User user;

                menu.LogPage();
                user = new User(menu.login, menu.haslo);
                user.LogOn();

                if (user.isLoged)
                {
                    menu.mainMenu(user);
                    /*user.Dump();*/
                }
                Console.ReadKey();
            }
        }
    }
}
