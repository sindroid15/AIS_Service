using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace AIS_DataAccessLayer.DA
{
    class InventoryDA
    {
        AlphaElectricEntitiesDB db;

        public InventoryDA()
        {
            db = new AlphaElectricEntitiesDB();
        }

        public List<Inventory> SelectAll()
        {
            return db.Inventories.ToList();
        }

        public bool InsertInventory(Inventory inven)
        {
            db.Inventories.Add(inven);
            return db.SaveChanges() > 0 ? true : false;
        }

        public bool Update(int id, int stocklevel, int locID)
        {
            var inven = db.Inventories.Where(x => x.ID == id).FirstOrDefault();
            if (inven != null)
            {
                inven.LocationID = locID;
                inven.StockLevel = stocklevel;
            }
            return db.SaveChanges() > 0 ? true : false;
        }

        
    }
}
