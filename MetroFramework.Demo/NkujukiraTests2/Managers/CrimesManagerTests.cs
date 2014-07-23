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
    public class CrimesManagerTests
    {
        Crime[] all_crimes=null;
        Crime crime = new Crime("today", "he stole laptop", "crime againist person", "theft", "15:00", "not availabe", 1);

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
            CrimesManager.CreateTable();
        }

        public void PopulateTable()
        {
            //WE GET ALL OBJECTS AT THE START ONLY INORDER TO REDUCE THE TIME TAKEN
            //TO RUN THE TESTS
            if (all_crimes == null)
            {

                all_crimes = CrimesManager.GetAllCrimes();
            }

            foreach (var crime in all_crimes)
            {
                CrimesManager.Save(crime);
            }
        }

        [TestCleanup]
        public void TearDown()
        {
            //AM THINKING THAT AFTER EACH TESt HAS RUN WE DISCARD THE CHANGES MADE THE CODE
            // AND RESTORE THE TABLE TO ITS ORIGINAL STATE
            if (all_crimes != null)
            {
                CrimesManager.DropTable();
                CreateTableIfItDoesntExist();
                PopulateTable();
            }
        }

        [TestMethod()]
        public void CrimesManagerCreateTableTest()
        {
            bool sucess = CrimesManager.CreateTable();
            Assert.IsTrue(sucess);
        }

        [TestMethod()]
        public void CrimesManagerDropTableTest()
        {
            bool sucess = CrimesManager.DropTable();
            Assert.IsTrue(sucess);
        }

        [TestMethod()]
        public void CrimesManagerPopulateTableTest()
        {
            bool sucess = CrimesManager.PopulateTable();
            Assert.IsTrue(sucess);
        }

        [TestMethod()]
        public void CrimesManagerSaveTest()
        {
            
            bool sucess = CrimesManager.Save(crime);
            Assert.IsTrue(sucess);
        }


        [TestMethod()]
        public void CrimesManagerGetCrimeTest()
        {
            
            bool sucess = CrimesManager.Save(crime);
            Crime a_crime = CrimesManager.GetCrime(crime.id);
            Assert.IsNotNull(a_crime);
        }

        [TestMethod()]
        public void CrimesManagerGetCrimesCommittedTest()
        {
            
            bool sucess = CrimesManager.Save(crime);
            Crime[] crimes = CrimesManager.GetCrimesCommitted(crime.perpetrator_id);
            Assert.IsNotNull(crimes);
        }

        [TestMethod()]
        public void CrimesManagerGetAllCrimesTest()
        {
            Crime[] crimes = CrimesManager.GetAllCrimes();
            Assert.IsNotNull(crimes);
        }

        [TestMethod()]
        public void CrimesManagerUpdateTest()
        {
            
            CrimesManager.Save(crime);
            bool sucess = CrimesManager.Update(crime);
            Assert.IsTrue(sucess);
        }

        [TestMethod()]
        public void CrimesManagerDeleteTest()
        {
           
            CrimesManager.Save(crime);
            bool sucess = CrimesManager.Delete(crime.id);
            Assert.IsTrue(sucess);
        }

        
       
    }
}
