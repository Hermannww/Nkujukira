using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nkujukira.Demo.Managers;
using Nkujukira.Demo.Entitities;
using Emgu.CV;
using Emgu.CV.Structure;
using System.Diagnostics;

namespace Nkujukira.Demo.Managers.Tests
{
    [TestClass()]
    public class PerpetratorsManagerTests
    {
        Perpetrator[] all_perps;

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
            PerpetratorsManager.CreateTable();
        }

        public void PopulateTable()
        {
            //WE GET ALL OBJECTS AT THE START ONLY INORDER TO REDUCE THE TIME TAKEN
            //TO RUN THE TESTS
            if (all_perps == null)
            {
               
                all_perps = PerpetratorsManager.GetAllPerpetrators();
            }

            foreach (var perp in all_perps)
            {
                PerpetratorsManager.Save(perp);
            }
        }

        [TestCleanup]
        public void TearDown()
        {
            //AM THINKING THAT AFTER EACH TESt HAS RUN WE DISCARD THE CHANGES MADE THE CODE
            // AND RESTORE THE TABLE TO ITS ORIGINAL STATE
            if (all_perps != null)
            {
                PerpetratorsManager.DropTable();
                CreateTableIfItDoesntExist();
                PopulateTable();
            }
        }

        [TestMethod()]
        public void PerpetratorsManagerGetPerpetratorTest()
        {
            Perpetrator perp = PerpetratorsManager.GetPerpetrator(all_perps[0].id);
            Assert.IsNotNull(perp);
        }

        [TestMethod()]
        public void PerpetratorsManagerSaveTest()
        {
            bool sucess = PerpetratorsManager.Save(all_perps[0]);
            Assert.IsTrue(sucess);
        }

        [TestMethod()]
        public void PerpetratorsManagerUpdateTest()
        {
            bool sucess = PerpetratorsManager.Update(all_perps[0]);
            Assert.IsTrue(sucess);
        }

        [TestMethod()]
        public void PerpetratorsManagerDeleteTest()
        {
            bool sucess = PerpetratorsManager.Delete(all_perps[0].id);
            Assert.IsTrue(sucess);
        }

        [TestMethod()]
        public void PerpetratorsManagerCreateTableTest()
        {
            bool sucess=PerpetratorsManager.CreateTable();
            Assert.IsTrue(sucess);
        }

        [TestMethod()]
        public void PerpetratorsManagerDropTableTest()
        {
            bool sucess = PerpetratorsManager.DropTable();
            Assert.IsTrue(sucess);
        }

        [TestMethod()]
        public void PerpetratorsManagerPopulateTableTest()
        {
            bool sucess = PerpetratorsManager.PopulateTable();
            Assert.IsTrue(sucess);
        }   

        [TestMethod()]
        public void PerpetratorsManagerGetAllPerpetratorsTest()
        {
            Perpetrator[] perps = PerpetratorsManager.GetAllPerpetrators();
            Assert.IsNotNull(perps);
        }

        [TestMethod()]
        public void PerpetratorsManagerGetPerpetratorFacesTest()
        {
           Image<Bgr,byte>[] faces= PerpetratorsManager.GetPerpetratorFaces(1);
           Assert.IsNotNull(faces);
        }

        [TestMethod()]
        public void PerpetratorsManagerGetAllActivePerpetratorsTest()
        {
            Perpetrator[] perps = PerpetratorsManager.GetAllActivePerpetrators();
            Assert.IsNotNull(perps);
        }

        


    }
}
