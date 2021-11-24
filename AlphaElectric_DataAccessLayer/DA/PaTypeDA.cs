using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace AIS_DataAccessLayer.DA
{
    class PaTypeDA
    {
        AlphaElectricEntitiesDB db;

        public PaTypeDA()
        {
            db = new AlphaElectricEntitiesDB();
        }

        public List<PaType> SelectAll()
        {
            return db.PaTypes.ToList();
        }

        public bool InsertPaType(PaType patype)
        {
            db.PaTypes.Add(patype);
            return db.SaveChanges() > 0 ? true : false;
        }


        public bool Delete(int id)
        {
            var patype = db.PaTypes.Where(x => x.ID == id).FirstOrDefault();
            if (patype != null)
            {
                db.PaTypes.Remove(patype);
            }
            return db.SaveChanges() > 0 ? true : false;
        }

        public bool Update(int id, string name)
        {
            var patype = db.PaTypes.Where(x => x.ID == id).FirstOrDefault();
            if (patype != null)
            {
                patype.Name = name;
            }
            return db.SaveChanges() > 0 ? true : false;
        }
        
       
    }
}
