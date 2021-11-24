using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace AIS_DataAccessLayer.DA
{
    class EmployeeDA
    {
        AlphaElectricEntitiesDB db;

        public EmployeeDA()
        {
            db = new AlphaElectricEntitiesDB();
        }

        public List<Employee> SelectAll()
        {
            return db.Employees.ToList();
        }

        public List<Employee> SelectByDesignation(int id)
        {
            var emplist =  db.Employees.Where(x => x.DesignationID == id).ToList();

            foreach (var row in emplist)
                row.FirstName = row.FirstName + " " + row.LastName;

            return emplist;
        }


        public bool InsertEmployee(Employee emp)
        {
            db.Employees.Add(emp);
            return db.SaveChanges() > 0 ? true : false;
        }


        public bool Delete(int id)
        {
            var emp = db.Employees.Where(x => x.ID == id).FirstOrDefault();
            if (emp != null)
            {
                db.Employees.Remove(emp);
            }
            return db.SaveChanges() > 0 ? true : false;
        }

        public bool Update(int id, string firstname, string lastname, string phone, string passport, DateTime joindate, string address, int desigid, int statusid)
        {
            var emp = db.Employees.Where(x => x.ID == id).FirstOrDefault();
            if (emp != null)
            {
                emp.FirstName = firstname;
                emp.LastName = lastname;
                emp.Phone = phone;
                emp.Passport = passport;
                emp.JoinDate = joindate;
                emp.Address = address;
                emp.DesignationID = desigid;
                emp.EmployeeStatusID = statusid;
            }
            return db.SaveChanges() > 0 ? true : false;
        }
        
       
    }
}
