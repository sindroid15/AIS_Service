using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;


namespace AIS_DataAccessLayer.DA
{
    class ProductDA
    {
        AlphaElectricEntitiesDB db;

        public ProductDA()
        {
            db = new AlphaElectricEntitiesDB();
        }

        public List<Product> SelectAll()
        {
            return db.Products.ToList();
        }

        public bool InsertProduct(Product prod)
        {
            db.Products.Add(prod);
            return db.SaveChanges() > 0 ? true : false;
        }

        public bool Update(int id, string serialno, string name, int makeid)
        {
            var prod = db.Products.Where(x => x.ID == id).FirstOrDefault();
            if (prod != null)
            {
                prod.SerialNo = serialno;
                prod.Name = name;
                prod.MakeID = makeid;
            }
            return db.SaveChanges() > 0 ? true : false;
        }

        

        public List<Part> SelectAllPart()
        {
            return db.Products.OfType<Part>().ToList();
        }

        public List<Panel> SelectAllPanel()
        {
            return db.Products.OfType<Panel>().ToList();
        }

      
    }
}
