using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using AIS_DataAccessLayer.DA;


namespace AIS_DataAccessLayer.Factories
{
  
    public class PanelShellGradeProtectionFactory
    {
        PanelShellGradeProtectionDA pgradeDa;

        public PanelShellGradeProtectionFactory()
        {
            pgradeDa = new PanelShellGradeProtectionDA();
        }

        public List<PanelShellGradeProtection> SelectAll()
        {
            return pgradeDa.SelectAll();
        }

        public bool InsertPanelShellGradeProtection(PanelShellGradeProtection pgrade)
        {
            return pgradeDa.InsertPanelShellGradeProtection(pgrade);
        }
    }
}
