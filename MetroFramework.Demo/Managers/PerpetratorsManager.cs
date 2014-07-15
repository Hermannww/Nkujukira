using Emgu.CV;
using Emgu.CV.Structure;
using MetroFramework.Demo.Entitities;
using MetroFramework.Demo.Singletons;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Concurrent;
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
        public static int PERPETRATOR_ID            = 0;
        private const string TABLE_NAME             = "PERPETRATORS";
        private static string PATH_TO_IMAGES        = Singleton.RESOURCES_DIRECTORY + TABLE_NAME + @"\";
        private const int ID                        = 0;
        private const int NAME                      = 1;
        private const int IS_A_STUDENT              = 2;
        private const int IS_ACTIVE                 = 3;
        private static int GENDER                   = 4;
        private static int CREATED_AT               = 5;


        public static bool CreateTable()
        {
            try
            {
                //sql statement
                String create_sql                   = "CREATE TABLE IF NOT EXISTS " + TABLE_NAME +
                                                 " (ID INT AUTO_INCREMENT PRIMARY KEY," +
                                                 " NAME VARCHAR(30)," +
                                                 " IS_A_STUDENT VARCHAR(10)," +
                                                 " IS_ACTIVE VARCHAR(10)," +
                                                 " GENDER VARCHAR(10)," +
                                                 " CREATED_AT TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP)";

                //sql command
                sql_command                         = new MySqlCommand();
                sql_command.Connection              = (MySqlConnection)database.OpenConnection();
                sql_command.CommandText             = create_sql;
                sql_command.Prepare();

                //execute sql
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
                //sql statement
                String drop_sql                     = "DROP TABLE IF EXISTS " + TABLE_NAME;
                sql_command                         = new MySqlCommand();
                sql_command.Connection              = (MySqlConnection)database.OpenConnection();
                sql_command.CommandText             = drop_sql;
                sql_command.Prepare();

                //execute sql
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

        public static Perpetrator GetPerpetrator(int id)
        {
            try
            {
                //select sql
                String select_sql                   = "SELECT * FROM " + TABLE_NAME + " WHERE ID=@id";

                //Sql command
                sql_command                         = new MySqlCommand();
                sql_command.Connection              = (MySqlConnection)database.OpenConnection();
                sql_command.CommandText             = select_sql;

                sql_command.Parameters.AddWithValue("@id", "" + id);

                sql_command.Prepare();

                //get results in enum object
                data_reader                         = database.Select(sql_command);

                List<Perpetrator> perpetrators      = new List<Perpetrator>();

                //loop thru em 
                while (data_reader.Read())
                {

                    //create new student
                    String name                     = data_reader.GetString(NAME);
                    Image<Gray, byte>[] faces       = GetPerpetratorFaces(id);
                    bool is_a_student               = data_reader.GetBoolean(IS_A_STUDENT);
                    bool is_active                  = data_reader.GetBoolean(IS_ACTIVE);
                    String gender                   = data_reader.GetString(GENDER);
                    String created_at               = data_reader.GetString(CREATED_AT);

                    Perpetrator perp                = new Perpetrator(id, name, faces, is_a_student, is_active, gender, created_at);

                    //add student to list
                    perpetrators.Add(perp);
                }

                //return array of results
                return perpetrators.ToArray()[0];
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                data_reader.Close();
                database.CloseConnection();
            }

        }

        public static Perpetrator[] GetAllPerpetrators()
        {
            try
            {
                //select sql
                String select_sql                   = "SELECT * FROM " + TABLE_NAME;

                //Sql command
                sql_command                         = new MySqlCommand();
                sql_command.Connection              = (MySqlConnection)database.OpenConnection();
                sql_command.CommandText             = select_sql;
                sql_command.Prepare();

                //get results in enum object
                data_reader                         = database.Select(sql_command);

                List<Perpetrator> perpetrators      = new List<Perpetrator>();

                //loop thru em 
                while (data_reader.Read())
                {
                    //create new student

                    int id                          = data_reader.GetInt32(ID);
                    String name                     = data_reader.GetString(NAME);
                    Image<Gray, byte>[] faces       = GetPerpetratorFaces(id);
                    bool is_a_student               = data_reader.GetBoolean(IS_A_STUDENT);
                    bool is_active                  = data_reader.GetBoolean(IS_ACTIVE);
                    String gender                   = data_reader.GetString(GENDER);
                    String created_at               = data_reader.GetString(CREATED_AT);
                    Perpetrator perp                = new Perpetrator(id, name, faces, is_a_student, is_active, gender, created_at);

                    //add student to list
                    perpetrators.Add(perp);
                }

                //return array of results
                return perpetrators.ToArray();
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                data_reader.Close();
                database.CloseConnection();
            }

        }

        public static Image<Gray, byte>[] GetPerpetratorFaces(int id)
        {
            String path                             = PATH_TO_IMAGES + id + @"\";
            Image<Gray, byte>[] images              = FileManager.GetAllImagesInDirectory(path);
            return images;
        }

        public static Perpetrator[] GetAllActivePerpetrators()
        {
            try
            {
                //select sql
                String select_sql                   = "SELECT * FROM " + TABLE_NAME + " WHERE IS_ACTIVE='True'";

                //Sql command
                sql_command                         = new MySqlCommand();
                sql_command.Connection              = (MySqlConnection)database.OpenConnection();
                sql_command.CommandText             = select_sql;
                sql_command.Prepare();

                //get results in enum object
                data_reader                         = database.Select(sql_command);

                List<Perpetrator> perpetrators_list = new List<Perpetrator>();

                //loop thru em 
                while (data_reader.Read())
                {
                    //create new student

                    int id                          = data_reader.GetInt32(ID);
                    String name                     = data_reader.GetString(NAME);
                    Image<Gray, byte>[] faces       = GetPerpetratorFaces(id);
                    bool is_a_student               = data_reader.GetBoolean(IS_A_STUDENT);
                    bool is_active                  = data_reader.GetBoolean(IS_ACTIVE);
                    String gender                   = data_reader.GetString(GENDER);
                    String created_at               = data_reader.GetString(CREATED_AT);

                    Perpetrator perp                = new Perpetrator(id, name, faces, is_a_student, is_active, gender, created_at);

                    //add student to list
                    perpetrators_list.Add(perp);
                }



                //return array of results
                return perpetrators_list.ToArray();

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

                String insert_sql                   = "INSERT INTO " + TABLE_NAME +
                                                      " (NAME,IS_A_STUDENT,IS_ACTIVE,GENDER)"+
                                                      " values(@name,@is_a_student,@is_active,@gender) ";

                //sql command
                sql_command                         = new MySqlCommand();
                sql_command.Connection              = (MySqlConnection)database.OpenConnection();
                sql_command.CommandText             = insert_sql;
                sql_command.Parameters.AddWithValue("@name", perp.name);
                sql_command.Parameters.AddWithValue("@is_a_student", "" + perp.is_a_student);
                sql_command.Parameters.AddWithValue("@is_active", "" + perp.is_still_active);
                sql_command.Parameters.AddWithValue("@gender", perp.gender);

                sql_command.Prepare();

                //execute query
                database.Insert(sql_command);

                //set perp id
                perp.id                             = (int)sql_command.LastInsertedId;


                //create file path
                String path                         = PATH_TO_IMAGES + perp.id + @"\";

                //create folder for the perpetrator images
                FileManager.CreateFolderIfMissing(path);

                //save each face in that folder 
                for (int i= 0; i < perp.faces.Length; i++)
                {
                    //save using the perps name plus a unique number 
                    FileManager.SaveImage(path + perp.name + " " + i + ".png", perp.faces[i]);
                }

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


        public static bool Delete(int perpetrator_id)
        {
            try
            {
                //get the perp object associated with id
                Perpetrator perp                    = GetPerpetrator(perpetrator_id);

                if (perp != null)
                {
                    //Delete cached object as well
                    Singleton.Delete(perp);
                }

                String delete_sql                   = "DELETE FROM " + TABLE_NAME + " WHERE ID=@id";

                //Sql command
                sql_command                         = new MySqlCommand();
                sql_command.Connection              = (MySqlConnection)database.OpenConnection();
                sql_command.CommandText             = delete_sql;
                sql_command.Parameters.AddWithValue("@id", perpetrator_id);
                sql_command.Prepare();

                //execute command
                database.Update(sql_command);


                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public static bool Update(Perpetrator perp)
        {
            try
            {
                String update_sql                   = "UPDATE " + TABLE_NAME + " SET NAME=@name ,IS_A_STUDENT=@student,IS_ACTIVE=@active,GENDER=@gender WHERE ID=@id";

                //Sql command
                sql_command                         = new MySqlCommand();
                sql_command.Connection              = (MySqlConnection)database.OpenConnection();
                sql_command.CommandText             = update_sql;

                sql_command.Parameters.AddWithValue("@id", perp.id);
                sql_command.Parameters.AddWithValue("@name", perp.name);

                sql_command.Parameters.AddWithValue("@student", "" + perp.is_a_student);
                sql_command.Parameters.AddWithValue("@active", "" + perp.is_still_active);
                sql_command.Parameters.AddWithValue("@gender", perp.gender);

                sql_command.Prepare();

                //execute command
                database.Update(sql_command);

                Singleton.Update(perp);
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


    }
}
