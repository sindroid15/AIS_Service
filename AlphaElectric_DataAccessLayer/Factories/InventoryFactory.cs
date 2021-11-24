using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using AIS_DataAccessLayer.DA;


namespace AIS_DataAccessLayer.Factories
{
  
    public class InventoryFactory
    {
        InventoryDA invenDa;

        public InventoryFactory()
        {
            invenDa = new InventoryDA();
        }

        public List<Inventory> SelectAll()
        {
            return invenDa.SelectAll();
        }

        public bool InsertInventory(Inventory inven)
        {
            return invenDa.InsertInventory(inven);
        }

        public bool Update(int id, int stocklevel, int locID)
        {
            return invenDa.Update(id, stocklevel, locID);
        }
    }
}
