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
                Console.WriteLine(token.getNombre()+", "+token.getToken());
            }

            Console.ReadLine();

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
                else if(esAgrupador(programa[pos]))
                {
                    lista.Add(new Token(programa[pos].ToString(), 2));
                    pos++;
                }
                else if (esTerminador(programa[pos]))
                {
                    lista.Add(new Token(programa[pos].ToString(), 3));
                    pos++;
                }
                else if (esAsignador(programa[pos]))
                {
                    lista.Add(new Token(programa[pos].ToString(), 4));
                    pos++;
                }
            }
            return lista;
        }

        private bool esAsignador(char p)
        {
            if (p == '=')
                return true;
            return false;
        }

        private bool esTerminador(char p)
        {
            if (p == '!')
                return true;
            return false;
        }

        private bool esAgrupador(char p)
        {
            if (p == ')' || p == '(')
                return true;
            return false;
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
