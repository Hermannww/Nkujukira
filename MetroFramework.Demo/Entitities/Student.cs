using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace MetroFramework.Demo.Entitities
{
    public class Student
    {
        public int id { get; set; }
        public String firstName { get; set; }
        public String middleName { get; set; }
        public String lastName { get; set; }
        public String studentNo { get; set; }
        public String regNo { get; set; }
        public String course { get; set; }
        public String DOB { get; set; }
        public String gender { get; set; }
        public Bitmap[] photos { get; set; }
       

        public Student(String firstName, String middleName, String lastName, String studentNo, String regNo, String course, String DOB, String gender, Bitmap[] photos)
        {
            this.firstName  = firstName;
            this.lastName   = lastName;
            this.middleName = middleName;
            this.studentNo  = studentNo;
            this.regNo      = regNo;
            this.course     = course;
            this.DOB        = DOB;
            this.gender     = gender;
            this.photos     = photos;
        }

        public Student(int id,String firstName, String middleName, String lastName, String studentNo, String regNo, String course, String DOB, String gender, Bitmap[] photos)
        {
            this.id         = id;
            this.firstName  = firstName;
            this.lastName   = lastName;
            this.middleName = middleName;
            this.studentNo  = studentNo;
            this.regNo      = regNo;
            this.course     = course;
            this.DOB        = DOB;
            this.gender     = gender;
            this.photos     = photos;
        }
    }

}
