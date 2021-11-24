using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AIS_DataAccessLayer.DA
{
    class MakeDA
    {
        AlphaElectricEntitiesDB db;

        public MakeDA()
        {
            db = new AlphaElectricEntitiesDB();
        }

        public List<Make> SelectAll()
        {
            return db.Makes.ToList();
        }

        public bool InsertMake(Make mk)
        {
            db.Makes.Add(mk);
            return db.SaveChanges() > 0 ? true : false;
        }

 
        public bool Delete(int id)
        {
            var mk = db.Makes.Where(x => x.ID == id).FirstOrDefault();
            if (mk != null)
            {
                db.Makes.Remove(mk);
            }
            return db.SaveChanges() > 0 ? true : false;
        }

        public bool Update(int id, string name)
        {
            var mk = db.Makes.Where(x => x.ID == id).FirstOrDefault();
            if (mk != null)
            {
                mk.Name = name;
            }
            return db.SaveChanges() > 0 ? true : false;
        }
        
        
    }
}
