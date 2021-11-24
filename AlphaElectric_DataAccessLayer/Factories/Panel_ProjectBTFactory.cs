using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using AIS_DataAccessLayer.DA;


namespace AIS_DataAccessLayer.Factories
{

    public class Panel_ProjectBTFactory
    {
        Panel_ProjectBTDA panelProjBTDa;

        public Panel_ProjectBTFactory()
        {
            panelProjBTDa = new Panel_ProjectBTDA();
        }

        public List<Panel_ProjectBT> SelectAll()
        {
            return panelProjBTDa.SelectAll();
        }

        public bool InsertPanel_ProjectBT(Panel_ProjectBT productPurchaseBT)
        {
            return panelProjBTDa.InsertPanel_ProjectBT(productPurchaseBT);
        }
    }
}
