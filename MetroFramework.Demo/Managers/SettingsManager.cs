﻿using MetroFramework.Demo.Entitities;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace MetroFramework.Demo.Managers
{
    public class SettingsManager: Manager
    {
        private static string TABLE_NAME;
        private static int VALUE;
        private static int ID;
        private static int NAME;


        public void CreateTable() 
        {
            String create_sql = "CREATE TABLE " + TABLE_NAME + " IF NOT EXISTS (ID INT AUTO_INCREMENT PRIMARY KEY,NAME VARCHAR(30),VALUE VARCHAR(30))";
            sql_command = new MySqlCommand();
            sql_command.Connection = (MySqlConnection)database.OpenConnection();
            sql_command.CommandText = create_sql;
            sql_command.Prepare();
            database.Update(sql_command);
        }

        public void DropTable() 
        {
            String drop_sql = "DROP TABLE " + TABLE_NAME + " IF EXISTS";
            sql_command = new MySqlCommand();
            sql_command.Connection = (MySqlConnection)database.OpenConnection();
            sql_command.CommandText = drop_sql;
            sql_command.Prepare();
            database.Update(sql_command);
        }

        public void PopulateTable() 
        {
        
        }

        public static Setting GetSetting(String setting_name)
        {
            //resultant object
            Setting setting = null;

            try
            {
                //sql
                String select_sql = "SELECT * FROM " + TABLE_NAME + " WHERE NAME=@name";

                //Sql command
                sql_command = new MySqlCommand();
                sql_command.Connection = (MySqlConnection)database.OpenConnection();
                sql_command.CommandText = select_sql;

                sql_command.Parameters.AddWithValue("@name", setting_name);
        
                sql_command.Prepare();

                //execute command
                data_reader = database.Select(sql_command);

                //while there are results
                if (data_reader.Read())
                {
                    //create object
                    String value = data_reader.GetString(VALUE);
                    int id = data_reader.GetInt32(ID);
                    setting = new Setting(id,setting_name,value);
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
            finally
            {
                //close reader
                data_reader.Close();
            }
            return setting;
        }

        public static Setting[] GetAllSettings() 
        {
            //resultant object
            List<Setting> settings = new List<Setting>();

            try
            {
                //sql
                String select_sql = "SELECT * FROM " + TABLE_NAME;

                //Sql command
                sql_command = new MySqlCommand();
                sql_command.CommandText = select_sql;
                sql_command.Prepare();

                //execute command
                data_reader = database.Select(sql_command);


                //while there are results
                if (data_reader.Read())
                {
                    //create object
                    String name = data_reader.GetString(NAME);
                    String value = data_reader.GetString(VALUE);
                    int id = data_reader.GetInt32(ID);

                    Setting setting = new Setting(id,name, value);

                    //add to list
                    settings.Add(setting);
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
            finally
            {
                //close reader
                data_reader.Close();
            }
            return settings.ToArray();
        }

        public static bool Save(Setting setting) 
        {
            //sql statement
            String insert_sql = "INSERT INTO " + TABLE_NAME + " (NAME,VALUE) values(@name,@value)";

            //Sql command
            sql_command = new MySqlCommand();
            sql_command.CommandText = insert_sql;

            sql_command.Parameters.AddWithValue("@name", setting.name);
            sql_command.Parameters.AddWithValue("@value", setting.value);
            
            sql_command.Prepare();

            //execute command
            database.Insert(sql_command);

            return true;
        }

        public static bool Delete(Setting setting) 
        {
            return false;
        }

        public static bool Update(Setting setting) 
        {
            String update_sql = "UPDATE " + TABLE_NAME + " SET NAME=@name ,VALUE=@value WHERE ID=@id";

            //Sql command
            sql_command = new MySqlCommand();
            sql_command.CommandText = update_sql;

            sql_command.Parameters.AddWithValue("@id", setting.id);
            sql_command.Parameters.AddWithValue("@name", setting.name);
            sql_command.Parameters.AddWithValue("@value", setting.value);

            sql_command.Prepare();

            //execute command
            database.Update(sql_command);
            return true;
        }
    }
}