using MetroFramework.Demo.Entitities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MetroFramework.Demo.Managers
{
    public class PerpetratorsManager 
    {
        public static int PERPETRATOR_ID = 0;

        public static  Entity[] All()
        {
            throw new NotImplementedException();
        }

        public static  Entity[] Where(string coloum, string condition, string value)
        {
            throw new NotImplementedException();
        }

        public static  Entity[] OrderBy(string coloum, string order)
        {
            throw new NotImplementedException();
        }

        public static Entity[] Get()
        {
            throw new NotImplementedException();
        }

        public static  Entity First()
        {
            throw new NotImplementedException();
        }

        public static Entity Last()
        {
            throw new NotImplementedException();
        }

        public static bool Save(Perpetrator perp) 
        {

            return false;
        }

        internal static void Delete(int perpetrator_id)
        {
            
        }
    }
}
