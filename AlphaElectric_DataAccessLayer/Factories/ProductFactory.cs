using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using AIS_DataAccessLayer.DA;


namespace AIS_DataAccessLayer.Factories
{
  
    public class ProductFactory
    {
        ProductDA prodDa;

        public ProductFactory()
        {
            prodDa = new ProductDA();
        }

        public List<Product> SelectAll()
        {
            return prodDa.SelectAll();
        }

        public List<Part> SelectAllPart()
        {
            return prodDa.SelectAllPart();
        }

        public List<Panel> SelectAllPanel()
        {
            return prodDa.SelectAllPanel();
        }

        public bool InsertProduct(Product prod)
        {
            return prodDa.InsertProduct(prod);
        }

        public bool Update(int id, string serialno, string name, int makeid)
        {
            return prodDa.Update(id, serialno, name, makeid);
        }
    }
}
