using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MetroFramework.Demo.FactoryMethod;

namespace MetroFramework.Demo.Factories
{
    public class DataBaseFactory
    {
        public DataBaseInterface getDataBase(String database)
        {
            if (database == null)
            {
                return null;
            }
            else if (database.Equals("MYSQL"))
            {
                return new MySQLDataBaseHandler();
            }

            return null;
        }
    }
}
