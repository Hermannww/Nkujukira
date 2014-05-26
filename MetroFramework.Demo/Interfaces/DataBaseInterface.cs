using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using MetroFramework.Demo.Entitities;

namespace MetroFramework.Demo.FactoryMethod
{
    public interface DataBaseInterface
    {
        public bool OpenConnection();
        public bool CloseConnection();
        public bool CreateTable();
        public bool CreateNewUser(Admin user);
        public bool UserNameExists(String user_name);
        public bool GetUser(String user_name, String pass_word);
        public bool UserTableIsNotEmpty();
        public bool ChangeUserRole(String id, String role);
        public bool UpdateLoginCredentials(String default_user_name, String default_pass_word, String user_name, String pass_word);
        public bool DeleteUser(String id);
        public bool CreateTableSystemUsers();
    }
}
