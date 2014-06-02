using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MetroFramework.Demo.Entitities
{
    public class StolenItem:Entity
    {
        public int id { get; set; }
        public String name_of_item { get; set; }
        public int victims_id { get; set; }

        public StolenItem(int id,String name_of_item,int victims_id)
        {
            this.id           = id;
            this.name_of_item = name_of_item;
            this.victims_id   = victims_id;
        }

        public StolenItem(String name_of_item, int victims_id)
        {
            this.name_of_item = name_of_item;
            this.victims_id   = victims_id;
        }
       
    }
}
