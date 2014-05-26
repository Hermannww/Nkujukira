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
        public bool OpenConnection() {
            return false;
        }
        public bool CloseConnection()
        {
            return false;
        }
        public bool CreateTable()
        {
            return false;
        }
        public bool CreateNewUser(Admin user)
        {
            return false;
        }
        public bool UserNameExists(String user_name)
        {
            return false;
        }
        public bool GetUser(String user_name, String pass_word)
        {
            return false;
        }
        public bool UserTableIsNotEmpty()
        {
            return false;
        }
        public bool ChangeUserRole(String id, String role)
        {
            return false;
        }
        public bool UpdateLoginCredentials(String default_user_name, String default_pass_word, String user_name, String pass_word)
        {
            return false;
        }
        public bool DeleteUser(String id)
        {
            return false;
        }
        public bool CreateTableSystemUsers()
        {
            return false;
        }

    }
}
