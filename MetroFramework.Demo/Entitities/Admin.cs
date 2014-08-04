using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nkujukira.Demo.Entitities
{
    public class Admin
    {
        public int id { get; set; }
        public String user_name { get; set; }
        public String password { get; set; }
        public String user_type { get; set; }
        public String email { get; set; }
        public String phone_number { get; set; }

        public Admin(int id, String user_name, String password, String email, String phone_number, String user_type)
        {
            this.id           = id;
            this.user_name    = user_name;
            this.password     = password;
            this.user_type    = user_type;
            this.email        = email;
            this.phone_number = phone_number;
        }

        public Admin(String user_name, String password, String email, String phone_number, String user_type)
        {
            this.user_name    = user_name;
            this.password     = password;
            this.user_type    = user_type;
            this.email        = email;
            this.phone_number = phone_number;

        }
    }
}
