using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MetroFramework.Demo.Entitities
{
    public class StolenItem:Entity
    {
        public int id { get; set; }
        public int name_of_item { get; set; }
        public int victims_id { get; set; }

       
    }
}
