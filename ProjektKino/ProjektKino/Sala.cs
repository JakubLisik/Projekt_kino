using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ProjektKino
{
    class Sala
    {
        public int idSali;
        public int rzady;
        public int kolumny;
        public int[,] rozklad;
        /*public string[,] rezerwacje;*/
        public Sala(string sala)
        {
            idSali = int.Parse(sala.Split()[0]);
            rzady = int.Parse(sala.Split()[1]);
            kolumny = int.Parse(sala.Split()[2]);
            rozklad = new int[rzady, kolumny];
            /*string[] zapisRezerwacji = File.ReadAllLines("../../seanse.txt");*/
            /*pobierzRezerwacje(zapisRezerwacji);*/
        }
        /*public void pobierzRezerwacje(string[] zapisRezerwacji)
        {

            rezerwacje[rzady, kolumny] = 

        }*/
        public void wyświetlSale(List<string> l)
        {
            Console.Write("    ");
            for (int i = 1; i <= kolumny; i++)
            {
                Console.Write("[" + i + "]");
            }
            Console.WriteLine();
            Console.WriteLine();
            for (int i = 0; i < rzady; i++)
            {
                Console.Write(i+1 + ".  ");
                for (int j = 0; j < kolumny; j++)
                {
                    int xyz = (i * kolumny) + (j + 1);
                    if (l.Contains(xyz.ToString())){
                        Console.Write("[x]");
                    }
                    else
                    {
                        Console.Write("[-]");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
