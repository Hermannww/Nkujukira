using Nkujukira.Demo.Entitities;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Nkujukira.Demo.DataStores;

namespace Nkujukira.Demo.Managers
{
    public class AdminManager : Manager
    {
        public const String TABLE_NAME             = "ADMINISTRATORS";
        public const int USERNAME                  = 1;
        public const int PASSWORD                  = 2;
        public const int TYPE                      = 3;
        private static int ID                      = 0;
        private static int EMAIL;
        private static int PHONE;

        public static bool CreateTable()
        {
            try
            {
                //sql string
                String create_sql                = "CREATE TABLE IF NOT EXISTS " + TABLE_NAME +
                                                   " (ID INT AUTO_INCREMENT PRIMARY KEY,"+
                                                   "USERNAME VARCHAR(30),"+
                                                   "PASSWORD VARCHAR(30),"+
                                                   "EMAIL VARCHAR(30)," +
                                                   "PHONE_NUMBER VARCHAR(30)," +
                                                   "USERTYPE VARCHAR(10) )";
                //create sql command
                sql_command                        = new MySqlCommand();
                sql_command.Connection             = (MySqlConnection)database.OpenConnection();
                sql_command.CommandText            = create_sql;
                //prepare sql statement
                sql_command.Prepare();
                //execute sql statement
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
                //sql string
                String drop_sql                    = "DROP TABLE IF EXISTS " + TABLE_NAME;
                //sql command
                sql_command                        = new MySqlCommand();
                sql_command.Connection             = (MySqlConnection)database.OpenConnection();
                sql_command.CommandText            = drop_sql;
                //prepare sql statement
                sql_command.Prepare();
                //exceute statemet
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
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public static Admin GetAdmin(String username, String password)
        {
            //resultant object
            Admin admin                            = null;

            try
            {
                //sql
                String select_sql                  = "SELECT * FROM " + TABLE_NAME +
                                                     " WHERE USERNAME=@username AND PASSWORD=@password";

                //Sql command
                sql_command                        = new MySqlCommand();
                sql_command.Connection             = (MySqlConnection)database.OpenConnection();
                sql_command.CommandText            = select_sql;

                sql_command.Parameters.AddWithValue("@username", username);
                sql_command.Parameters.AddWithValue("@password", password);
                sql_command.Prepare();

                //execute command
                data_reader                        = database.Select(sql_command);

                //while there are results
                if (data_reader.Read())
                {
                    //create object
                    int id                         = data_reader.GetInt32(ID);
                    String type                    = data_reader.GetString(TYPE);
                    String email                   = data_reader.GetString(EMAIL);
                    String phone_number            = data_reader.GetString(PHONE);
                    admin                          = new Admin(id, username, password,email,phone_number, type);
                }
            }
            catch (CantAcessDatabaseException)
            {
                throw;
            }
            catch (Exception) 
            {
            
            }
            finally
            {
                //close reader
                CloseDatabaseConnection();
            }
            return admin;
        }


        public static bool Exists(String username)
        {

            try
            {
                //sql
                String select_sql                  = "SELECT * FROM " + TABLE_NAME + " WHERE USERNAME=@username";

                //Sql command
                sql_command                        = new MySqlCommand();
                sql_command.Connection             = (MySqlConnection)database.OpenConnection();
                sql_command.CommandText            = select_sql;

                sql_command.Parameters.AddWithValue("@username", username);
                sql_command.Prepare();

                //execute command
                data_reader                        = database.Select(sql_command);

                //while there are results
                if (data_reader.Read())
                {
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                CloseDatabaseConnection();
            }
            return false;
        }

        public static Admin[] GetAllAdmins()
        {
            //results object
            List<Admin> all_admins                 = new List<Admin>();

            try
            {
                //sql string
                String select_sql                  = "SELECT * FROM " + TABLE_NAME;

                //Sql command
                sql_command                        = new MySqlCommand();
                sql_command.Connection             = (MySqlConnection)database.OpenConnection();
                sql_command.CommandText            = select_sql;
                sql_command.Prepare();

                //execute command
                data_reader                        = database.Select(sql_command);

                //while there are results
                if (data_reader.Read())
                {
                    //create object
                    int id                         = data_reader.GetInt32(ID);
                    String username                = data_reader.GetString(USERNAME);
                    String password                = data_reader.GetString(PASSWORD);
                    String type                    = data_reader.GetString(TYPE);
                    String email                   = data_reader.GetString(EMAIL);
                    String phone_number            = data_reader.GetString(PHONE);
                    Admin admin                    = new Admin(id, username, password,email,phone_number, type);
                    all_admins.Add(admin);
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
            finally
            {
                CloseDatabaseConnection();
            }
            return all_admins.ToArray();
        }

        public static bool Save(Admin admin)
        {
            try
            {

                String insert_sql = "INSERT INTO " + TABLE_NAME +
                                    " (USERNAME,PASSWORD,EMAIL,PHONE_NUMBER,USERTYPE)"+
                                    " values(@username,@password,@email,@phone,@usertype)";
                //Sql command
                sql_command                        = new MySqlCommand();
                sql_command.Connection             = (MySqlConnection)database.OpenConnection();
                sql_command.CommandText            = insert_sql;
                //add parameters
                sql_command.Parameters.AddWithValue("@username", admin.user_name);
                sql_command.Parameters.AddWithValue("@password", admin.password);
                sql_command.Parameters.AddWithValue("@email", admin.email);
                sql_command.Parameters.AddWithValue("@phone", admin.phone_number);
                sql_command.Parameters.AddWithValue("@usertype", admin.user_type);
                sql_command.Prepare();
                //execute command
                database.Insert(sql_command);
                //get id of admin
                admin.id                           = Convert.ToInt32(sql_command.LastInsertedId);
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

        public static bool Delete(Admin admin)
        {
            try
            {
                String delete_sql= "DELETE FROM " + TABLE_NAME + 
                                    "WHERE ID=@id";
                //Sql command
                sql_command                        = new MySqlCommand();
                sql_command.Connection             = (MySqlConnection)database.OpenConnection();
                sql_command.CommandText            = delete_sql;
                //add parameters
                sql_command.Parameters.AddWithValue("@id", admin.id);
                
                //create prepared statement
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

        public static bool Update(Admin admin)
        {
            try
            {
                //sql string
                String update_sql = "UPDATE " + TABLE_NAME +
                                    " SET USERNAME =@username,"+
                                    "PASSWORD      =@password,"+
                                    "USERTYPE      =@type"+
                                    " WHERE ID     =@id";
                //Sql command
                sql_command                        = new MySqlCommand();
                sql_command.Connection             = (MySqlConnection)database.OpenConnection();
                sql_command.CommandText            = update_sql;
                //Add paramaters
                sql_command.Parameters.AddWithValue("@id", admin.id);
                sql_command.Parameters.AddWithValue("@username", admin.user_name);
                sql_command.Parameters.AddWithValue("@password", admin.password);
                sql_command.Parameters.AddWithValue("@type", admin.user_type);
                //prepare sql statemet
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
