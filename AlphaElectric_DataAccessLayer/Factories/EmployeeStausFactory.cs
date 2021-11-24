using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using AIS_DataAccessLayer.DA;


namespace AIS_DataAccessLayer.Factories
{
 
    public class EmployeeStatusFactory
    {
        EmployeeStatusDA empStatusDa;

        public EmployeeStatusFactory()
        {
            empStatusDa = new EmployeeStatusDA();
        }

        public List<EmployeeStatus> SelectAll()
        {
            return empStatusDa.SelectAll();
        }

        public bool InsertEmployeeStatus(EmployeeStatus desig)
        {
            return empStatusDa.InsertEmployeeStatus(desig);
        }
    }
}
