using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace MetroFramework.Demo.Entitities
{
    public class Perpetrator:Entity
    {

        public int id { get; set; }
        public string name { get; set; }
        public Image<Gray, byte>[] faces { get; set; }

        public bool is_a_student { get; set; }
        public bool is_still_active { get; set; }
        public String gender { get; set; }
        public String created_at { get; set; }



        public Perpetrator(Image<Gray, byte>[] faces, bool is_active, String gender)
        {
            this.is_still_active = is_active;
            this.gender = gender;
            this.faces = faces;

        }

        public Perpetrator(int id1, string name1, Image<Gray, byte>[] faces1, bool is_a_student1, bool is_active, string gender1, String created_at)
        {
            // TODO: Complete member initialization
            this.id = id1;
            this.name = name1;
            this.faces = faces1;
            this.is_a_student = is_a_student1;
            this.is_still_active = is_active;
            this.gender = gender1;
            this.created_at = created_at;
        }

    }
}
