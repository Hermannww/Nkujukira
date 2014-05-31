using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MetroFramework.Demo.Entitities
{
    public class Setting : Entity
    {
        
        public int id { get; set; }

        public String name { get; set; }

        public String value { get; set; }

        public Setting(int id1, string setting_name, string value1)
        {
            // TODO: Complete member initialization
            this.id = id1;
            this.name = setting_name;
            this.value = value1;
        }

        public bool GetValueAsBoolean() ///<exception cref="InvalidCastException"></exception>
        {
            return Convert.ToBoolean(value);
        }

        public int GetValueAsInt() 
        {
            return Convert.ToInt32(value);
        }
    }
}
