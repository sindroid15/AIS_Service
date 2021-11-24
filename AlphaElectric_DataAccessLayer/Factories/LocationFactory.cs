using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using AIS_DataAccessLayer.DA;


namespace AIS_DataAccessLayer.Factories
{
   
    public class LocationFactory
    {
        LocationDA locDa;

        public LocationFactory()
        {
            locDa = new LocationDA();
        }

        public List<Location> SelectAll()
        {
            return locDa.SelectAll();
        }

        public bool InsertLocation(Location desig)
        {
            return locDa.InsertLocation(desig);
        }
    }
}
