using MetroFramework.Demo.Entitities;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace MetroFramework.Demo.Managers
{
    class VictimsManager : Manager
    {
        //fields for victims table
        private static string TABLE_NAME        = "VICTIMS";
        private const int ID                    = 0;
        private const int NAME                  = 1;
        private const int DOB                   = 2;
        private const int IS_A_STUDENT          = 3;
        private const int GENDER                = 4;
        private const int CRIME_ID              = 5;
      
      

        public static void CreateTable()
        {
            try
            {
                String create_sql               = "CREATE TABLE IF NOT EXISTS " + TABLE_NAME + " (ID INT AUTO_INCREMENT PRIMARY KEY,NAME VARCHAR(30),DATE_OF_BIRTH VARCHAR(30),IS_A_STUDENT VARCHAR(30),GENDER VARCHAR(10),CRIME_ID INT,CREATED_AT TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP)";
                sql_command                     = new MySqlCommand();
                sql_command.Connection          = (MySqlConnection)database.OpenConnection();
                sql_command.CommandText         = create_sql;
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
                String drop_sql                 = "DROP TABLE IF EXISTS " + TABLE_NAME;
                sql_command                     = new MySqlCommand();
                sql_command.Connection          = (MySqlConnection)database.OpenConnection();
                sql_command.CommandText         = drop_sql;
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
                String select_sql               = "SELECT * FROM " + TABLE_NAME;

                sql_command                     = new MySqlCommand();
                sql_command.Connection          = (MySqlConnection)database.OpenConnection();
                sql_command.CommandText         = select_sql;
                sql_command.Prepare();

                //get results in enum object
                data_reader                     = database.Select(sql_command);

                List<Victim> victims            = new List<Victim>();

                //loop thru em 
                while (data_reader.Read())
                {
                    //create new student

                    int id                      = data_reader.GetInt32(ID);
                    String name                 = data_reader.GetString(NAME);
                    StolenItem[] items_stolen   = null;
                    bool is_a_student           = data_reader.GetBoolean(IS_A_STUDENT);
                    String gender               = data_reader.GetString(GENDER);
                    String d_o_b                = data_reader.GetString(DOB);
                    int crime_id                = data_reader.GetInt32(CRIME_ID);

                    Victim victim               = new Victim(id, name, d_o_b, items_stolen, gender, is_a_student, crime_id);

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
                database.CloseConnection();
            }
            return null;
        }

        public Victim GetVictim(int id)
        {
            try
            {
                //select sql
                String select_sql               = "SELECT * FROM " + TABLE_NAME + "WHERE ID=@id";

                sql_command                     = new MySqlCommand();
                sql_command.Connection          = (MySqlConnection)database.OpenConnection();
                sql_command.CommandText         = select_sql;
                sql_command.Parameters.AddWithValue("@id", id);
                sql_command.Prepare();


                //get results in enum object
                data_reader                     = database.Select(sql_command);



                //loop thru em 
                if (data_reader.Read())
                {
                    //create new victim

                    String name                 = data_reader.GetString(NAME);
                    StolenItem[] items_stolen   = null;
                    bool is_a_student           = data_reader.GetBoolean(IS_A_STUDENT);
                    String gender               = data_reader.GetString(GENDER);
                    String d_o_b                = data_reader.GetString(DOB);
                    int crime_id                = data_reader.GetInt32(CRIME_ID);

                    Victim victim               = new Victim(id, name, d_o_b, items_stolen, gender, is_a_student, crime_id);

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
                database.CloseConnection();
            }
            return null;
        }

        

        public static bool Save(Victim victim)
        {
            try
            {
                String insert_sql               = "INSERT INTO " + TABLE_NAME + " (NAME,DATE_OF_BIRTH,IS_A_STUDENT,GENDER,CRIME_ID) VALUES(@name,@dob,@is_student,@gender,@crime_id)";

                //Sql command
                sql_command                     = new MySqlCommand();
                sql_command.Connection          = (MySqlConnection)database.OpenConnection();
                sql_command.CommandText         = insert_sql;

                sql_command.Parameters.AddWithValue("@name", victim.name);
                sql_command.Parameters.AddWithValue("@dob", victim.date_of_birth);
                sql_command.Parameters.AddWithValue("@is_student", "" + victim.is_a_student);
                sql_command.Parameters.AddWithValue("@gender", victim.gender);
                sql_command.Parameters.AddWithValue("@crime_id", victim.crime_id);
                sql_command.Prepare();

                database.Insert(sql_command);

                victim.id                       = Convert.ToInt32(sql_command.LastInsertedId);

               
            }
            finally
            {
                database.CloseConnection();
            }

            return true;
        }

        public static bool Update(Victim victim)
        {
            try
            {
                String update_sql               = "UPDATE " + TABLE_NAME + " SET NAME=@name ,DOB=@dob,IS_A_STUDENT=@student,GENDER=@gender,CRIME_ID=@crime_id WHERE ID=@id";

                //Sql command
                sql_command                     = new MySqlCommand();
                sql_command.Connection          = (MySqlConnection)database.OpenConnection();
                sql_command.CommandText         = update_sql;

                sql_command.Parameters.AddWithValue("@id", victim.id);
                sql_command.Parameters.AddWithValue("@name", victim.name);
                sql_command.Parameters.AddWithValue("@dob", victim.date_of_birth);
                sql_command.Parameters.AddWithValue("@student", victim.is_a_student);
                sql_command.Parameters.AddWithValue("@gender", victim.gender);
                sql_command.Parameters.AddWithValue("@crime_id", victim.crime_id);

                sql_command.Prepare();

                //execute command
                database.Update(sql_command);
            }
            finally
            {
                database.CloseConnection();
            }

            return true;
        }

        public static bool Delete(int crime_id)
        {
            try
            {
                String delete_sql               = "DELETE FROM " + TABLE_NAME + " WHERE CRIME_ID=@id";
                //Sql command
                sql_command                     = new MySqlCommand();
                sql_command.Connection          = (MySqlConnection)database.OpenConnection();
                sql_command.CommandText         = delete_sql;
                sql_command.Parameters.AddWithValue("@id", crime_id);
                sql_command.Prepare();

                //execute command
                database.Update(sql_command);
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message + "ERROR form Delete Method VictimsManager");
            }
            finally
            {
                data_reader.Close();
                database.CloseConnection();
            }
            return false;
        }

        public static Victim[] GetVictimsOfCrime(int crime_id) 
        {
            try
            {
                //select sql
                String select_sql               = "SELECT * FROM " + TABLE_NAME + " WHERE CRIME_ID=@id";

                sql_command                     = new MySqlCommand();
                sql_command.Connection          = (MySqlConnection)database.OpenConnection();
                sql_command.CommandText         = select_sql;
                sql_command.Parameters.AddWithValue("@id", crime_id);
                sql_command.Prepare();

                //get results in enum object
                data_reader                     = database.Select(sql_command);

                List<Victim> victims            = new List<Victim>();

                //loop thru em 
                while (data_reader.Read())
                {
                    //create new student

                    int id                      = data_reader.GetInt32(ID);
                    String name                 = data_reader.GetString(NAME);
                    StolenItem[] items_stolen   = null;
                    bool is_a_student           = data_reader.GetBoolean(IS_A_STUDENT);
                    String gender               = data_reader.GetString(GENDER);
                    String d_o_b                = data_reader.GetString(DOB);

                    Victim victim               = new Victim(id, name, d_o_b, items_stolen, gender, is_a_student, crime_id);

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
                database.CloseConnection();
            }
            return null;
        }
    }
}
