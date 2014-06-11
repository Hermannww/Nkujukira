using MetroFramework.Demo.Entitities;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace MetroFramework.Demo.Managers
{
    class CrimesManager : Manager
    {
        public static int CRIME_ID = 0;
        private static string TABLE_NAME = "CRIMES";
        private int ID = 0;
        private int DATE = 1;
        private int TIME = 2;
        private int TYPE = 3;
        private int CRIME = 4;
        private int DETAILS = 5;
        private int PERPETRATOR_ID = 6;
        private int CREATED_AT = 7;


        public static void CreateTable()
        {
            try
            {
                //sql statement
                String create_sql = "CREATE TABLE IF NOT EXISTS " + TABLE_NAME + "  (ID INT AUTO_INCREMENT PRIMARY KEY,DATE VARCHAR(30),TIME VARCHAR(30),TYPE VARCHAR(10),CRIME VARCHAR(10),DETAILS VARCHAR(100),PERPETRATOR_ID INT,CREATED_AT TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP)";

                //sql command
                sql_command = new MySqlCommand();
                sql_command.Connection = (MySqlConnection)database.OpenConnection();
                sql_command.CommandText = create_sql;
                sql_command.Prepare();

                //execute sql
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

        public Crime GetCrime(int id)
        {
            try
            {
                //select sql
                String select_sql = "SELECT * FROM " + TABLE_NAME + " WHERE ID=@id";

                //Sql command
                sql_command = new MySqlCommand();
                sql_command.Connection = (MySqlConnection)database.OpenConnection();
                sql_command.CommandText = select_sql;
                sql_command.Parameters.AddWithValue("@id", id);
                sql_command.Prepare();

                //get results in enum object
                data_reader = database.Select(sql_command);

                List<Crime> crimes = new List<Crime>();

                //loop thru em 
                while (data_reader.Read())
                {
                    //create new student


                    String date = data_reader.GetString(DATE);
                    String time = data_reader.GetString(TIME);
                    String type = data_reader.GetString(TYPE);
                    String crime_committed = data_reader.GetString(CRIME);
                    String details = data_reader.GetString(DETAILS);
                    int perpetrator_id = data_reader.GetInt32(PERPETRATOR_ID);
                    String created_at = data_reader.GetString(CREATED_AT);

                    Crime crime = new Crime(date, details, type, crime_committed, time, perpetrator_id);

                    //add student to list
                    crimes.Add(crime);
                }

                //return array of results
                return crimes.ToArray()[0];
            }
            finally
            {
                data_reader.Close();
                database.CloseConnection();
            }
        }

        public Crime[] GetAllCrimes()
        {

            try
            {
                //select sql
                String select_sql = "SELECT * FROM " + TABLE_NAME;

                //Sql command
                sql_command = new MySqlCommand();
                sql_command.Connection = (MySqlConnection)database.OpenConnection();
                sql_command.CommandText = select_sql;

                sql_command.Prepare();

                //get results in enum object
                data_reader = database.Select(sql_command);

                List<Crime> crimes = new List<Crime>();

                //loop thru em 
                while (data_reader.Read())
                {
                    //create new student

                    int id = data_reader.GetInt32(ID);
                    String date = data_reader.GetString(DATE);
                    String time = data_reader.GetString(TIME);
                    String type = data_reader.GetString(TYPE);
                    String crime_committed = data_reader.GetString(CRIME);
                    String details = data_reader.GetString(DETAILS);
                    int perpetrator_id = data_reader.GetInt32(PERPETRATOR_ID);
                    String created_at = data_reader.GetString(CREATED_AT);

                    Crime crime = new Crime(id, date, details, type, crime_committed, time, perpetrator_id, created_at);

                    //add student to list
                    crimes.Add(crime);
                }

                //return array of results
                return crimes.ToArray();
            }
            finally
            {
                data_reader.Close();
                database.CloseConnection();
            }
        }

        internal static bool Save(Crime crime)
        {
            try
            {
                String path = "";
                String insert_sql = "INSERT INTO " + TABLE_NAME + " (DATE,TIME,TYPE,CRIME,DETAILS,PERPETRATOR_ID) values(@date,@time,@type,@crime,@details,@perp_id) ";

                //sql command
                sql_command = new MySqlCommand();
                sql_command.Connection = (MySqlConnection)database.OpenConnection();
                sql_command.CommandText = insert_sql;
                sql_command.Parameters.AddWithValue("@date", crime.date_of_crime);
                sql_command.Parameters.AddWithValue("@time", crime.time_of_crime);
                sql_command.Parameters.AddWithValue("@type", crime.type_of_crime);
                sql_command.Parameters.AddWithValue("@crime", crime.crime_committed);
                sql_command.Parameters.AddWithValue("@details", crime.details_of_crime);
                sql_command.Parameters.AddWithValue("@perp_id", crime.perpetrator_id);

                sql_command.Prepare();

                //execute query
                database.Insert(sql_command);

                crime.id = Convert.ToInt32(sql_command.LastInsertedId);

                return true;
            }
            finally
            {
                database.CloseConnection();
            }
        }

        public static bool Update(Crime crime)
        {
            try
            {
                String update_sql = "UPDATE " + TABLE_NAME + " SET DATE=@date ,TIME=@time,TYPE=@type,CRIME=@crime,DETAISL=@details,PERPETRATOR_ID=@perp_id WHERE ID=@id";
                String path = "";

                //Sql command
                sql_command = new MySqlCommand();
                sql_command.Connection = (MySqlConnection)database.OpenConnection();
                sql_command.CommandText = update_sql;

                sql_command.Parameters.AddWithValue("@date", crime.date_of_crime);
                sql_command.Parameters.AddWithValue("@time", crime.time_of_crime);
                sql_command.Parameters.AddWithValue("@type", crime.type_of_crime);
                sql_command.Parameters.AddWithValue("@crime", crime.crime_committed);
                sql_command.Parameters.AddWithValue("@details", crime.details_of_crime);
                sql_command.Parameters.AddWithValue("@perp_id", crime.perpetrator_id);

                sql_command.Prepare();

                //execute command
                database.Update(sql_command);
                return true;
            }
            finally
            {
                database.CloseConnection();
            }
        }

        public static bool Delete(int perpetrator_id)
        {
            try
            {
                String delete_sql = "DELETE FROM " + TABLE_NAME + " WHERE PERPETRATOR_ID=@id";
                //Sql command
                sql_command = new MySqlCommand();
                sql_command.Connection = (MySqlConnection)database.OpenConnection();
                sql_command.CommandText = delete_sql;
                sql_command.Parameters.AddWithValue("@id", perpetrator_id);
                sql_command.Prepare();

                //execute command
                database.Update(sql_command);
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message + "ERROR form Delete Method CrimesManager");
            }
            finally
            {
                data_reader.Close();
                database.CloseConnection();
            }
            return false;
        }

        public static int GetCrimeId(int perpetrator_id)
        {
            try
            {
                //select sql
                //String select_sql = "SELECT * FROM " + TABLE_NAME + "WHERE ID = @id";
                String select_sql = "Select ID from crimes where PERPETRATOR_ID = @id";
                

                sql_command = new MySqlCommand();
                sql_command.Connection = (MySqlConnection)database.OpenConnection();
                sql_command.CommandText = select_sql;
                sql_command.Parameters.AddWithValue("@id", perpetrator_id);

                sql_command.Prepare();


                //get results in enum object
                data_reader = database.Select(sql_command);

                //loop thru em 
                if (data_reader.Read())
                {
                    //create new victim
                    int id = data_reader.GetInt32(CRIME_ID);

                    return id;
                }
                
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message + "ERROR from GetCrimeId Crime Manager");

            }
            finally
            {
                data_reader.Close();
                database.CloseConnection();
            }
            return 0;

        }
    }
}
