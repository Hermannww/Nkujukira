using Nkujukira.Demo.Factories;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nkujukira.Demo.Managers
{
    public class DatabaseManager : Manager
    {
        private const string DATABASE_NAME = DatabaseFactory.DATABASE_NAME;

        //CREATE NEW DATABASE
        public static bool CreateDatabase()
        {
            try
            {
                String create_sql          = "CREATE DATABASE IF NOT EXITS " + DATABASE_NAME;
                sql_command                = new MySql.Data.MySqlClient.MySqlCommand();
                sql_command.Connection     = (MySqlConnection)database.OpenConnection();
                sql_command.CommandText    = create_sql;
                sql_command.Prepare();
                database.Update(sql_command);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                CloseDatabaseConnection();
            }
        }

        //CREATE TABLES IN DATABASE
        public static bool CreateTables()
        {
            try
            {
                AdminManager.CreateTable();
                StudentsManager.CreateTable();
                PerpetratorsManager.CreateTable();
                VictimsManager.CreateTable();
                SettingsManager.CreateTable();
                CrimesManager.CreateTable();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                CloseDatabaseConnection();
            }
        }

        //POPULATE TABLES WITH INITIAL DATA
        public static bool PopulateTables()
        {
            try
            {
                AdminManager.PopulateTable();
                StudentsManager.PopulateTable();
                PerpetratorsManager.PopulateTable();
                VictimsManager.PopulateTable();
                SettingsManager.PopulateTable();
                CrimesManager.PopulateTable();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                CloseDatabaseConnection();
            }
        }

        //DROP ALL TABLES IN DATABASE
        public static bool DropTables()
        {
            try
            {
                AdminManager.DropTable();
                StudentsManager.DropTable();
                PerpetratorsManager.DropTable();
                VictimsManager.DropTable();
                SettingsManager.DropTable();
                CrimesManager.DropTable();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                CloseDatabaseConnection();
            }
        }

        public static bool DropDatabase() 
        {
            try
            {
                String create_sql          = "DROP DATABASE IF EXITS " + DATABASE_NAME;
                sql_command                = new MySql.Data.MySqlClient.MySqlCommand();
                sql_command.Connection     = (MySqlConnection)database.OpenConnection();
                sql_command.CommandText    = create_sql;
                sql_command.Prepare();
                database.Update(sql_command);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally 
            {
                CloseDatabaseConnection();
            }
        
        }
    }
}
