using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using AIS_DataAccessLayer.DA;


namespace AIS_DataAccessLayer.Factories
{

    public class Product_PurchaseOrderBTFactory
    {
        Product_PurchaseOrderBTDA productPurchaseBTDa;

        public Product_PurchaseOrderBTFactory()
        {
            productPurchaseBTDa = new Product_PurchaseOrderBTDA();
        }

        public List<Product_PurchaseOrderBT> SelectAll()
        {
            return productPurchaseBTDa.SelectAll();
        }

        public bool InsertProduct_PurchaseOrderBT(Product_PurchaseOrderBT productPurchaseBT)
        {
            return productPurchaseBTDa.InsertProduct_PurchaseOrderBT(productPurchaseBT);
        }
    }
}
