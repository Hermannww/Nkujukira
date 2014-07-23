using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using Nkujukira.Demo.Entitities;
using System.Data;
using System.Collections;
using System.Data.SqlClient;
using System.Data.Common;

namespace Nkujukira.Demo.Interfaces
{
    public interface DatabaseInterface
    {
      
        //open connection to database
        DbConnection OpenConnection();

        DbConnection GetConnection();

        //Close connection
        bool CloseConnection();
       

        //Insert statement
        void Insert(DbCommand insert_sql);
       

        //Update statement
        void Update(DbCommand update_sql);
       

        //Delete statement
        void Delete(DbCommand delete_sql);
        

        //Select statement
        IDataReader Select(DbCommand select_sql);
       

        //Count statement
        int Count(DbCommand count_sql);
       

        //Backup
        void Backup();
       

        //Restore
        void Restore();
       
    }
}
