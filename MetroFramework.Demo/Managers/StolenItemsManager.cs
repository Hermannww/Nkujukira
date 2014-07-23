using Nkujukira.Demo.Entitities;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Nkujukira.Demo.Managers
{
    public class StolenItemsManager:Manager
    {
        //fields for victims table
        private static string TABLE_NAME = "STOLEN_ITEMS";
        
        //fields for items stolen table
        private const int ID        = 0;
        private const int NAME_OF_ITEM   = 1;
        private const int VICTIMS_ID     = 2;

        public static bool CreateTable()
        {
            try
            {
                //create items stolen table
                String create_sql        = "CREATE TABLE IF NOT EXISTS STOLEN_ITEMS (ID INT AUTO_INCREMENT PRIMARY KEY,NAME_OF_ITEM VARCHAR(30),VICTIM_ID INT )";
                sql_command              = new MySqlCommand();
                sql_command.Connection   = (MySqlConnection)database.OpenConnection();
                sql_command.CommandText  = create_sql;
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
                database.CloseConnection();
            }
        }

        public static bool DropTable()
        {
            try
            {
                String drop_sql          = "DROP TABLE IF EXISTS " + TABLE_NAME;
                sql_command              = new MySqlCommand();
                sql_command.Connection   = (MySqlConnection)database.OpenConnection();
                sql_command.CommandText  = drop_sql;
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
                database.CloseConnection();
            }

        }

        public static bool PopulateTable()
        {
            try
            {
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static StolenItem[] GetVictimsStolenItems(int victim_id) 
        {
            List<StolenItem> stolen_items = new List<StolenItem>();
            try
            {
                //SELECT SQL
                String select_sql               = "SELECT * FROM " + TABLE_NAME + " WHERE VICTIM_ID=@id";

                sql_command                     = new MySqlCommand();
                sql_command.Connection          = (MySqlConnection)database.OpenConnection();
                sql_command.CommandText         = select_sql;
                sql_command.Parameters.AddWithValue("@id",victim_id);
                sql_command.Prepare();

                //GET RESULTS IN ENUM OBJECT
                data_reader                     = database.Select(sql_command);

               

                //LOOP THRU EM
                while (data_reader.Read())
                {
                    //CREATE STOLEN ITEM
                    int id                      = data_reader.GetInt32(ID);
                    String name_of_item         = data_reader.GetString(NAME_OF_ITEM);
                    
                    StolenItem stolen_item              = new StolenItem(id,name_of_item,victim_id);

                    //ADD ITEM TO LIST
                    stolen_items.Add(stolen_item);
                }

               
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);

            }
            finally
            {
                data_reader.Close();
                database.CloseConnection();
            }

            //RETURN ARRAY OF RESULTS
            return stolen_items.ToArray();
        
        }

        public static bool Save(StolenItem item) 
        {
            try
            {
                String insert_sql = "INSERT INTO " + TABLE_NAME + " (NAME_OF_ITEM,VICTIM_ID) VALUES(@name_of_item,@victim_id)";

                //Sql command
                sql_command = new MySqlCommand();
                sql_command.Connection = (MySqlConnection)database.OpenConnection();
                sql_command.CommandText = insert_sql;

                sql_command.Parameters.AddWithValue("@name_of_item", item.name_of_item);
                sql_command.Parameters.AddWithValue("@victim_id", item.victims_id);            
                sql_command.Prepare();

                database.Insert(sql_command);

                item.id = Convert.ToInt32(sql_command.LastInsertedId);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                database.CloseConnection();
            }
            
        }

        public static bool Update(StolenItem item) 
        {
            try
            {
                //sql statement
                String update_sql = "UPDATE ITEMS_STOLEN SET NAME=@item_name AND VICTIM_ID=@victim_id WHERE ID=@id";

                //Sql command
                sql_command = new MySqlCommand();
                sql_command.Connection = (MySqlConnection)database.OpenConnection();
                sql_command.CommandText = update_sql;

                sql_command.Parameters.AddWithValue("@id", item.id);
                sql_command.Parameters.AddWithValue("@victim_id", item.victims_id);
                sql_command.Parameters.AddWithValue("@name", item.name_of_item);

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
                database.CloseConnection();
            }
        }

        public static bool Delete(int id) 
        {
            try
            {
                String delete_sql = "DELETE FROM " + TABLE_NAME + " WHERE ID=@id";
                //Sql command
                sql_command = new MySqlCommand();
                sql_command.Connection = (MySqlConnection)database.OpenConnection();
                sql_command.CommandText = delete_sql;
                sql_command.Parameters.AddWithValue("@id", id);
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
                data_reader.Close();
                database.CloseConnection();
            }
        }
    }
}
