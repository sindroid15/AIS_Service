using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace AIS_DataAccessLayer.DA
{
    class CustomerOrderDA
    {
        AlphaElectricEntitiesDB db;

        public CustomerOrderDA()
        {
            db = new AlphaElectricEntitiesDB();
        }

        public List<CustomerOrder> SelectAll()
        {
            return db.CustomerOrders.ToList();
        }

        public bool InsertCustomerOrder(CustomerOrder co)
        {
            db.CustomerOrders.Add(co);
            return db.SaveChanges() > 0 ? true : false;
        }

 
        public bool Delete(int id)
        {
            var po = db.CustomerOrders.Where(x => x.ID == id).FirstOrDefault();
            if (po != null)
            {
                db.CustomerOrders.Remove(po);
            }
            return db.SaveChanges() > 0 ? true : false;
        }

     
    }
}
