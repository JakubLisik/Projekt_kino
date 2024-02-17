using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektKino
{
    class Film
    {
        public string id;
        public string tytul;
        public Film(string x)
        {
            id = x.Split()[0];
            tytul = x.Split()[1];
        }
    }
}
