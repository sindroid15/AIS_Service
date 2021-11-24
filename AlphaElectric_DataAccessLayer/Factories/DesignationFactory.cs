using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using AIS_DataAccessLayer.DA;


namespace AIS_DataAccessLayer.Factories
{
    
    public class DesignationFactory
    {
        DesignationDA desigDa;

        public DesignationFactory()
        {
            desigDa = new DesignationDA();
        }

        public List<Designation> SelectAll()
        {
            return desigDa.SelectAll();
        }

        public bool InsertDesignation(Designation desig)
        {
            return desigDa.InsertDesignation(desig);
        }
    }
}
