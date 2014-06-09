using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MetroFramework.Demo.Interfaces
{
    public interface FileInterface
    {
        bool writeToFile(String file_name, String text);
        String readFromFile(String file_name);
    }
}
