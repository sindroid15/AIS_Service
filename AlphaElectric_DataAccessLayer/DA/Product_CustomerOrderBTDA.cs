using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace AIS_DataAccessLayer.DA
{
    class Product_CustomerOrderBTDA
    {
        AlphaElectricEntitiesDB db;

        public Product_CustomerOrderBTDA()
        {
            db = new AlphaElectricEntitiesDB();
        }

        public List<Product_CustomerOrderBT> SelectAll()
        {
            return db.Product_CustomerOrderBT.ToList();
        }

        public bool InsertProduct_CustomerOrderBT(Product_CustomerOrderBT productCustBT)
        {
            db.Product_CustomerOrderBT.Add(productCustBT);
            return db.SaveChanges() > 0 ? true : false;
        }

       
    }
}
