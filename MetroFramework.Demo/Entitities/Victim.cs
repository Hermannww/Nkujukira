using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MetroFramework.Demo.Entitities
{
    class Victim
    {
        public String name           { get; set; }
        public String date_of_birth  { get; set; }
        public String[] items_stolen { get; set; }
        public String gender         { get; set; }
        public bool is_a_student     { get; set; }
        public String time_of_crime  { get; set; }
        public int crime_id          { get; set; }

        public Victim(String name, String date_of_birth, String[] items_stolen, String gender, bool is_student, String time_of_crime, int crime_id) 
        {
            this.name          = name;
            this.date_of_birth = date_of_birth;
            this.items_stolen  = items_stolen;
            this.gender        = gender;
            this.is_a_student  = is_student;
            this.time_of_crime = time_of_crime;
            this.crime_id      = crime_id;
        }
    }
}
