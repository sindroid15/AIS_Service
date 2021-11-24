using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using AIS_DataAccessLayer.DA;


namespace AIS_DataAccessLayer.Factories
{

    public class PaTypeFactory
    {
        PaTypeDA patypeDa;

        public PaTypeFactory()
        {
            patypeDa = new PaTypeDA();
        }

        public List<PaType> SelectAll()
        {
            return patypeDa.SelectAll();
        }

        public bool InsertPaType(PaType patype)
        {
            return patypeDa.InsertPaType(patype);
        }
    }
}
