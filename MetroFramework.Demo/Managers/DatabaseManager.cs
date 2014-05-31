using MetroFramework.Demo.Factories;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MetroFramework.Demo.Managers
{
    class DatabaseManager : Manager
    {
        private const string DATABASE_NAME = DatabaseFactory.DATABASE;

        public static void CreateDatabase() 
        {
            String create_sql = "create database " + DATABASE_NAME;
            sql_command = new MySql.Data.MySqlClient.MySqlCommand();
            sql_command.Connection = (MySqlConnection)database.OpenConnection();
            sql_command.CommandText = create_sql;
            sql_command.Prepare();
            database.Update(sql_command);
        }

        public static void CreateTables() 
        {
            AdminManager.CreateTable();

            StudentsManager.CreateTable();

            PerpetratorsManager.CreateTable();

            VictimsManager.CreateTable();
        }

        public static void PopulateTables() 
        {
            AdminManager.PopulateTable();

            StudentsManager.PopulateTable();

            PerpetratorsManager.PopulateTable();

            VictimsManager.PopulateTable();
        }

        public static void Droptables()
        {
            AdminManager.DropTable();

            StudentsManager.DropTable();

            PerpetratorsManager.DropTable();

            VictimsManager.DropTable();
        }
    }
}
