using MetroFramework.Demo.Entitities;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;

namespace MetroFramework.Demo.Managers
{
    public class PerpetratorsManager : Manager
    {
        public static int PERPETRATOR_ID       = 0;
        private const string TABLE_NAME        = "PERPETRATORS";
        private const string PATH_TO_IMAGES    = "";
        private const int ID                   = 0;
        private const int NAME                 = 1;
        private const int PHOTOS_PATH          = 2;
        private const int IS_A_STUDENT         = 3;
        private const int IS_ACTIVE            = 4;
        private static int GENDER              = 5;
        private static int CREATED_AT          = 6;

        public static void CreateTable()
        {
            try
            {
                //sql statement
                String create_sql              = "CREATE TABLE IF NOT EXISTS " + TABLE_NAME + "  (ID INT AUTO_INCREMENT PRIMARY KEY,NAME VARCHAR(30),PHOTOS_PATH VARCHAR(30),IS_A_STUDENT VARCHAR(10),IS_ACTIVE VARCHAR(10),GENDER VARCHAR(10),CREATED_AT TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP)";

                //sql command
                sql_command                    = new MySqlCommand();
                sql_command.Connection         = (MySqlConnection)database.OpenConnection();
                sql_command.CommandText        = create_sql;
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
                //sql statement
                String drop_sql                = "DROP TABLE IF EXISTS " + TABLE_NAME;
                sql_command                    = new MySqlCommand();
                sql_command.Connection         = (MySqlConnection)database.OpenConnection();
                sql_command.CommandText        = drop_sql;
                sql_command.Prepare();

                //execute sql
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

        public static Perpetrator[] GetAllPerpetrators()
        {
            try
            {
                //select sql
                String select_sql              = "SELECT * FROM " + TABLE_NAME;

                //Sql command
                sql_command                    = new MySqlCommand();
                sql_command.Connection         = (MySqlConnection)database.OpenConnection();
                sql_command.CommandText        = select_sql;
                sql_command.Prepare();

                //get results in enum object
                data_reader                    = database.Select(sql_command);

                List<Perpetrator> perpetrators = new List<Perpetrator>();

                //loop thru em 
                while (data_reader.Read())
                {
                    //create new student

                    int id                     = data_reader.GetInt32(ID);
                    String name                = data_reader.GetString(NAME);
                    Bitmap[] faces             = GetPerpetratorFaces(data_reader.GetString(PHOTOS_PATH));
                    bool is_a_student          = data_reader.GetBoolean(IS_A_STUDENT);
                    bool is_active             = data_reader.GetBoolean(IS_ACTIVE);
                    String gender              = data_reader.GetString(GENDER);
                    String created_at          = data_reader.GetString(CREATED_AT);

                    Perpetrator perp           = new Perpetrator(id, name, faces, is_a_student, is_active, gender,created_at);

                    //add student to list
                    perpetrators.Add(perp);
                }

                //return array of results
                return perpetrators.ToArray();
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

        private static Bitmap[] GetPerpetratorFaces(string p)
        {
            throw new NotImplementedException();
        }

        public static Perpetrator[] GetAllActivePerpetrators()
        {
            try
            {
                //select sql
                String select_sql              = "SELECT * FROM " + TABLE_NAME + " IS_ACTIVE='true'";

                //Sql command
                sql_command                    = new MySqlCommand();
                sql_command.Connection         = (MySqlConnection)database.OpenConnection();
                sql_command.CommandText        = select_sql;
                sql_command.Prepare();

                //get results in enum object
                data_reader                    = database.Select(sql_command);

                List<Perpetrator> perpetrators = new List<Perpetrator>();

                //loop thru em 
                while (data_reader.Read())
                {
                    //create new student

                    int id                     = data_reader.GetInt32(ID);
                    String name                = data_reader.GetString(NAME);
                    Bitmap[] faces             = GetPerpetratorFaces(data_reader.GetString(PHOTOS_PATH));
                    bool is_a_student          = data_reader.GetBoolean(IS_A_STUDENT);
                    bool is_active             = data_reader.GetBoolean(IS_ACTIVE);
                    String gender              = data_reader.GetString(GENDER);
                    String created_at          = data_reader.GetString(CREATED_AT);

                    Perpetrator perp           = new Perpetrator(id, name, faces, is_a_student, is_active, gender,created_at);

                    //add student to list
                    perpetrators.Add(perp);
                }

                //return array of results
                return perpetrators.ToArray();
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



        public static bool Save(Perpetrator perp)
        {
            try
            {
                String path                    = "";
                String insert_sql              = "INSERT INTO " + TABLE_NAME + " (NAME,PHOTOS_PATH,IS_A_STUDENT,IS_ACTIVE,GENDER) values(@name,@path,@is_a_student,@is_active,@gender) ";

                //sql command
                sql_command                    = new MySqlCommand();
                sql_command.Connection         = (MySqlConnection)database.OpenConnection();
                sql_command.CommandText        = insert_sql;
                sql_command.Parameters.AddWithValue("@name", perp.name);
                sql_command.Parameters.AddWithValue("@path", path);
                sql_command.Parameters.AddWithValue("@is_a_student", ""+perp.is_a_student);
                sql_command.Parameters.AddWithValue("@is_active", ""+perp.is_still_active);
                sql_command.Parameters.AddWithValue("@gender", perp.gender);
       
                sql_command.Prepare();

                //execute query
                database.Insert(sql_command);

                perp.id = (int)sql_command.LastInsertedId;

                return true;
            }
            finally
            {
                database.CloseConnection();
            }
        }


        internal static void Delete(int perpetrator_id)
        {

        }

        public static bool Update(Perpetrator perp)
        {
            try
            {
                String update_sql              = "UPDATE " + TABLE_NAME + " SET NAME=@name ,PHOTOS_PATH=@path,IS_A_STUDENT=@student,IS_ACTIVE=@active,GENDER=@gender WHERE ID=@id";
                String path                    = "";

                //Sql command
                sql_command                    = new MySqlCommand();
                sql_command.Connection         = (MySqlConnection)database.OpenConnection();
                sql_command.CommandText        = update_sql;

                sql_command.Parameters.AddWithValue("@id", perp.id);
                sql_command.Parameters.AddWithValue("@name", perp.name);
                sql_command.Parameters.AddWithValue("@path", path);
                sql_command.Parameters.AddWithValue("@student", perp.is_a_student);
                sql_command.Parameters.AddWithValue("@active", perp.is_still_active);
                sql_command.Parameters.AddWithValue("@gender", perp.gender);

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
    }
}
