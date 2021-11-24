using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace AIS_DataAccessLayer.DA
{
    class ProjectDA
    {
        AlphaElectricEntitiesDB db;

        public ProjectDA()
        {
            db = new AlphaElectricEntitiesDB();
        }

        public List<Project> SelectAll()
        {
            return db.Projects.ToList();
        }

        public bool InsertProject(Project proj)
        {
            db.Projects.Add(proj);
            return db.SaveChanges() > 0 ? true : false;
        }


        public bool Delete(int id)
        {
            var proj = db.Projects.Where(x => x.ID == id).FirstOrDefault();
            if (proj != null)
            {
                db.Projects.Remove(proj);
            }
            return db.SaveChanges() > 0 ? true : false;
        }

        public bool Update(int id, string name, int statusID, DateTime de)
        {
            var proj = db.Projects.Where(x => x.ID == id).FirstOrDefault();
            if (proj != null)
            {
                proj.Name = name;
                proj.CustomerOrder.OrderStatusID = statusID;
                proj.DeliveyDate = de;
              
            }
            return db.SaveChanges() > 0 ? true : false;
        }
        
       
    }
}
