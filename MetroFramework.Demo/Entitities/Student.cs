using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MetroFramework.Demo.Entitities
{
    public class Student
    {
        private String firstName;
        private String middleName;
        private String lastName;
        private String studentNo;
        private String regNo;
        private String course;
        private String DOB;
        private String gender;
        private String photo;
        private byte[] imageData;

        public Student(String firstName,
                String middleName,
                String lastName,
                String studentNo,
                String regNo,
                String course,
                String DOB,
                String gender,
                String photo)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.middleName = middleName;
            this.studentNo = studentNo;
            this.regNo = regNo;
            this.course = course;
            this.DOB = DOB;
            this.gender = gender;
            this.photo = photo;

        }
        public Student(String firstName,
               String middleName,
               String lastName,
               String studentNo,
               String regNo,
               String course,
               String DOB,
               String gender,
               byte[] imageData)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.middleName = middleName;
            this.studentNo = studentNo;
            this.regNo = regNo;
            this.course = course;
            this.DOB = DOB;
            this.gender = gender;
            this.imageData = imageData;

        }

        public String getFirstName()
        {
            return firstName;
        }

        public void setFirstName(String firstName)
        {
            this.firstName = firstName;
        }

        public String getMiddleName()
        {
            return middleName;
        }

        public void setMiddleName(String middleName)
        {
            this.middleName = middleName;
        }

        public String getLastName()
        {
            return lastName;
        }

        public void setLastName(String lastName)
        {
            this.lastName = lastName;
        }

        public String getStudentNo()
        {
            return studentNo;
        }

        public void setStudentNo(String studentNo)
        {
            this.studentNo = studentNo;
        }

        public String getRegNo()
        {
            return regNo;
        }

        public void setRegNo(String regNo)
        {
            this.regNo = regNo;
        }

        public String getCourse()
        {
            return course;
        }

        public void setCourse(String course)
        {
            this.course = course;
        }

        public String getDOB()
        {
            return DOB;
        }

        public void setDOB(String DOB)
        {
            this.DOB = DOB;
        }

        public String getGender()
        {
            return gender;
        }

        public void setGender(String gender)
        {
            this.gender = gender;
        }

        public String getPhoto()
        {
            return photo;
        }

        public void setPhoto(String photo)
        {
            this.photo = photo;
        }

        public byte[] getImageData()
        {
            return imageData;
        }

        public void setImageData(byte[] imageData)
        {
            this.imageData = imageData;
        }
        public List<Student> getStudentDetails() {

            return null;
        }
    }

}
