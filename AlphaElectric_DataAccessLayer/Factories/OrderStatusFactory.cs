using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using AIS_DataAccessLayer.DA;


namespace AIS_DataAccessLayer.Factories
{
   
    public class OrderStatusFactory
    {
        OrderStatusDA ordstatusDa;

        public OrderStatusFactory()
        {
            ordstatusDa = new OrderStatusDA();
        }

        public List<OrderStatus> SelectAll()
        {
            return ordstatusDa.SelectAll();
        }

        public bool InsertOrderStatus(OrderStatus con)
        {
            return ordstatusDa.InsertOrderStatus(con);
        }

        public bool Update(int id, string name)
        {
            return ordstatusDa.Update(id, name);
        }
    }
}
