using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MetroFramework.Demo.FactoryMethod;
using MetroFramework.Demo.Entitities;

namespace MetroFramework.Demo.Factories
{
    class MySQLDataBaseHandler :DataBaseInterface
    {
        public bool openConnection() {
            return false;
        }
        public bool closeConnection()
        {
            return false;
        }
        public bool createTable()
        {
            return false;
        }
        public bool createNewUser(Admin user)
        {
            return false;
        }
        public bool userNameExists(String user_name)
        {
            return false;
        }
        public bool getUser(String user_name, String pass_word)
        {
            return false;
        }
        public bool userTableIsNotEmpty()
        {
            return false;
        }
        public bool changeUserRole(String id, String role)
        {
            return false;
        }
        public bool updateLoginCredentials(String default_user_name, String default_pass_word, String user_name, String pass_word)
        {
            return false;
        }
        public bool deleteUser(String id)
        {
            return false;
        }
        public bool createTableSystemUsers()
        {
            return false;
        }

    }
}
