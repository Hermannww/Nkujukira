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
    public class SettingsManagerTests
    {
        private static Setting setting_1 = new Setting("similarity_threshold", "60");
        private static Setting setting_2 = new Setting("data_folder", "");
        private static Setting setting_3 = new Setting("theme", "Dark");
        private static Setting[] all_settings = { setting_1,setting_2,setting_3 };

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
            SettingsManager.CreateTable();
        }

        public void PopulateTable()
        {
            //WE GET ALL OBJECTS AT THE START ONLY INORDER TO REDUCE THE TIME TAKEN
            //TO RUN THE TESTS
            if (all_settings == null)
            {

                all_settings = SettingsManager.GetAllSettings();
            }

            foreach (var setting in all_settings)
            {
                SettingsManager.Save(setting);
            }
        }

        [TestCleanup]
        public void TearDown()
        {
            //AM THINKING THAT AFTER EACH TESt HAS RUN WE DISCARD THE CHANGES MADE THE CODE
            // AND RESTORE THE TABLE TO ITS ORIGINAL STATE
            if (all_settings != null)
            {
                SettingsManager.DropTable();
                CreateTableIfItDoesntExist();
                PopulateTable();
            }
        }

        [TestMethod()]
        public void SettingsManagerCreateTableTest()
        {
            bool sucess = SettingsManager.CreateTable();
            Assert.IsTrue(sucess);
        }

        [TestMethod()]
        public void SettingsManagerDropTableTest()
        {
            bool sucess = SettingsManager.DropTable();
            Assert.IsTrue(sucess);
        }

        [TestMethod()]
        public void SettingsManagerPopulateTableTest()
        {
            bool sucess = SettingsManager.PopulateTable();
            Assert.IsTrue(sucess);
        }

        [TestMethod()]
        public void SettingsManagerGetSettingTest()
        {
            Setting setting = SettingsManager.GetSetting(all_settings[0].name);
            Assert.IsNotNull(setting);
        }

        [TestMethod()]
        public void SettingsManagerGetAllSettingsTest()
        {
            Setting[] settings = SettingsManager.GetAllSettings();
            Assert.IsNotNull(settings);
        }

        [TestMethod()]
        public void SettingsManagerSaveTest()
        {
            bool sucess = SettingsManager.Save(all_settings[0]);
            Assert.IsTrue(sucess);
        }

        [TestMethod()]
        public void SettingsManagerDeleteTest()
        {
            bool sucess = SettingsManager.Delete(all_settings[0].id);
            Assert.IsTrue(sucess);
        }

        [TestMethod()]
        public void SettingsManagerUpdateTest()
        {
            bool sucess = SettingsManager.Update(all_settings[0]);
            Assert.IsTrue(sucess);
        }
    }
}
