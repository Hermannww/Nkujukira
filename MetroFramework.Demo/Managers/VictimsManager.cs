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

        public static void CreateTable()
        {
            String create_sql                     = "CREATE TABLE " + TABLE_NAME + " IF NOT EXISTS (ID INT AUTO_INCREMENT PRIMARY KEY,NAME VARCHAR(30),DATE_OF_BIRTH VARCHAR(30),GENDER VARCHAR(10),CRIME_ID INT )";
            sql_command                           = new MySqlCommand();
            sql_command.Connection                = (MySqlConnection)database.OpenConnection();
            sql_command.CommandText               = create_sql;
            sql_command.Prepare();
            database.Update(sql_command);
        }

        public static void DropTable()
        {
            String drop_sql                       = "DROP TABLE " + TABLE_NAME + " IF EXISTS";
            sql_command                           = new MySqlCommand();
            sql_command.Connection                = (MySqlConnection)database.OpenConnection();
            sql_command.CommandText               = drop_sql;
            sql_command.Prepare();
            database.Update(sql_command);
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
                    String[] items_stolen         = GetItemsStolen(data_reader.GetString(ITEMS_STOLEN));
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
                    String[] items_stolen         = GetItemsStolen(data_reader.GetString(ITEMS_STOLEN));
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

        private static string[] GetItemsStolen(string p)
        {
            throw new NotImplementedException();
        }

        public static bool Save(Victim victim)
        {
            return true;
        }
    }
}
