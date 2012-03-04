using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Compilador
{
    class Program
    {
        StringBuilder programa;
        static void Main(string[] args)
        {
            Program programa = new Program();
        }

        /**
         * Constructor de la clase
         * */
        Program()
        {
            // Leer archivos
            StreamReader sr = new StreamReader("programa.itc");
            programa = new StringBuilder();
            String line; 
            line = sr.ReadLine();
            
            /**
             * Este es un ciclo raro
             **/
            while (line != null)
            {
                for (int x = 0; x < line.Length; x++)
                    if (line[x] != ' ' && line[x] != '\n')
                        programa.Append(line[x]);
                line = sr.ReadLine();
            }

            StreamWriter sw = new StreamWriter("ejecutable.o");
            sw.WriteLine(programa);
            sw.Close();
            // Analizador lexico
        }
    }
}
