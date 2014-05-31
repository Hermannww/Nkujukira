using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MetroFramework.Demo.Entitities
{
    public class Admin
    {
        public String id        { get; set; }
        public String user_name { get; set; }
        public String password  { get; set; }
        public String user_type { get; set; }

        public Admin(String id, String user_name, String password, String user_type)
        {
            this.id        = id;
            this.user_name = user_name;
            this.password  = password;
            this.user_type = user_type;
        }
        public Admin(String user_name, String password, String user_type)
        {
            this.user_name = user_name;
            this.password  = password;
            this.user_type = user_type;
        }
    }
}
