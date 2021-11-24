using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using AIS_DataAccessLayer.DA;


namespace AIS_DataAccessLayer.Factories
{

    public class CustomerOrderFactory
    {
        CustomerOrderDA coDa;

        public CustomerOrderFactory()
        {
            coDa = new CustomerOrderDA();
        }

        public List<CustomerOrder> SelectAll()
        {
            return coDa.SelectAll();
        }

        public bool InsertCustomerOrder(CustomerOrder po)
        {
            return coDa.InsertCustomerOrder(po);
        }
    }
}
