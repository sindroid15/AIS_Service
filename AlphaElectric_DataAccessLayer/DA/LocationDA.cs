using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace AIS_DataAccessLayer.DA
{
    class LocationDA
    {
        AlphaElectricEntitiesDB db;

        public LocationDA()
        {
            db = new AlphaElectricEntitiesDB();
        }

        public List<Location> SelectAll()
        {
            return db.Locations.ToList();
        }

        public bool InsertLocation(Location loc)
        {
            db.Locations.Add(loc);
            return db.SaveChanges() > 0 ? true : false;
        }

    
        public bool Delete(int id)
        {
            var desig = db.Locations.Where(x => x.ID == id).FirstOrDefault();
            if (desig != null)
            {
                db.Locations.Remove(desig);
            }
            return db.SaveChanges() > 0 ? true : false;
        }

        public bool Update(int id, string name)
        {
            var loc = db.Locations.Where(x => x.ID == id).FirstOrDefault();
            if (loc != null)
            {
                loc.Name = name;
            }
            return db.SaveChanges() > 0 ? true : false;
        }
        
       
    }
}
