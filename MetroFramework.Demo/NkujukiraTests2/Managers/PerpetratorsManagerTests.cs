using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetroFramework.Demo.Managers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MetroFramework.Demo.Entitities;
namespace MetroFramework.Demo.Managers.Tests
{
    [TestClass()]
    public class PerpetratorsManagerTests
    {
        Perpetrator[] all_perps;

        [TestMethod()]
        public void GetPerpetratorTest()
        {
            Perpetrator perp = PerpetratorsManager.GetPerpetrator(1);
            Assert.IsNotNull(perp);
        }

        [TestMethod()]
        public void SaveTest()
        {
            bool sucess = PerpetratorsManager.Save(all_perps[0]);
            Assert.IsTrue(sucess);
        }

        [TestMethod()]
        public void UpdateTest()
        {
            bool sucess = PerpetratorsManager.Update(all_perps[0]);
            Assert.IsTrue(sucess);
        }

        [TestMethod()]
        public void DeleteTest()
        {
            bool sucess = PerpetratorsManager.Delete(all_perps[0].id);
            Assert.IsTrue(sucess);
        }

        [TestMethod()]
        public void CreateTableTest()
        {
            bool sucess=PerpetratorsManager.CreateTable();
            Assert.IsTrue(sucess);
        }

        [TestMethod()]
        public void DropTableTest()
        {
            bool sucess = PerpetratorsManager.DropTable();
            Assert.IsTrue(sucess);
            PerpetratorsManager.CreateTable();      
        }

        [TestMethod()]
        public void PopulateTableTest()
        {
            foreach (var perp in all_perps) 
            {
               bool sucess= PerpetratorsManager.Save(perp);
               if (!sucess) 
               {
                   Assert.Fail();
                   return;
               }
            }
            Assert.IsTrue(true);
        }

        

        [TestMethod()]
        public void GetAllPerpetratorsTest()
        {
            Perpetrator[] perps = PerpetratorsManager.GetAllPerpetrators();
            Assert.IsNotNull(perps);
        }

        [TestMethod()]
        public void GetPerpetratorFacesTest()
        {
           //Image<Gray,byte>[] faces= PerpetratorsManager.GetPerpetratorFaces(id);
        }

        [TestMethod()]
        public void GetAllActivePerpetratorsTest()
        {
            Perpetrator[] perps = PerpetratorsManager.GetAllActivePerpetrators();
            Assert.IsNotNull(perps);
        }

        


    }
}
