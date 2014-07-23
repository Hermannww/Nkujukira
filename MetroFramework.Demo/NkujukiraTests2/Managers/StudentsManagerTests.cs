using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nkujukira.Demo.Managers;
using Nkujukira.Demo.Entitities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Emgu.CV;
using Emgu.CV.Structure;

namespace Nkujukira.Demo.Managers.Tests
{
    [TestClass()]
    public class StudentsManagerTests
    {
        Student[] all_students;

        [TestInitialize]
        public void SetUp()
        {
            //AM THINKING THAT BEFORE WE RUN EACH TEST WE CREATE A NEW TABLE 
            //AND POPULATE IT WITH THE DUMMY DATA FOR THE TEST
            CreateTableIfItDoesntExist();
            PopulateTable();

        }

        public void CreateTableIfItDoesntExist()
        {
            StudentsManager.CreateTable();
        }

        public void PopulateTable()
        {
            //WE GET ALL OBJECTS AT THE START ONLY INORDER TO REDUCE THE TIME TAKEN
            //TO RUN THE TESTS
            if (all_students == null)
            {

                all_students = StudentsManager.GetAllStudents();
            }

            foreach (var student in all_students)
            {
                StudentsManager.Save(student);
            }
        }

        [TestCleanup]
        public void TearDown()
        {
            //AM THINKING THAT AFTER EACH TESt HAS RUN WE DISCARD THE CHANGES MADE THE CODE
            // AND RESTORE THE TABLE TO ITS ORIGINAL STATE
            if (all_students != null)
            {
                StudentsManager.DropTable();
                CreateTableIfItDoesntExist();
                PopulateTable();
            }
        }

        [TestMethod()]
        public void StudentsManagerCreateTableTest()
        {
            bool sucess = StudentsManager.CreateTable();
            Assert.IsTrue(sucess);
        }

        [TestMethod()]
        public void StudentsManagerDropTableTest()
        {
            bool sucess = StudentsManager.DropTable();
            Assert.IsTrue(sucess);
        }

        [TestMethod()]
        public void StudentsManagerPopulateTableTest()
        {
            bool sucess = StudentsManager.PopulateTable();
            Assert.IsTrue(sucess);
        }

        [TestMethod()]
        public void StudentsManagerGetAllStudentsTest()
        {
            Student[] students = StudentsManager.GetAllStudents();
            Assert.IsNotNull(students);
        }

        [TestMethod()]
        public void StudentsManagerGetStudentTest()
        {
            Student student = StudentsManager.GetStudent(all_students[0].id);
            Assert.IsNotNull(student);
        }

        [TestMethod()]
        public void StudentsManagerSaveTest()
        {
            bool sucess = StudentsManager.Save(all_students[0]);
            Assert.IsTrue(sucess);
        }

        [TestMethod()]
        public void StudentsManagerDeleteTest()
        {
            bool sucess = StudentsManager.Delete(all_students[0].id);
            Assert.IsTrue(sucess);
        }

        [TestMethod()]
        public void StudentsManagerUpdateTest()
        {
            bool sucess = StudentsManager.Update(all_students[0]);
            Assert.IsTrue(sucess);
        }

        [TestMethod()]
        public void StudentsManagerGetStudentPhotosTest()
        {
            Image<Bgr, byte>[] faces = StudentsManager.GetStudentPhotos(1);
            Assert.IsNotNull(faces);
        }
    }
}
