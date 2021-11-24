using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    public class EmployeeViewModel : IDataErrorInfo
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Passport { get; set; }
        public System.DateTime JoinDate { get; set; }
        public string Address { get; set; }
        public int DesignationID { get; set; }
        public int EmployeeStatusID { get; set; }

        public string Error
        {
            get
            {
                return null;
            }
        }
        public string this[string columnName]
        {
            get
            {
                string result = null;

              

                return result;
            }
        }
       
    }
}