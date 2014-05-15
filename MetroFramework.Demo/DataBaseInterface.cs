using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using MetroFramework.Demo.Entitities;

namespace MetroFramework.Demo.FactoryMethod
{
    interface DataBaseInterface
    {
        public bool openConnection();
        public bool closeConnection();
        public bool createTable();
        public bool createNewUser(SystemUser user);
        public bool userNameExists(String user_name);
        public bool getUser(String user_name, String pass_word);
        public bool userTableIsNotEmpty();
        public bool changeUserRole(String id, String role);
        public bool updateLoginCredentials(String default_user_name, String default_pass_word, String user_name, String pass_word);
        public bool deleteUser(String id);
        public bool createTableSystemUsers();
    }
}
