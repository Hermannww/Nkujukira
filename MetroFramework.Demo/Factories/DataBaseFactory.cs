using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MetroFramework.Demo.Interfaces;
using MetroFramework.Demo.DataStores;

namespace MetroFramework.Demo.Factories
{
    public class DatabaseFactory : StorageFactory
    {
        public const String MYSQL_DBMS = "MYSQL";
        public const String USERNAME   = "root";
        public  const String PASSWORD  = "";
        public const String SERVER     = "localhost";
        public const String DATABASE   = "Nkujukira";

        public static DatabaseInterface GetDatabase(String dbms)
        {
            switch(dbms)
            {
                case MYSQL_DBMS:
                    return new MySQLDatabaseHandler(SERVER, DATABASE, USERNAME, PASSWORD);
            }

            return null;
        }
    }
}
