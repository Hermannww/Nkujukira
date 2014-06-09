using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MetroFramework.Demo.Interfaces;
using MetroFramework.Demo.DataStores;

namespace MetroFramework.Demo.Factories
{
    public class FileFactory
    {
        public FileInterface GetFile(String file_type)
        {
            if (file_type == null)
            {
                return null;
            }
            else if (file_type.Equals("TEXTFILE"))
            {
                return new TextFile();
            }
            else if (file_type.Equals("XMLFILE"))
            {
                return new XMLFile();
            }
            return null;
        }

    }
}
