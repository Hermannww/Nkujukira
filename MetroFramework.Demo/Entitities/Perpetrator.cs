using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace MetroFramework.Demo.Entitities
{
    public class Perpetrator
    {
        public int id { get; set; }
        public string name { get; set; }
        public Bitmap[] faces { get; set; }
        public bool is_a_student { get; set; }
        public bool is_still_active { get; set; }
        public int crime_id { get; set; }

        public Perpetrator(int id,Bitmap[] faces)
        {
            this.id = id;
            this.faces = faces;
        }
         
    }
}
