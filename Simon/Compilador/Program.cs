using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Collections;

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

            ArrayList tokens = this.lexico(programa);

            foreach(Token token in tokens)
            {
                Console.WriteLine(token.getTipo()+" "+token.getToken());
            }

            /*
             * StreamWriter sw = new StreamWriter("ejecutable.o");
            sw.WriteLine(programa);
            sw.Close();
             */ 
            // Analizador lexico
        }

        private ArrayList lexico(StringBuilder programa)
        {
            ArrayList lista = new ArrayList();
            int pos = 0;
            while (pos < programa.Length)
            {
                // Es digito
                String res = "";
                if (esNumero(programa[pos]))
                {
                    do
                    {
                        res += programa[pos];
                        pos++;
                    } while (esNumero(programa[pos]));
                    lista.Add(new Token(res, 0));
                }
                else if (esCaracter(programa[pos]))
                {
                    do
                    {
                        res += programa[pos];
                        pos++;
                    } while (esNumero(programa[pos]) || esCaracter(programa[pos]));
                    lista.Add(new Token(res, 1));
                }
                else
                {
                    lista.Add(new Token(programa[pos].ToString(), 2));
                    pos++;
                }
            }
            return lista;
        }

        private bool esCaracter(char c)
        {
            if (c >= 'a' && c <= 'z')
                return true;
            if (c >= 'A' && c <= 'Z')
                return true;
            return false;
        }

        private Boolean esNumero(char c)
        {
            if (c >= '0' && c <= '9')
                return true;
            return false;
        }
    }
}
