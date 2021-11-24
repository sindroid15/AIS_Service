using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using AIS_DataAccessLayer.DA;


namespace AIS_DataAccessLayer.Factories
{

    public class PurchaseOrderFactory
    {
        PurchaseOrderDA poDa;

        public PurchaseOrderFactory()
        {
            poDa = new PurchaseOrderDA();
        }

        public List<PurchaseOrder> SelectAll()
        {
            return poDa.SelectAll();
        }

        public bool InsertPurchaseOrder(PurchaseOrder po)
        {
            return poDa.InsertPurchaseOrder(po);
        }
    }
}
