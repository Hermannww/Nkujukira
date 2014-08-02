using Nkujukira.Demo.Entitities;
using Nkujukira.Demo.Factories;
using Nkujukira.Demo.Interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Nkujukira.Demo.Managers
{
    public class Manager
    {
        //database object
        public static DatabaseInterface database = DatabaseFactory.GetDatabase(DatabaseFactory.MYSQL_DBMS);

        //used to read results of data
        public static IDataReader data_reader = null;

        //Sql commad
        public static MySqlCommand sql_command = null ;

        public static void  CloseDatabaseConnection()
        {
            if (data_reader != null) {data_reader.Close();}
            if (database != null)    { database.CloseConnection();}
        }
       
    }
}
