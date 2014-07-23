using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nkujukira.Demo.Managers;
using Nkujukira.Demo.Entitities;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Nkujukira.Demo.Managers.Tests
{
    [TestClass()]
    public class AdminManagerTests
    {
        Admin[] all_admins=null;

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
            AdminManager.CreateTable();
        }

        public void PopulateTable() 
        {
            //WE GET ALL OBJECTS AT THE START ONLY INORDER TO REDUCE THE TIME TAKEN
            //TO RUN THE TESTS
            if (all_admins == null)
            {
                all_admins = AdminManager.GetAllAdmins();
            }

            foreach (var admin in all_admins)
            {
                AdminManager.Save(admin);
            }
        }

        [TestCleanup]
        public void TearDown() 
        {
            //AM THINKING THAT AFTER EACH TESt HAS RUN WE DISCARD THE CHANGES MADE BY THE CODE
            // AND RESTORE THE TABLE TO ITS ORIGINAL STATE
            AdminManager.DropTable();
            CreateTableIfItDoesntExist();
            PopulateTable();
        }

        [TestMethod()]
        public void AdminManagerCreateTableTest()
        {
            bool sucess=AdminManager.CreateTable();
            Assert.IsTrue(sucess);

        }

        [TestMethod()]
        public void AdminManagerDropTableTest()
        {
            bool success=AdminManager.DropTable();
            Assert.IsTrue(success);
            AdminManager.CreateTable();
        }

        [TestMethod()]
        public void AdminManagerPopulateTableTest()
        {
            bool sucess = AdminManager.PopulateTable();
            Assert.IsTrue(sucess);
        }

        [TestMethod()]
        public void AdminManagerGetAdminTest()
        {

            Admin admin=AdminManager.GetAdmin("nsubugak", "@llison");
            Assert.IsNotNull(admin);
        }

        [TestMethod()]
        public void AdminManagerExistsTest()
        {
            bool sucess = AdminManager.Exists("nsubugak");
            Assert.IsTrue(sucess);
        }

        [TestMethod()]
        public void AdminManagerGetAllAdminsTest()
        {
            Admin[] admins = AdminManager.GetAllAdmins();
            Assert.IsTrue(admins.Length >= 1);
        }

        [TestMethod()]
        public void AdminManagerSaveTest()
        {
            Admin admin=new Admin("kasoma","kasoma","admin");
            bool sucess = AdminManager.Save(admin);
            Assert.IsTrue(sucess);
        }

        [TestMethod()]
        public void AdminManagerDeleteTest()
        {
            bool sucess = AdminManager.Delete(new Admin("kasoma", "kasoma", "admin"));
            Assert.IsTrue(sucess);
        }

        [TestMethod()]
        public void AdminManagerUpdateTest()
        {
            bool sucess = AdminManager.Update(new Admin(1, "nsubugak", "@llison", "admin"));
            Assert.IsTrue(sucess);
        }
    }
}
