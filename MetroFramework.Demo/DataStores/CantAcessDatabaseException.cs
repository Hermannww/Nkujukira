using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nkujukira.Demo.DataStores
{
    public class CantAcessDatabaseException : Exception
    {
        public String ErrorMessage { get; set; }
        public CantAcessDatabaseException(String msg) 
        {
            ErrorMessage = msg;
        }
    }
}
