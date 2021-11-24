using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using AIS_DataAccessLayer.DA;


namespace AIS_DataAccessLayer.Factories
{

    public class SizeTypeFactory
    {
        SizeTypeDA sztypeDa;

        public SizeTypeFactory()
        {
            sztypeDa = new SizeTypeDA();
        }

        public List<SizeType> SelectAll()
        {
            return sztypeDa.SelectAll();
        }

        public bool InsertSizeType(SizeType sztype)
        {
            return sztypeDa.InsertSizeType(sztype);
        }
    }
}
