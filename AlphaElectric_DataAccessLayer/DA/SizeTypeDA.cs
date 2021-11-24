using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace AIS_DataAccessLayer.DA
{
    class SizeTypeDA
    {
        AlphaElectricEntitiesDB db;

        public SizeTypeDA()
        {
            db = new AlphaElectricEntitiesDB();
        }

        public List<SizeType> SelectAll()
        {
            return db.SizeTypes.ToList();
        }

        public bool InsertSizeType(SizeType sztype)
        {
            db.SizeTypes.Add(sztype);
            return db.SaveChanges() > 0 ? true : false;
        }


        public bool Delete(int id)
        {
            var sztype = db.SizeTypes.Where(x => x.ID == id).FirstOrDefault();
            if (sztype != null)
            {
                db.SizeTypes.Remove(sztype);
            }
            return db.SaveChanges() > 0 ? true : false;
        }

        public bool Update(int id, string descrip)
        {
            var sztype = db.SizeTypes.Where(x => x.ID == id).FirstOrDefault();
            if (sztype != null)
            {
                sztype.Description = descrip;
            }
            return db.SaveChanges() > 0 ? true : false;
        }
        
       
    }
}
