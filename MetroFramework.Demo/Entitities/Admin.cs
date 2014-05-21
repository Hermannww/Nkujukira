using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MetroFramework.Demo.Entitities
{
    public class Admin
    {
        private String id;
        private String user_name;
        private String password;
        private String user_type;
        public Admin(String id, String user_name, String password, String user_type)
        {
            this.id = id;
            this.user_name = user_name;
            this.password = password;
            this.user_type = user_type;
        }
        public Admin(String user_name, String password, String user_type)
        {
            this.user_name = user_name;
            this.password = password;
            this.user_type = user_type;
        }
        public String getUserType()
        {
            return user_type;
        }
        public void setUserType(String user_type)
        {
            this.user_type = user_type;
        }
        public String getId()
        {
            return id;
        }
        public void setId(String id)
        {
            this.id = id;
        }
        public String getUserName()
        {
            return user_name;
        }
        public void setUserName(String user_name)
        {
            this.user_name = user_name;

        }
        public String getPassWord()
        {
            return password;
        }
        public void setPassWord(String password)
        {
            this.password = password;
        }
    }
}
