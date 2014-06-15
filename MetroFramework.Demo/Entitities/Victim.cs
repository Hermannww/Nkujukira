using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MetroFramework.Demo.Entitities
{
    public class Victim
    {

        public int id                    { get; set; }
        public String name               { get; set; }
        public String date_of_birth      { get; set; }
        public StolenItem[] items_stolen { get; set; }
        public String gender             { get; set; }
        public bool is_a_student         { get; set; }
        public int crime_id              { get; set; }

        public Victim(int id,String name, String date_of_birth, StolenItem[] items_stolen, String gender, bool is_student, int crime_id) 
        {
            this.id            = id;
            this.name          = name;
            this.date_of_birth = date_of_birth;
            this.items_stolen  = items_stolen;
            this.gender        = gender;
            this.is_a_student  = is_student;
            this.crime_id      = crime_id;
        }

        public Victim(String name, String date_of_birth, StolenItem[] items_stolen, String gender, bool is_student, int crime_id)
        {
            this.name = name;
            this.date_of_birth = date_of_birth;
            this.items_stolen = items_stolen;
            this.gender = gender;
            this.is_a_student = is_student;
            this.crime_id = crime_id;
        }
    }
}
