using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace AIS_DataAccessLayer.DA
{
    class OrderStatusDA
    {
        AlphaElectricEntitiesDB db;

        public OrderStatusDA()
        {
            db = new AlphaElectricEntitiesDB();
        }

        public List<OrderStatus> SelectAll()
        {
            return db.OrderStatus.ToList();
        }

        public bool InsertOrderStatus(OrderStatus con)
        {
            db.OrderStatus.Add(con);
            return db.SaveChanges() > 0 ? true : false;
        }

    

        public bool Update(int id, string name)
        {
            var con = db.OrderStatus.Where(x => x.ID == id).FirstOrDefault();
            if (con != null)
            {
                con.Name = name;
            }
            return db.SaveChanges() > 0 ? true : false;
        }
        
       
    }
}
