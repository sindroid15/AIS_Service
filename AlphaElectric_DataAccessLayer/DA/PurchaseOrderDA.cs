using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace AIS_DataAccessLayer.DA
{
    class PurchaseOrderDA
    {
        AlphaElectricEntitiesDB db;

        public PurchaseOrderDA()
        {
            db = new AlphaElectricEntitiesDB();
        }

        public List<PurchaseOrder> SelectAll()
        {
            return db.PurchaseOrders.ToList();
        }

        public bool InsertPurchaseOrder(PurchaseOrder po)
        {
            db.PurchaseOrders.Add(po);
            return db.SaveChanges() > 0 ? true : false;
        }

 
        public bool Delete(int id)
        {
            var po = db.PurchaseOrders.Where(x => x.ID == id).FirstOrDefault();
            if (po != null)
            {
                db.PurchaseOrders.Remove(po);
            }
            return db.SaveChanges() > 0 ? true : false;
        }

       
    }
}
