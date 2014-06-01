using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MetroFramework.Demo.Entitities;
using MySql.Data.MySqlClient;
using System.Diagnostics;
using System.Data;
using System.Windows.Forms;
using System.IO;
using System.Collections;
using MetroFramework.Demo.Interfaces;
using System.Data.SqlClient;
using System.Data.Common;

namespace MetroFramework.Demo.DataStores
{
    class MySQLDatabaseHandler : DatabaseInterface
    {
        private MySqlConnection connection;
        private String server;
        private String database;
        private String password;
        private String username;



        public MySQLDatabaseHandler(String server, String database, String username, String password)
        {
            this.server   = server;
            this.database = database;
            this.username = username;
            this.password = password;
        }

        //open connection to database
        public DbConnection OpenConnection()
        {
            try
            {
                if (connection == null)
                {
                    string connection_string = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + username + ";" + "PASSWORD=" + password + ";";
                    connection               = new MySqlConnection(connection_string);
                    connection.Open();
                }
                return connection;
            }
            catch (MySqlException ex)
            {
                //When handling errors, you can your application's response based 
                //on the error number.
                //The two most common error numbers when connecting are as follows:
                //0: Cannot connect to server.
                //1045: Invalid user name and/or password.
                switch (ex.Number)
                {
                    case 0:
                        MessageBox.Show("Cannot connect to server.  Contact administrator");
                        break;

                    case 1045:
                        MessageBox.Show("Invalid username/password, please try again");
                        break;
                }
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        //Close connection
        public bool CloseConnection()
        {
            try
            {
                if (connection != null)
                {
                    connection.Close();
                    connection = null;
                }
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return false;
            }
        }

        //Insert statement
        public void Insert(DbCommand insert_query)
        {
            //open connection
            if (this.OpenConnection() != null)
            {
                
                insert_query.Connection = connection;
                insert_query.Prepare();

                //Execute command
                insert_query.ExecuteNonQuery();

                //close connection
                this.CloseConnection();
            }
        }

        //Update statement
        public void Update(DbCommand update_query)
        {
            try
            {
                //Open connection
                if (this.OpenConnection() != null)
                {


                    //Assign the query using CommandText
                    update_query.Connection = connection;

                    update_query.Prepare();

                    //Execute query
                    update_query.ExecuteNonQuery();

                    //close connection
                    this.CloseConnection();
                }
            }
            catch (Exception e) 
            {
                Debug.WriteLine(e.Message);
            }
        }

        //Delete statement
        public void Delete(DbCommand delete_query)
        {
            try
            {
                if (this.OpenConnection() != null)
                {
                    delete_query.Connection = connection;
                    delete_query.Prepare();
                    delete_query.ExecuteNonQuery();
                    this.CloseConnection();
                }
            }
            catch (Exception e) 
            {
                Debug.WriteLine(e.Message);
            }
        }

        //Select statement
        public IDataReader Select(DbCommand select_query)
        {
            try
            {
                //Open connection
                if (this.OpenConnection() != null)
                {
                    
                    //Create a data reader and Execute the commandC:\Users\ken\Documents\GitHub\Nkujukira\MetroFramework.Demo\Managers\
                    IDataReader data_reader = select_query.ExecuteReader();

                    
                    //return list to be displayed
                    return data_reader;
                }
               
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
           return null;
        }

        //Count statement
        public int Count(DbCommand query)
        {
            int Count = -1;

            //Open Connection
            if (this.OpenConnection() != null)
            {
                //Create Mysql Command
                query.Connection = connection;

                //ExecuteScalar will return one value
                Count            = int.Parse(query.ExecuteScalar() + "");

                //close Connection
                this.CloseConnection();

                return Count;
            }
            else
            {
                return Count;
            }
        }

        //Backup
        public void Backup()
        {

            try
            {
                DateTime Time              = DateTime.Now;
                int year                   = Time.Year;
                int month                  = Time.Month;
                int day                    = Time.Day;
                int hour                   = Time.Hour;
                int minute                 = Time.Minute;
                int second                 = Time.Second;
                int millisecond            = Time.Millisecond;

                //Save file to C:\ with the current date as a filename
                string path;
                path                       = "C:\\MySqlBackup" + year + "-" + month + "-" + day + "-" + hour + "-" + minute + "-" + second + "-" + millisecond + ".sql";
                StreamWriter file          = new StreamWriter(path);


                ProcessStartInfo psi       = new ProcessStartInfo();
                psi.FileName               = "mysqldump";
                psi.RedirectStandardInput  = false;
                psi.RedirectStandardOutput = true;
                psi.Arguments              = string.Format(@"-u{0} -p{1} -h{2} {3}", username, password, server, database);
                psi.UseShellExecute        = false;

                Process process            = Process.Start(psi);

                string output;
                output                     = process.StandardOutput.ReadToEnd();
                file.WriteLine(output);
                process.WaitForExit();
                file.Close();
                process.Close();
            }
            catch (IOException ex)
            {
                MessageBox.Show("Error , unable to backup!");
            }
        }

        //Restore
        public void Restore()
        {
            try
            {
                //Read file from C:\
                string path;
                path                       = "C:\\MySqlBackup.sql";
                StreamReader file          = new StreamReader(path);
                string input               = file.ReadToEnd();
                file.Close();

                ProcessStartInfo psi       = new ProcessStartInfo();
                psi.FileName               = "mysql";
                psi.RedirectStandardInput  = true;
                psi.RedirectStandardOutput = false;
                psi.Arguments              = string.Format(@"-u{0} -p{1} -h{2} {3}", username, password, server, database);
                psi.UseShellExecute        = false;


                Process process            = Process.Start(psi);
                process.StandardInput.WriteLine(input);
                process.StandardInput.Close();
                process.WaitForExit();
                process.Close();
            }
            catch (IOException ex)
            {
                MessageBox.Show("Error , unable to Restore!");
            }
        }
    }
}
