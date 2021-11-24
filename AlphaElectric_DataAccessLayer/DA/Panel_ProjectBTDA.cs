using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace AIS_DataAccessLayer.DA
{
    class Panel_ProjectBTDA
    {
        AlphaElectricEntitiesDB db;

        public Panel_ProjectBTDA()
        {
            db = new AlphaElectricEntitiesDB();
        }

        public List<Panel_ProjectBT> SelectAll()
        {
            return db.Panel_ProjectBT.ToList();
        }

        public bool InsertPanel_ProjectBT(Panel_ProjectBT panelProjBT)
        {
            db.Panel_ProjectBT.Add(panelProjBT);
            return db.SaveChanges() > 0 ? true : false;
        }

        
    }
}
