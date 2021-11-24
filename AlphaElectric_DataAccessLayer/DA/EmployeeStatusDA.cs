using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace AIS_DataAccessLayer.DA
{
    class EmployeeStatusDA
    {
        AlphaElectricEntitiesDB db;

        public EmployeeStatusDA()
        {
            db = new AlphaElectricEntitiesDB();
        }

        public List<EmployeeStatus> SelectAll()
        {
            return db.EmployeeStatus.ToList();
        }

        public bool InsertEmployeeStatus(EmployeeStatus empStatus)
        {
            db.EmployeeStatus.Add(empStatus);
            return db.SaveChanges() > 0 ? true : false;
        }

        //CHECK IT
        public bool Delete(int id)
        {
            var empStatus = db.EmployeeStatus.Where(x => x.ID == id).FirstOrDefault();
            if (empStatus != null)
            {
                db.EmployeeStatus.Remove(empStatus);
            }
            return db.SaveChanges() > 0 ? true : false;
        }

        public bool Update(int id, string name)
        {
            var empStatus = db.EmployeeStatus.Where(x => x.ID == id).FirstOrDefault();
            if (empStatus != null)
            {
                empStatus.Name = name;
            }
            return db.SaveChanges() > 0 ? true : false;
        }
        
       
    }
}
