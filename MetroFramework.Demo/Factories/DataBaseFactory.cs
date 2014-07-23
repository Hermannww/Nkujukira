using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nkujukira.Demo.Interfaces;
using Nkujukira.Demo.DataStores;

namespace Nkujukira.Demo.Factories
{
    public class DatabaseFactory
    {
        public const String MYSQL_DBMS     = "MYSQL";
        private const String USERNAME      = "root";
        private const String PASSWORD      = "";
        private const String SERVER        = "localhost";
        public const String DATABASE_NAME = "Nkujukira";

        public static DatabaseInterface GetDatabase(String DBMS)
        {
            switch (DBMS)
            {
                case MYSQL_DBMS:
                    return new MySQLDatabaseHandler(SERVER, DATABASE_NAME, USERNAME, PASSWORD);
            }

            return null;
        }
    }
}
