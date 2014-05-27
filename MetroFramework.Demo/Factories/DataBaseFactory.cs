using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MetroFramework.Demo.FactoryMethod;

namespace MetroFramework.Demo.Factories
{
    public class DatabaseFactory : StorageFactory
    {
        public const String MYSQL_DATABASE = "MYSQL";

        public DatabaseInterface getDataBase(String database)
        {
            switch(database)
            {
                case MYSQL_DATABASE:
                    return new MySQLDatabaseHandler();
            }

            return null;
        }
    }
}
