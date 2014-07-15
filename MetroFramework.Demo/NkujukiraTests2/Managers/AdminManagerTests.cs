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
    public class AdminManagerTests
    {

        [TestMethod()]
        public void CreateTableTest()
        {
            bool sucess=AdminManager.CreateTable();
            Assert.IsTrue(sucess);

        }

        [TestMethod()]
        public void DropTableTest()
        {
            bool success=AdminManager.DropTable();
            Assert.IsTrue(success);
            AdminManager.CreateTable();
        }

        [TestMethod()]
        public void PopulateTableTest()
        {
            bool sucess = AdminManager.PopulateTable();
            Assert.IsTrue(sucess);
        }

        [TestMethod()]
        public void GetAdminTest()
        {

            Admin admin=AdminManager.GetAdmin("nsubugak", "@llison");
            Assert.IsNotNull(admin);
        }

        [TestMethod()]
        public void ExistsTest()
        {
            bool sucess = AdminManager.Exists("nsubugak");
            Assert.IsTrue(sucess);
        }

        [TestMethod()]
        public void GetAllAdminsTest()
        {
            Admin[] admins = AdminManager.GetAllAdmins();
            Assert.IsTrue(admins.Length >= 1);
        }

        [TestMethod()]
        public void SaveTest()
        {
            Admin admin=new Admin("kasoma","kasoma","admin");
            bool sucess = AdminManager.Save(admin);
            Assert.IsTrue(sucess);
        }

        [TestMethod()]
        public void DeleteTest()
        {
            bool sucess = AdminManager.Delete(new Admin("kasoma", "kasoma", "admin"));
            Assert.IsTrue(sucess);
        }

        [TestMethod()]
        public void UpdateTest()
        {
            bool sucess = AdminManager.Update(new Admin(1, "nsubugak", "@llison", "admin"));
            Assert.IsTrue(sucess);
        }
    }
}
