using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace MetroFramework.Demo.Entitities
{
    public class Perpetrator
    {

        public int id                { get; set; }
        public string name           { get; set; }
        public Bitmap[] faces        { get; set; }
        public bool is_a_student     { get; set; }
        public bool is_still_active  { get; set; }
        public String gender         { get; set; }

        public Perpetrator(int id,Bitmap[] faces)
        {
            this.id = id;
            this.faces = faces;
        }

        public Perpetrator(int id1, string name1, Bitmap[] faces1, bool is_a_student1, bool is_active, string gender1)
        {
            // TODO: Complete member initialization
            this.id = id1;
            this.name = name1;
            this.faces = faces1;
            this.is_a_student = is_a_student1;
            this.is_still_active = is_active;
            this.gender = gender1;
        }
         
    }
}
