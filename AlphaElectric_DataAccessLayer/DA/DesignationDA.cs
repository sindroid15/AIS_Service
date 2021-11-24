using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace AIS_DataAccessLayer.DA
{
    class DesignationDA
    {
        AlphaElectricEntitiesDB db;

        public DesignationDA()
        {
            db = new AlphaElectricEntitiesDB();
        }

        public List<Designation> SelectAll()
        {
            return db.Designations.ToList();
        }

        public bool InsertDesignation(Designation desig)
        {
            db.Designations.Add(desig);
            return db.SaveChanges() > 0 ? true : false;
        }

    
        public bool Delete(int id)
        {
            var desig = db.Designations.Where(x => x.ID == id).FirstOrDefault();
            if (desig != null)
            {
                db.Designations.Remove(desig);
            }
            return db.SaveChanges() > 0 ? true : false;
        }

        public bool Update(int id, string name)
        {
            var desig = db.Designations.Where(x => x.ID == id).FirstOrDefault();
            if (desig != null)
            {
                desig.Name = name;
            }
            return db.SaveChanges() > 0 ? true : false;
        }
        
       
    }
}
