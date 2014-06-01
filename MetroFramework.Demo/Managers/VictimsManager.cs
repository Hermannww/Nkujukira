using MetroFramework.Demo.Entitities;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace MetroFramework.Demo.Managers
{
    class VictimsManager :Manager
    {
        public static int VICTIM_ID               = 0;
        private static string TABLE_NAME          = "VICTIMS";
        private const int ID                      = 0;
        private const int NAME                    = 1;
        private const int DOB                     = 2;
        private const int GENDER                  = 3;
        private const int IS_A_STUDENT            = 4;
        private const int CRIME_ID                = 5;
        private const int ITEMS_STOLEN            = 2;
        private const int NAME_OF_ITEM            = 1;
        private const int VICTIMS_ID              = 2;

        public static void CreateTable()
        {
            try
            {
                String create_sql = "CREATE TABLE IF NOT EXISTS " + TABLE_NAME + " (ID INT AUTO_INCREMENT PRIMARY KEY,NAME VARCHAR(30),DATE_OF_BIRTH VARCHAR(30),GENDER VARCHAR(10),CRIME_ID INT )";
                sql_command = new MySqlCommand();
                sql_command.Connection = (MySqlConnection)database.OpenConnection();
                sql_command.CommandText = create_sql;
                sql_command.Prepare();
                database.Update(sql_command);

                //create items stolen table
                create_sql = "CREATE TABLE IF NOT EXISTS STOLEN_ITEMS (ID INT AUTO_INCREMENT PRIMARY KEY,NAME_OF_ITEM VARCHAR(30),VICTIM_ID INT )";
                sql_command = new MySqlCommand();
                sql_command.Connection = (MySqlConnection)database.OpenConnection();
                sql_command.CommandText = create_sql;
                sql_command.Prepare();
                database.Update(sql_command);
            }
            finally
            {
                database.CloseConnection();
            }
        }

        public static void DropTable()
        {
            try
            {
                String drop_sql = "DROP TABLE IF EXISTS " + TABLE_NAME;
                sql_command = new MySqlCommand();
                sql_command.Connection = (MySqlConnection)database.OpenConnection();
                sql_command.CommandText = drop_sql;
                sql_command.Prepare();
                database.Update(sql_command);
            }
            finally
            {
                database.CloseConnection();
            }

        }

        public static void PopulateTable()
        {

        }


        public static Victim[] GetAllVictims()
        {
            try
            {
                //select sql
                String select_sql                 = "SELECT * FROM " + TABLE_NAME;

                sql_command                       = new MySqlCommand();
                sql_command.CommandText           = select_sql;
                sql_command.Prepare();

                //get results in enum object
                data_reader                       = database.Select(sql_command);

                List<Victim> victims              = new List<Victim>();

                //loop thru em 
                while (data_reader.Read())
                {
                    //create new student

                    int id                        = data_reader.GetInt32(ID);
                    String name                   = data_reader.GetString(NAME);
                    StolenItem[] items_stolen     = GetItemsStolen(data_reader.GetString(ITEMS_STOLEN));
                    bool is_a_student             = data_reader.GetBoolean(IS_A_STUDENT);
                    String gender                 = data_reader.GetString(GENDER);
                    String d_o_b                  = data_reader.GetString(DOB);
                    int crime_id                  = data_reader.GetInt32(CRIME_ID);

                    Victim victim                 = new Victim(id,name, d_o_b, items_stolen, gender, is_a_student, crime_id);

                    //add student to list
                    victims.Add(victim);
                }

                //return array of results
                return victims.ToArray();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);

            }
            finally
            {
                data_reader.Close();
            }
            return null;
        }

        public Victim GetVictim(int id) 
        {
            try
            {
                //select sql
                String select_sql                 = "SELECT * FROM " + TABLE_NAME + "WHERE ID=@id";

                sql_command                       = new MySqlCommand();
                sql_command.CommandText           = select_sql;
                sql_command.Parameters.AddWithValue("@id", id);
                sql_command.Prepare();
               

                //get results in enum object
                data_reader                       = database.Select(sql_command);

               

                //loop thru em 
                if (data_reader.Read())
                {
                    //create new victim

                    String name                   = data_reader.GetString(NAME);
                    StolenItem[] items_stolen     = GetItemsStolen(data_reader.GetString(ITEMS_STOLEN));
                    bool is_a_student             = data_reader.GetBoolean(IS_A_STUDENT);
                    String gender                 = data_reader.GetString(GENDER);
                    String d_o_b                  = data_reader.GetString(DOB);
                    int crime_id                  = data_reader.GetInt32(CRIME_ID);

                    Victim victim                 = new Victim(id,name, d_o_b, items_stolen, gender, is_a_student, crime_id);

                    return victim;
                }

            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);

            }
            finally
            {
                data_reader.Close();
            }
            return null;
        }

        private static StolenItem[] GetItemsStolen(string p)
        {
            return new StolenItem[] { };
        }

        public static bool Save(Victim victim)
        {
            return true;
        }

        public static bool Update(Victim victim)
        {
            String update_sql                     = "UPDATE " + TABLE_NAME + " SET NAME=@name ,DOB=@dob,IS_A_STUDENT=@student,GENDER=@gender,CRIME_ID=@crime_id WHERE ID=@id";
            
            //Sql command
            sql_command                           = new MySqlCommand();
            sql_command.CommandText               = update_sql;

            sql_command.Parameters.AddWithValue("@id", victim.id);
            sql_command.Parameters.AddWithValue("@name", victim.name);
            sql_command.Parameters.AddWithValue("@dob", victim.date_of_birth);
            sql_command.Parameters.AddWithValue("@student", victim.is_a_student);
            sql_command.Parameters.AddWithValue("@gender", victim.gender);
            sql_command.Parameters.AddWithValue("@crime_id", victim.crime_id);

            sql_command.Prepare();

            //execute command
            database.Update(sql_command);

            //update each stolen item
            foreach (var stolen_item in victim.items_stolen)
            {
               //sql statement
                update_sql                        = "UPDATE ITEMS_STOLEN SET NAME=@item_name WHERE ID=@id";

                //Sql command
                sql_command                       = new MySqlCommand();
                sql_command.CommandText           = update_sql;

                sql_command.Parameters.AddWithValue("@id", stolen_item.id);
                sql_command.Parameters.AddWithValue("@name", stolen_item.name_of_item);

                sql_command.Prepare();

                //execute command
                database.Update(sql_command);
            }
            return true;
        }
    }
}
