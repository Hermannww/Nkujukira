using Nkujukira.Demo.Entitities;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Nkujukira.Demo.Managers
{
    public class SettingsManager: Manager
    {
        private const string TABLE_NAME ="SETTINGS";
        private const int VALUE         =2;
        private const int ID            =0;
        private const int NAME          =1;

        public enum SETTINGS 
        {
            SIMILARITY_THRESHOLD,
            MINIMUM_NUMBER_OF_FACES_ALLOWED,
            THEME
        }


        public static bool CreateTable() 
        {
            try
            {
                String create_sql = "CREATE TABLE IF NOT EXISTS " + TABLE_NAME + " (ID INT AUTO_INCREMENT PRIMARY KEY,NAME VARCHAR(30),VALUE VARCHAR(30),CREATED_AT TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP)";
                sql_command             = new MySqlCommand();
                sql_command.Connection  = (MySqlConnection)database.OpenConnection();
                sql_command.CommandText = create_sql;
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

        public static bool DropTable() 
        {
            try
            {
                String drop_sql         = "DROP TABLE IF EXISTS " + TABLE_NAME;
                sql_command             = new MySqlCommand();
                sql_command.Connection  = (MySqlConnection)database.OpenConnection();
                sql_command.CommandText = drop_sql;
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

        public static bool PopulateTable() 
        {
            try
            {
                Setting similarity_threshold = new Setting("similarity_threshold", "70");
                Setting theme                = new Setting("theme", "Dark");
                SettingsManager.Save(similarity_threshold);
                SettingsManager.Save(theme);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static Setting GetSetting(SETTINGS settings_name)
        {
            String setting_name = GetSettingsName(settings_name);

            //resultant object
            Setting setting             = null;

            try
            {
                //sql
                String select_sql       = "SELECT * FROM " + TABLE_NAME + " WHERE NAME=@name";

                //Sql command
                sql_command             = new MySqlCommand();
                sql_command.Connection  = (MySqlConnection)database.OpenConnection();
                sql_command.CommandText = select_sql;

                sql_command.Parameters.AddWithValue("@name", setting_name);
        
                sql_command.Prepare();

                //execute command
                data_reader             = database.Select(sql_command);

                //while there are results
                if (data_reader.Read())
                {
                    //create object
                    String value        = data_reader.GetString(VALUE);
                    int id              = data_reader.GetInt32(ID);
                    setting             = new Setting(id,setting_name,value);
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
            finally
            {
                //close reader
                CloseDatabaseConnection();
            }
            return setting;
        }

        private static string GetSettingsName(SETTINGS settings_name)
        {
            switch (settings_name) 
            {
                case SETTINGS.SIMILARITY_THRESHOLD:
                    return "similarity_threshold";
                case SETTINGS.THEME:
                    return "theme";
                case SETTINGS.MINIMUM_NUMBER_OF_FACES_ALLOWED:
                    return "minimum_faces";

            }
            return null;
        }

        public static Setting[] GetAllSettings() 
        {
            //resultant object
            List<Setting> settings      = new List<Setting>();

            try
            {
                //sql
                String select_sql       = "SELECT * FROM " + TABLE_NAME;

                //Sql command
                sql_command             = new MySqlCommand();
                sql_command.CommandText = select_sql;
                sql_command.Prepare();

                //execute command
                data_reader             = database.Select(sql_command);


                //while there are results
                if (data_reader.Read())
                {
                    //create object
                    String name         = data_reader.GetString(NAME);
                    String value        = data_reader.GetString(VALUE);
                    int id              = data_reader.GetInt32(ID);

                    Setting setting     = new Setting(id,name, value);

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
                CloseDatabaseConnection();
            }
            return settings.ToArray();
        }

        public static bool Save(Setting setting) 
        {
            try
            {
                //sql statement
                String insert_sql       = "INSERT INTO " + TABLE_NAME + " (NAME,VALUE) values(@name,@value)";

                //Sql command
                sql_command             = new MySqlCommand();
                sql_command.CommandText = insert_sql;
                sql_command.Connection  = (MySqlConnection)database.OpenConnection();
                sql_command.Parameters.AddWithValue("@name", setting.name);
                sql_command.Parameters.AddWithValue("@value", setting.value);

                sql_command.Prepare();

                //execute command
                database.Insert(sql_command);

                setting.id = Convert.ToInt32(sql_command.LastInsertedId);

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

        public static bool Delete(int id)
        {
            try
            {
                //insert sql
                String delete_sql = "DELETE FROM " + TABLE_NAME + " WHERE ID=@id";

                //Sql command
                sql_command = new MySqlCommand();
                sql_command.Connection = (MySqlConnection)database.OpenConnection();
                sql_command.CommandText = delete_sql;

                sql_command.Parameters.AddWithValue("@id", id);

                sql_command.Prepare();


                //get results in enum object
                database.Delete(sql_command);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally { CloseDatabaseConnection(); }
        }

        public static bool Update(Setting setting) 
        {
            try
            {
                String update_sql       = "UPDATE " + TABLE_NAME + " SET NAME=@name ,VALUE=@value WHERE ID=@id";

                //Sql command
                sql_command             = new MySqlCommand();
                sql_command.Connection  = (MySqlConnection)database.OpenConnection();
                sql_command.CommandText = update_sql;

                sql_command.Parameters.AddWithValue("@name", setting.name);
                sql_command.Parameters.AddWithValue("@value", setting.value);
                sql_command.Parameters.AddWithValue("@id", setting.id);
                sql_command.Prepare();

                //execute command
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
