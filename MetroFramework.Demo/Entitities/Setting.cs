using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MetroFramework.Demo.Entitities
{
    public class Setting : Entity
    {
        public static string DISABLE_LOGIN_COMPONENT="disable_login_compoent";


        public int id       { get; set; }

        public String name  { get; set; }

        public String value { get; set; }

        public Setting(int id, string setting_name, string value)
        {

            this.id    = id;
            this.name  = setting_name;
            this.value = value;
        }

        public Setting(string setting_name, string value)
        {

            this.name  = setting_name;
            this.value = value;
        }

        public bool GetValueAsBoolean()
        {
            return Convert.ToBoolean(value);
        }

        public int GetValueAsInt()
        {
            return Convert.ToInt32(value);
        }
    }
}
