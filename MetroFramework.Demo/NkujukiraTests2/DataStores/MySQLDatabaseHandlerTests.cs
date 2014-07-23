using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nkujukira.Demo.DataStores;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.Common;
namespace Nkujukira.Demo.DataStores.Tests
{
    [TestClass()]
    public class MySQLDatabaseHandlerTests
    {
        String username = "root";
        String password = "";
        String database = "nkujukira";
        String server = "localhost";

        [TestMethod()]
        public void MySQLDatabaseHandlerConstructorTest()
        {
          
            MySQLDatabaseHandler handler=new MySQLDatabaseHandler(server,database,username,password);
            Assert.IsNotNull(handler);
        }

        [TestMethod()]
        public void MySQLDatabaseHandlerOpenConnectionTest()
        {
            MySQLDatabaseHandler handler = new MySQLDatabaseHandler(server, database, username, password);
            DbConnection con= handler.OpenConnection();
            Assert.IsNotNull(con);
            handler.CloseConnection();
        }

        [TestMethod()]
        public void MySQLDatabaseHandlerCloseConnectionTest()
        {
            MySQLDatabaseHandler handler = new MySQLDatabaseHandler(server, database, username, password);
            DbConnection con = handler.OpenConnection();
            bool sucess=handler.CloseConnection();
            Assert.IsTrue(sucess);
        }


        [TestMethod()]
        public void MySQLDatabaseHandlerInsertTest()
        {
        }

        [TestMethod()]
        public void MySQLDatabaseHandlerUpdateTest()
        {
            
        }

        [TestMethod()]
        public void MySQLDatabaseHandlerDeleteTest()
        {
           
        }

        [TestMethod()]
        public void MySQLDatabaseHandlerSelectTest()
        {
            
        }

        [TestMethod()]
        public void MySQLDatabaseHandlerCountTest()
        {
           
        }

        [TestMethod()]
        public void MySQLDatabaseHandlerBackupTest()
        {
            
        }

        [TestMethod()]
        public void MySQLDatabaseHandlerRestoreTest()
        {
          
        }

        [TestMethod()]
        public void MySQLDatabaseHandlerGetConnectionTest()
        {
          
        }
    }
}
