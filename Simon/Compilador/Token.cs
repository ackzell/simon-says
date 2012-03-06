using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Compilador
{
    class Token
    {
        String token;
        int tipo;
        /*
         * 0 - Numero
         * 1 - Id
         * 2 - Agrupador
         * 3 - Terminador
         * 4 - Asignador
         */
        public Token(string s, int t)
        {
            token = s;
            tipo = t;
        }

        public String getToken()
        {
            return token;
        }

        public int getTipo()
        {
            return tipo;
        }

        public String getNombre()
        {
            switch (tipo)
            {
                case 0:
                    return "Numero";
                case 1:
                    return "Caracter";
                case 2:
                    return "Agrupador";
                case 3:
                    return "Terminador";
                case 4:
                    return "Asignador";
            }
            return "ND";
        }
    }
}
