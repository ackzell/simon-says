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
    }
}
