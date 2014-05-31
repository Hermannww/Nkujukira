using MetroFramework.Demo.Entitities;
using MetroFramework.Demo.Factories;
using MetroFramework.Demo.Interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace MetroFramework.Demo.Managers
{
    public abstract class Manager
    {
        //database object
        public static DatabaseInterface database = DatabaseFactory.GetDatabase(DatabaseFactory.MYSQL_DBMS);

        //used to read results of data
        public static IDataReader data_reader = null;

        //Sql commad
        public static MySqlCommand sql_command = null ;
    }
}
