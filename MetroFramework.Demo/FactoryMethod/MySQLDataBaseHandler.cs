using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MetroFramework.Demo.FactoryMethod;
using MetroFramework.Demo.Entitities;
using MySql.Data.MySqlClient;
using System.Diagnostics;
using System.Data;

namespace MetroFramework.Demo.Factories
{
    class MySQLDataBaseHandler : DataBaseInterface
    {
        private MySqlConnection connection = null;
        private String server;
        private String dataBase;
        private String password;
        private String username;
        private String tableName;
        public  static bool firstUser = false;
        public String getTableName()
        {
            return tableName;
        }
        public void setTableName(String tableName)
        {
            this.tableName = tableName;
        }
        public void createTables()
        {
            createTableStudent();
            createTableAdmin();
        }
        public MySQLDataBaseHandler()
        {
            initialise();
            this.createTables();
            if (userTableIsNotEmpty())
            {
                Debug.WriteLine("\nTable SystemUsers is not Empty\n");
            }
            else
            {
                bool user_created = createNewUser(new Admin("admin", "123", "Admin"));
                if (user_created)
                {
                    firstUser = true;
                    Debug.WriteLine("New User created");
                }
                else
                {
                    Debug.WriteLine("No User created");
                }
            }
        }
        private void initialise()
        {
            try
            {
                server = "localhost";
                dataBase = "Nkujukira";
                username = "root";
                password = "";
                String connectionString = @"server=" + server + ";userid=" + username + ";password=" + password + ";database=" + dataBase;
                connection = new MySqlConnection(connectionString);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message + "ERROR from initialise method");
            }
        }
        public bool openConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Problem With the Open connection");
                Debug.WriteLine(ex.Message);
            }
            return false;
        }

        public bool closeConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Problem With the Close connection");
                Debug.WriteLine(ex.Message);
            }
            return false;
        }

        public bool createTableAdmin()
        {
            bool created = false;
            try
            {
                if (this.openConnection() == true)
                {
                    String query = "Create table SystemUsers(Id int auto_increment,Username varchar (30) not null,Password varchar (30) not null,UserType varchar (25) not null,Primary key(Id))";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    int rows = cmd.ExecuteNonQuery();
                    if (rows == 0)
                    {
                        Debug.WriteLine("System users table created");
                        created = true;
                    }

                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            finally
            {
                this.closeConnection();
            }
            return created;
        }

        public bool createTableStudent()
        {
            bool created = false;
            try
            {
                if (this.openConnection() == true)
                {
                    String query = "create Table Student("
                    + "FirstName varchar(30) not null,"
                    + "LastName varchar(30) not null,"
                    + "MiddleName varchar(30),"
                    + "StudentNo varchar(30) not null,"
                    + "RegNo varchar(30) not null,"
                    + "Course varchar(25) not null,"
                    + "DOB varchar(25) not null,"
                    + "Gender varchar(25) not null,"
                    + "Photo varchar(500) null)";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    int rows = cmd.ExecuteNonQuery();
                    if (rows == 0)
                    {
                        Debug.WriteLine("Students table created");
                        created = true;
                    }

                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message + "problem from the createTableStudent function");
            }
            finally
            {
                this.closeConnection();
            }
            return created;
        }

        public bool addStudent(Student student)
        {
            try
            {
                if (this.openConnection() == true)
                {
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandText = "insert into Student values(@FirstName,@LastName,@MiddleName,@StudentNo,@RegNo,@Course,@DOB,@Gender,@Photo)";
                    cmd.Prepare();
                    cmd.Parameters.AddWithValue("@FirstName", student.getFirstName());
                    cmd.Parameters.AddWithValue("@LastName", student.getLastName());
                    cmd.Parameters.AddWithValue("@MiddleName", student.getMiddleName());
                    cmd.Parameters.AddWithValue("@StudentNo", student.getStudentNo());
                    cmd.Parameters.AddWithValue("@RegNo", student.getRegNo());
                    cmd.Parameters.AddWithValue("@Course", student.getCourse());
                    cmd.Parameters.AddWithValue("@DOB", student.getDOB());
                    cmd.Parameters.AddWithValue("@Gender", student.getGender());
                    cmd.Parameters.AddWithValue("@Photo", student.getPhoto());
                    int rows = cmd.ExecuteNonQuery();
                    if (rows > 0)
                    {
                        this.closeConnection();
                        return true;
                    }

                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message + "Error from AddStudent Method");
            }
            return false;
        }
        public List<Student> getStudentDetails()
        {
            List<Student> list = new List<Student>();
            try
            {
                if (this.openConnection() == true)
                {
                    String query = "select * from Student";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        String firstName = dataReader.GetString("FirstName");
                        String middleName = dataReader.GetString("MiddleName");
                        String lastName = dataReader.GetString("LastName");
                        String studentNo = dataReader.GetString("StudentNo");
                        String regNo = dataReader.GetString("RegNo");
                        String course = dataReader.GetString("Course");
                        String DOB = dataReader.GetString("DOB");
                        String gender = dataReader.GetString("Gender");
                        String photo = dataReader.GetString("Photo");
                        list.Add(new Student(firstName, middleName, lastName, studentNo, regNo, course, DOB, gender, photo));
                    }
                    dataReader.Close();

                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message + "Image ERROR");
            }
            finally
            {
                this.closeConnection();
            }
            return list;
        }

        public DataTable generateUsersDataTable()
        {
            DataTable dataTable = new DataTable();
            try
            {
                dataTable.Columns.Add("ID");
                dataTable.Columns.Add("Name");
                dataTable.Columns.Add("Role");

                if (this.openConnection() == true)
                {
                    String query = "select * from SystemUsers";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        String id = dataReader.GetString("Id");
                        String user_name = dataReader.GetString("Username");
                        String password = dataReader.GetString("Password");
                        String user_type = dataReader.GetString("UserType");
                        dataTable.Rows.Add(id, user_name, user_type);
                    }
                    dataReader.Close();

                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            finally
            {
                this.closeConnection();
            }
            return dataTable;
        }
        public bool createNewUser(Admin user)
        {
            String user_name = user.getUserName();
            String pass_word = user.getPassWord();
            String user_type = user.getUserType();
            try
            {
                if (this.openConnection() == true)
                {
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandText = "insert into SystemUsers(Username,Password,UserType) values(@Username,@Password,@UserType)";
                    cmd.Prepare();
                    cmd.Parameters.AddWithValue("@Username", user_name);
                    cmd.Parameters.AddWithValue("@Password", pass_word);
                    cmd.Parameters.AddWithValue("@UserType", user_type);
                    int rows = cmd.ExecuteNonQuery();
                    if (rows > 0)
                    {
                        this.closeConnection();
                        return true;
                    }

                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return false;
        }
        public bool userNameExists(String user_name)
        {
            bool user_name_exists = false;
            try
            {
                if (this.openConnection() == true)
                {
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandText = "select * from SystemUsers where Username= @Username";
                    cmd.Prepare();
                    cmd.Parameters.AddWithValue("@Username", user_name);
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    if (dataReader.Read())
                    {
                        user_name_exists = true;
                    }
                    dataReader.Close();
                    this.closeConnection();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return user_name_exists;
        }
        public bool getUser(String user_name, String pass_word)
        {
            bool user_exists = false;
            try
            {
                if (this.openConnection() == true)
                {
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandText = "select * from SystemUsers where Username= @Username and Password= @Password";
                    cmd.Prepare();
                    cmd.Parameters.AddWithValue("@Username", user_name);
                    cmd.Parameters.AddWithValue("@Password", pass_word);
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    if (dataReader.Read())
                    {
                        user_exists = true;
                    }
                    dataReader.Close();
                    this.closeConnection();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return user_exists;
        }
        public bool userTableIsNotEmpty()
        {
            bool default_user_exists = false;
            try
            {
                if (this.openConnection() == true)
                {
                    String query = "select * from SystemUsers";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    if (dataReader.Read())
                    {
                        default_user_exists = true;
                    }
                    dataReader.Close();
                    this.closeConnection();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return default_user_exists;
        }
        public bool changeUserRole(String id, String role)
        {
            bool role_updated = false;
            try
            {

                if (this.openConnection() == true)
                {
                    MySqlCommand cmd = new MySqlCommand();
                    String query = "Update SystemUsers SET UserType=@userRole WHERE Id=@id";
                    cmd.Connection = connection;
                    cmd.Prepare();
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@UserRole", role);
                    cmd.Parameters.AddWithValue("@id", id);
                    int rows = cmd.ExecuteNonQuery();
                    if (rows > 0)
                    {
                        role_updated = true;
                    }

                    this.closeConnection();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return role_updated;

        }

        public bool updateLoginCredentials(String default_user_name, String default_pass_word, String user_name, String pass_word)
        {
            bool default_user_updated = false;
            try
            {
                if (this.openConnection() == true)
                {
                    MySqlCommand cmd = new MySqlCommand();
                    String query = "Update SystemUsers SET Username=@Username,Password=@Password WHERE Username=@Username_default and Password=@Password_default";
                    cmd.Connection = connection;
                    cmd.Prepare();
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@Username", user_name);
                    cmd.Parameters.AddWithValue("@Password", pass_word);
                    cmd.Parameters.AddWithValue("@Username_default", default_user_name);
                    cmd.Parameters.AddWithValue("@Password_default", default_pass_word);
                    int rows = cmd.ExecuteNonQuery();
                    if (rows > 0)
                    {
                        default_user_updated = true;
                    }

                    this.closeConnection();
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return default_user_updated;
        }

        public bool deleteUser(String id)
        {
            bool deleted = false;
            try
            {
                if (this.openConnection() == true)
                {
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandText = "delete from SystemUsers where id= @id";
                    cmd.Prepare();
                    cmd.Parameters.AddWithValue("@id", id);
                    int rows = cmd.ExecuteNonQuery();
                    if (rows > 0)
                    {
                        deleted = true;
                    }
                    this.closeConnection();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return deleted;
        }


       

    }
}
