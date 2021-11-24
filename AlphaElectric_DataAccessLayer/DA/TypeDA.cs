using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace AIS_DataAccessLayer.DA
{
    class TypeDA
    {
        AlphaElectricEntitiesDB db;

        public TypeDA()
        {
            db = new AlphaElectricEntitiesDB();
        }

        public List<Type> SelectAll()
        {
            return db.Types.ToList();
        }

        public bool InsertType(Type type)
        {
            db.Types.Add(type);
            return db.SaveChanges() > 0 ? true : false;
        }


        public bool Delete(int id)
        {
            var type = db.Types.Where(x => x.ID == id).FirstOrDefault();
            if (type != null)
            {
                db.Types.Remove(type);
            }
            return db.SaveChanges() > 0 ? true : false;
        }

        public bool Update(int id, string descrip)
        {
            var type = db.Types.Where(x => x.ID == id).FirstOrDefault();
            if (type != null)
            {
                type.Description = descrip;
            }
            return db.SaveChanges() > 0 ? true : false;
        }
       
    }
}
