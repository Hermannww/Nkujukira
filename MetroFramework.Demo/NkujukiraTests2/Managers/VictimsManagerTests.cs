using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nkujukira.Demo.Managers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nkujukira.Demo.Entitities;
namespace Nkujukira.Demo.Managers.Tests
{
    [TestClass()]
    public class VictimsManagerTests
    {
        Victim[] all_victims;

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
            VictimsManager.CreateTable();
        }

        public void PopulateTable()
        {
            //WE GET ALL OBJECTS AT THE START ONLY INORDER TO REDUCE THE TIME TAKEN
            //TO RUN THE TESTS
            if (all_victims == null)
            {

                all_victims = VictimsManager.GetAllVictims();
            }

            foreach (var student in all_victims)
            {
                VictimsManager.Save(student);
            }
        }

        [TestCleanup]
        public void TearDown()
        {
            //AM THINKING THAT AFTER EACH TESt HAS RUN WE DISCARD THE CHANGES MADE THE CODE
            // AND RESTORE THE TABLE TO ITS ORIGINAL STATE
            if (all_victims != null)
            {
                VictimsManager.DropTable();
                CreateTableIfItDoesntExist();
                PopulateTable();
            }
        }


        [TestMethod()]
        public void VictimsManagerCreateTableTest()
        {
            bool sucess = VictimsManager.CreateTable();
            Assert.IsTrue(sucess);
        }

        [TestMethod()]
        public void VictimsManagerDropTableTest()
        {
            bool sucess = VictimsManager.DropTable();
            Assert.IsTrue(sucess);
        }

        [TestMethod()]
        public void VictimsManagerPopulateTableTest()
        {
            bool sucess = VictimsManager.PopulateTable();
            Assert.IsTrue(sucess);
        }

        [TestMethod()]
        public void VictimsManagerGetAllVictimsTest()
        {
            Victim[] victims = VictimsManager.GetAllVictims();
            Assert.IsNotNull(victims);
        }

        [TestMethod()]
        public void VictimsManagerGetVictimTest()
        {
            Victim victim = VictimsManager.GetVictim(1);
            Assert.IsNotNull(victim);
        }

        [TestMethod()]
        public void VictimsManagerSaveTest()
        {
            bool sucess = VictimsManager.Save(all_victims[0]);
            Assert.IsTrue(sucess);
        }

        [TestMethod()]
        public void VictimsManagerUpdateTest()
        {
            bool sucess = VictimsManager.Update(all_victims[0]);
            Assert.IsTrue(sucess);
        }

        [TestMethod()]
        public void VictimsManagerDeleteTest()
        {
            bool sucess = VictimsManager.Delete(all_victims[0].id);
            Assert.IsTrue(sucess);
        }

        [TestMethod()]
        public void VictimsManagerGetVictimsOfCrimeTest()
        {
            Victim[] victim = VictimsManager.GetVictimsOfCrime(all_victims[0].crime_id);
            Assert.IsNotNull(victim);
        }
    }
}
