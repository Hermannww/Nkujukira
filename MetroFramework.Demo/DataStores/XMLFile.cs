using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MetroFramework.Demo.Interfaces;

namespace MetroFramework.Demo.DataStores
{
    public class XMLFile:FileInterface
    {
        public bool writeToFile(String file_name, String text)
        {
            return false;
        }
        public String readFromFile(String file_name) {
            return null;
        }
    }
}
