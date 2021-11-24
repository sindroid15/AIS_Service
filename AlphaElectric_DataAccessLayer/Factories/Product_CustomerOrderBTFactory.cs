using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using AIS_DataAccessLayer.DA;


namespace AIS_DataAccessLayer.Factories
{

    public class Product_CustomerOrderBTFactory
    {
        Product_CustomerOrderBTDA productCustBTDa;

        public Product_CustomerOrderBTFactory()
        {
            productCustBTDa = new Product_CustomerOrderBTDA();
        }

        public List<Product_CustomerOrderBT> SelectAll()
        {
            return productCustBTDa.SelectAll();
        }

        public bool InsertProduct_CustomerOrderBT(Product_CustomerOrderBT productPurchaseBT)
        {
            return productCustBTDa.InsertProduct_CustomerOrderBT(productPurchaseBT);
        }
    }
}
