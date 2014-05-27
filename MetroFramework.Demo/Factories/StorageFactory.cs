using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MetroFramework.Demo.Factories
{
    public class StorageFactory : AbstractFactory
    {
        public const String DATABASE_FACTORY = "Database";
        public const String FILE_FACTORY     = "File";

        public StorageFactory GetStorage(String type) 
        {
            switch (type) 
            {

                case DATABASE_FACTORY:
                    return new DatabaseFactory();

                case FILE_FACTORY:
                    return new FileFactory();

            }
            return null;
        }

    }
}
