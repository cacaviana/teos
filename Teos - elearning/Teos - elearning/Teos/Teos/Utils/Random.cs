using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Teos.Utils
{
    public class Random
    {
        Random random = new Random();

        string[] NomesAleatorios = {"A", "B", "C", "D", "E", "F", "G", "H",
                            "I", "J", "K", "L", "M", "N", "O", "P","Q",
        "R", "S", "T", "U", "V", "X", "W", "Y", "Z",
        "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p","q",
        "r", "s", "t", "u", "v", "x", "w", "y", "z",
        "1", "2", "3", "4", "5", "6", "7", "8", "9", "0",
        "_","-", "¨"};

        public string GerarRandom(string valor)
        {
            
         
            
            //for (int i = 0; i < 7; i++)
            //{
            //    valor += random.GerarRandom(NomesAleatorios);
            //}

            return valor;
        }

    }
}