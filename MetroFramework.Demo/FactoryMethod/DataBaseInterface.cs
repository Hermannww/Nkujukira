using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using MetroFramework.Demo.Entitities;
using System.Data;

namespace MetroFramework.Demo.FactoryMethod
{
    public interface DataBaseInterface
    {
        bool openConnection();

        bool closeConnection();

        bool createTableAdmin();
        bool createTableStudent();
        bool addStudent(Student student);
        List<Student> getStudentDetails();
        bool createNewUser(Admin user);
        bool userNameExists(String user_name);
        bool getUser(String user_name, String pass_word);
        bool userTableIsNotEmpty();
        bool changeUserRole(String id, String role);
        bool updateLoginCredentials(String default_user_name, String default_pass_word, String user_name, String pass_word);
        bool deleteUser(String id);
        DataTable generateUsersDataTable();
    }
}
